import { availableCagesDetect } from "../availableCagesDetectors/availableCagesDetect"

export const moveInAvailbaleCages = (pieces, piece, moveTo) => {
    const availableCages = availableCagesDetect(pieces, piece)

    return !!availableCages.find(cage => cage.posX === moveTo.posX && cage.posY === moveTo.posY)
}