import { BISHOP } from "../../../utils/pieceNames"
import { AvailableCagesHelper } from "../helpers/AvailableCagesHelper";

export const bishopAvailableCagesDetect = (pieces, piece) => {
    if(!piece || piece.name !== BISHOP)
        return;

    const availableCages = []
    availableCages.push(...AvailableCagesHelper.getAvailableCagesMovingWith(pieces, piece, 1, 1))
    availableCages.push(...AvailableCagesHelper.getAvailableCagesMovingWith(pieces, piece, -1, 1))
    availableCages.push(...AvailableCagesHelper.getAvailableCagesMovingWith(pieces, piece, 1, -1))
    availableCages.push(...AvailableCagesHelper.getAvailableCagesMovingWith(pieces, piece, -1, -1))

    return availableCages
}