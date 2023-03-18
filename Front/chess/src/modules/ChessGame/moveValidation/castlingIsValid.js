import { BLACK } from "../../../utils/colors"
import { KING, ROCK } from "../../../utils/pieceNames"
import { isCheckInPosition } from "../checkDetectors/isCheckInPosition"
import { PiecesHelper } from "../helpers/PiecesHelper"
import { isCheckAfterMove } from "./isCheckAfterMove"

export const castlingIsValid = (currentGame, king, to) => {
    const rook = getRookForCastling(currentGame.pieces, king, to)
    if(king.name !== KING || !rook || rook.name !== ROCK || rook.isMoved || king.isMoved)
        return false

    if(isCheckInPosition(currentGame.pieces, king.color))
        return false

    const cagesForKingMove = getCagesThatMustNotBeAttakedForCastling(king, to)
    for(let cage of cagesForKingMove){
        if(PiecesHelper.getPiece(currentGame.pieces, cage) || isCheckAfterMove(currentGame.pieces, king, to))
            return false
        
    }

    return true
}

const getCagesThatMustNotBeAttakedForCastling = (king, to) => {
    const cagesForKingMove = []

    if(to.posX > king.validPosition.posX){
        cagesForKingMove.push({posY: king.validPosition.posY, posX: king.validPosition.posX + 1})
        cagesForKingMove.push({posY: king.validPosition.posY, posX: king.validPosition.posX + 2})
    }else{
        cagesForKingMove.push({posY: king.validPosition.posY, posX: king.validPosition.posX - 1})
        cagesForKingMove.push({posY: king.validPosition.posY, posX: king.validPosition.posX - 2})
    }

    return cagesForKingMove
}

const getRookForCastling = (pieces, king, to) => {
    let posX = 1
    let posY = 1

    if(king.validPosition.posX < to.posX)
        posX = 8
    
    if(king.color === BLACK)
        posY = 8

    return pieces.find(p => p.validPosition.posX == posX && p.validPosition.posY == posY)
}