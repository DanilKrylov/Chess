import { KNIGHT } from "../../../utils/pieceNames";
import { PiecesHelper } from "../helpers/PiecesHelper"

export const knightAvailableCagesDetect = (pieces, piece) => {
    if(!piece || piece.name !== KNIGHT)
        return;

    const posDifferences = [-2, -1, 1, 2]
    const availableCages = []
    for(let horDiff of posDifferences){
        for(let vertDiff of posDifferences){
            if(Math.abs(vertDiff) === Math.abs(horDiff))
                continue

            const currentPos = {posX: piece.validPosition.posX + horDiff, posY: piece.validPosition.posY + vertDiff}
            if(PiecesHelper.canBeSetedToPosition(pieces, currentPos, piece.color).canBeSetted)
                availableCages.push(currentPos)
        }
    }

    return availableCages
}