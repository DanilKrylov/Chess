import { KING } from "../../../utils/pieceNames"
import { availableCagesDetect } from "../availableCagesDetectors/availableCagesDetect"

export const isCheckInPosition = (pieces, checkToColor) => {
    const king = pieces.find(p => p.name === KING && p.color === checkToColor)
    console.log(king, pieces, checkToColor)
    for(let piece of pieces.filter(p => p.color !== checkToColor)){
        const availableCages = availableCagesDetect(pieces, piece)
        if(availableCages.find(cage => cage.posX === king.validPosition.posX && cage.posY === king.validPosition.posY))
            return true
    }
    return false
}