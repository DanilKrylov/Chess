import { BLACK, WHITE } from "../../../utils/colors"
import { PiecesHelper } from "../helpers/PiecesHelper"

export const isMoveValidOnEmptyBoard = (pieces, from, to, playerRole, moveColor) => {
    return isMoveAvailablePiece(pieces, from, playerRole) &&
           moveIsNotOnSpot(from, to) &&
           playerCanDoMove(playerRole, moveColor)
}

const isMoveAvailablePiece = (pieces, from, playerRole) => {
    const piece = PiecesHelper.getPiece(pieces, from)
    if(!piece)
        return false
    
    return (piece.color === WHITE && playerRole === WHITE) ||
           (piece.color === BLACK && playerRole === BLACK)
}

const moveIsNotOnSpot = (from, to) => {
    return !PiecesHelper.positionsIsEquals(from, to)
}

const playerCanDoMove = (playerRole, moveColor) => {
    return playerRole === moveColor
}