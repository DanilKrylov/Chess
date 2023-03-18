import { detectCheckmate, doCastling, movePiece } from "../../http/gameAPI"
import { BLACK, WHITE } from "../../utils/colors"
import { CASTLING_MOVE, DEFAULT_MOVE } from "../../utils/moveTypes"
import { isCheckMateInPosition } from "./checkDetectors/isCheckMateInPosition"
import { MoveTypeHelper } from "./helpers/MoveTypeHelper"
import { PiecesHelper } from "./helpers/PiecesHelper"
import { castlingIsValid } from "./moveValidation/castlingIsValid"
import { moveIsValid } from "./moveValidation/moveIsValid"

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

export const tryMovePieceByPlayer = async (from, to, currentGame, gameId) => {
    const piece = PiecesHelper.getPiece(currentGame.pieces, from)
    const moveType = MoveTypeHelper.getMoveType(piece, to)
    switch (moveType) {
        case DEFAULT_MOVE:
            if (currentGame.isEnded || !moveIsValid(currentGame.pieces, piece, to, currentGame.playerRole, currentGame.moveTurn)) {
                return false
            }

            try {
                await movePiece(gameId, from, to)
            }
            catch {
                return false
            }
            break
        case CASTLING_MOVE:
            if (currentGame.isEnded || !castlingIsValid(currentGame, piece, to)) {
                return false
            }

            try {
                await doCastling(gameId, piece, to)
            }
            catch {
                return false
            }
            break
    }

    return true
}

export const tryDetectCheckMate = async (pieces, checkMateToColor, gameId, playerRole) => {
    if ((playerRole !== BLACK && playerRole !== WHITE) || checkMateToColor === playerRole)
        return

    if (isCheckMateInPosition(pieces, checkMateToColor))
        await detectCheckmate(gameId)
}