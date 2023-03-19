import { moveIsValid } from "./moveIsValid"

export const pawnPromotionIsValid = (currentGame, pawn, to) => {
    return pawn && moveIsValid(currentGame.pieces, pawn, to, currentGame.playerRole, currentGame.moveTurn)
} 