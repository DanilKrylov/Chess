import { detectCheckmate, movePiece } from "../../http/gameAPI"
import { BLACK, WHITE } from "../../utils/colors"
import { isCheckMateInPosition } from "./checkDetectors/isCheckMateInPosition"
import { PiecesHelper } from "./helpers/PiecesHelper"
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
    
    if (currentGame.isEnded || !moveIsValid(currentGame.pieces, piece, to, currentGame.playerRole, currentGame.moveTurn)) {
        return false
    }

    try {
        await movePiece(gameId, from, to)
    }
    catch {
        return false
    }

    return true
}

export const tryDetectCheckMate = async (pieces, checkMateToColor, gameId, playerRole) => {
    if((playerRole !== BLACK && playerRole !== WHITE) || checkMateToColor === playerRole)
        return

    console.log(pieces)
    if(isCheckMateInPosition(pieces, checkMateToColor))
        await detectCheckmate(gameId)
}