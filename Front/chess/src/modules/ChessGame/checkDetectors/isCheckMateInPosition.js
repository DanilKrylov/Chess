import { availableCagesDetect } from "../availableCagesDetectors/availableCagesDetect"
import { PiecesHelper } from "../helpers/PiecesHelper"
import { isCheckInPosition } from "./isCheckInPosition"

export const isCheckMateInPosition = (pieces, checkMateToColor) => {
    if(!isCheckInPosition(pieces, checkMateToColor))
        return false

    for(let piece of pieces.filter(p => p.color === checkMateToColor)){
        const availableCagesForPiece = availableCagesDetect(pieces, piece)

        for(let availableCage of availableCagesForPiece){
            const piecesAfterMove = PiecesHelper.getPiecesWithMovedPiece(pieces, piece, availableCage)
            if(!isCheckInPosition(piecesAfterMove, checkMateToColor)) 
                return false
        }
    }

    return true
}