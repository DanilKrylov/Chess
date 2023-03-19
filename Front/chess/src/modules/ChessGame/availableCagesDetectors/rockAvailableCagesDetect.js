import { ROOK } from "../../../utils/pieceNames";
import { AvailableCagesHelper } from "../helpers/AvailableCagesHelper";

export const rockAvailableCagesDetect = (pieces, piece) => {
    if(!piece || piece.name !== ROOK)
        return;
    
    const availableCages = []
    availableCages.push(...AvailableCagesHelper.getAvailableCagesMovingWith(pieces, piece, 1, 0))
    availableCages.push(...AvailableCagesHelper.getAvailableCagesMovingWith(pieces, piece, -1, 0))
    availableCages.push(...AvailableCagesHelper.getAvailableCagesMovingWith(pieces, piece, 0, 1))
    availableCages.push(...AvailableCagesHelper.getAvailableCagesMovingWith(pieces, piece, 0, -1))

    return availableCages
}