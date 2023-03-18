import { isCheckInPosition } from "../checkDetectors/isCheckInPosition"
import { PiecesHelper } from "../helpers/PiecesHelper"

export const isCheckAfterMove = (piecesBeforeMove, piece, toPos) =>{
    const piecesWithMovedCurrentPiece = PiecesHelper.getPiecesWithMovedPiece(piecesBeforeMove, piece, toPos)
    return isCheckInPosition(piecesWithMovedCurrentPiece, piece.color)
}