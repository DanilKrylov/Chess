import { WHITE } from "../../../utils/colors";
import { PAWN } from "../../../utils/pieceNames";
import { PiecesHelper } from "../helpers/PiecesHelper";

export const pawnAvailableCagesDetect = (pieces, piece) =>{
    if(!piece || piece.name !== PAWN)
        return;
    
    const availableCages = []
    const colorKoef = piece.color === WHITE ? 1 : -1
    const {posY, posX} = piece.validPosition
    let checkingPos = {posY: posY + 1 * colorKoef, posX: posX}
    
    if(!PiecesHelper.pieceExist(pieces, checkingPos)){
        availableCages.push(checkingPos)
        checkingPos = {posY: posY + 2 * colorKoef, posX: posX}
        if(getPawnPosYStart(piece.color) === piece.validPosition.posY && !PiecesHelper.pieceExist(pieces, checkingPos))
            availableCages.push(checkingPos)
    }

    if(posY !== 1){
        checkingPos = {posY: posY + 1 * colorKoef, posX: posX - 1}
        addAvailabelCagesIfPieceColorIsOpposite(checkingPos, availableCages, pieces, piece.color)
    }

    if(posY !== 8){
        checkingPos = {posY: posY + 1 * colorKoef, posX: posX + 1}
        addAvailabelCagesIfPieceColorIsOpposite(checkingPos, availableCages, pieces, piece.color)
    }

    return availableCages
}

const getPawnPosYStart = (color) => {
    if(color === WHITE)
        return 2;
    
    return 7
} 

const addAvailabelCagesIfPieceColorIsOpposite = (checkingPos, availableCages, pieces, pieceColor) => {
    const checkingPiece = PiecesHelper.getPiece(pieces, checkingPos)
    if(checkingPiece && checkingPiece.color !== pieceColor)
        availableCages.push(checkingPos)
}