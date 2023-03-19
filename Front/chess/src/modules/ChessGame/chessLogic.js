import { detectCheckmate, doCastling, doPawnPromotion, movePiece } from "../../http/gameAPI"
import { BLACK, WHITE } from "../../utils/colors"
import { CASTLING_MOVE, DEFAULT_MOVE, PAWN_PROMOTE_MOVE } from "../../utils/moveTypes"
import { QUEEN } from "../../utils/pieceNames"
import { isCheckMateInPosition } from "./checkDetectors/isCheckMateInPosition"
import { MoveTypeHelper } from "./helpers/MoveTypeHelper"
import { PiecesHelper } from "./helpers/PiecesHelper"
import { castlingIsValid } from "./moveValidation/castlingIsValid"
import { moveIsValid } from "./moveValidation/moveIsValid"
import { pawnPromotionIsValid } from "./moveValidation/pawnPromotionIsValid"

export const setCurrentGameInfo = (currentGameContext, game, userEmail) => {
    if (userEmail === game.whitePlayerEmail) {
        currentGameContext.setPlayerRole("White")
        currentGameContext.setPlayerEmail(game.whitePlayerEmail)
        currentGameContext.setOpponentEmail(game.blackPlayerEmail)
    }
    else if (userEmail === game.blackPlayerEmail) {
        currentGameContext.setPlayerRole("Black")
        currentGameContext.setPlayerEmail(game.blackPlayerEmail)
        currentGameContext.setOpponentEmail(game.whitePlayerEmail)
    }
    else {
        currentGameContext.setPlayerRole("Viewer")
        currentGameContext.setPlayerEmail(game.whitePlayerEmail)
        currentGameContext.setOpponentEmail(game.blackPlayerEmail)
    }

    currentGameContext.setPieces(game.pieces.map(p => { return { ...p, validPosition: p.position } }))
    currentGameContext.setMoveTurn(game.moveTurn)
    currentGameContext.setWinnerPlayerEmail(game.gameResult.winnerPlayerEmail)
    currentGameContext.setIsEnded(game.gameResult.isEnded)
}

export const tryMovePieceByPlayer = async (from, to, currentGame, gameId, proposingChooserInfo) => {
    if (currentGame.isEnded)
        return false

    const piece = PiecesHelper.getPiece(currentGame.pieces, from)
    const moveType = MoveTypeHelper.getMoveType(piece, to)
    switch (moveType) {
        case DEFAULT_MOVE:
            return await tryMovePiece(currentGame, piece, to, gameId)
        case CASTLING_MOVE:
            return await tryDoCastling(currentGame, piece, to, gameId)
        case PAWN_PROMOTE_MOVE:
            return await tryPromotePawn(currentGame, piece, to, gameId, proposingChooserInfo)
    }
}

export const tryDetectCheckMate = async (pieces, checkMateToColor, gameId, playerRole) => {
    if ((playerRole !== BLACK && playerRole !== WHITE) || checkMateToColor === playerRole)
        return

    if (isCheckMateInPosition(pieces, checkMateToColor))
        await detectCheckmate(gameId)
}

const tryDoCastling = async (currentGame, piece, to, gameId) => {
    if (!castlingIsValid(currentGame, piece, to))
        return false

    try {
        await doCastling(gameId, piece, to)
    }
    catch {
        return false
    }

    return true
}

const tryPromotePawn = async (currentGame, piece, to, gameId, proposingChooserInfo) => {
    if (!pawnPromotionIsValid(currentGame, piece, to))
        return false

    proposingChooserInfo.setIsInPieceMenu(true)
    proposingChooserInfo.setPawnPos(to)
    proposingChooserInfo.setOnSelectPiece(async (pieceName) => {
        console.log(pieceName)
        try {
            await doPawnPromotion(gameId, piece.validPosition, to, pieceName)
        }
        catch {
        }
        proposingChooserInfo.clear()
    })
    return false
}

const tryMovePiece = async (currentGame, piece, to, gameId) => {
    if (!moveIsValid(currentGame.pieces, piece, to, currentGame.playerRole, currentGame.moveTurn))
        return false

    try {
        await movePiece(gameId, piece.validPosition, to)
    }
    catch {
        return false
    }

    return true
}