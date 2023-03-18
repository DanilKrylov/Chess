import { bishopAvailableCagesDetect } from "./bishopAvailableCagesDetect"
import { kingAvailableCagesDetect } from "./kingAvailableCagesDetect"
import { knightAvailableCagesDetect } from "./knightAvailableCagesDetect"
import { pawnAvailableCagesDetect } from "./pawnAvailableCagesDetect"
import { queenAvailableCagesDetect } from "./queenAvailableCagesDetect"
import { rockAvailableCagesDetect } from "./rockAvailableCagesDetect"

export const availableCagesDetect = (pieces, piece) => {
    for(let detect of detects){
        const detectResult = detect(pieces, piece)
        if(detectResult)
            return detectResult
    }
}

const detects = [
    pawnAvailableCagesDetect,
    kingAvailableCagesDetect,
    knightAvailableCagesDetect,
    bishopAvailableCagesDetect,
    rockAvailableCagesDetect,
    queenAvailableCagesDetect
]