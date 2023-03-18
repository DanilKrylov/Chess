import { KING } from "../../../utils/pieceNames"
import { PiecesHelper } from "../helpers/PiecesHelper";

export const kingAvailableCagesDetect = (pieces, piece) =>{
    if(!piece || piece.name !== KING)
        return;

    const availableCages = []
    const {posY, posX} = piece.validPosition

    for(let vertDiff = -1; vertDiff <= 1; vertDiff++){
        for(let horDiff = -1; horDiff <= 1; horDiff++){
            if(vertDiff === 0 && horDiff === 0)
                continue;

            const currentPosX = posX + horDiff
            const currentPosY = posY + vertDiff

            if(currentPosX > 8 || currentPosY > 8 || currentPosX < 1 || currentPosY < 1)
                continue;

            const checkingPos = {posX: currentPosX, posY: currentPosY}
            const pieceOnCage = PiecesHelper.getPiece(pieces, checkingPos)
            if(!pieceOnCage || pieceOnCage.color !== piece.color)
                availableCages.push(checkingPos)
        }
    }

    return availableCages
}