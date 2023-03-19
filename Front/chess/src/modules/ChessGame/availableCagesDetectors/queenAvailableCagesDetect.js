import { BISHOP, QUEEN, ROOK } from "../../../utils/pieceNames";
import { bishopAvailableCagesDetect } from "./bishopAvailableCagesDetect";
import { rockAvailableCagesDetect } from "./rockAvailableCagesDetect";

export const queenAvailableCagesDetect = (pieces, piece) => {
    if(!piece || piece.name !== QUEEN)
        return;

    const availableCages = []
    availableCages.push(...rockAvailableCagesDetect(pieces, {...piece, name: ROOK}))
    availableCages.push(...bishopAvailableCagesDetect(pieces, {...piece, name: BISHOP}))
    return availableCages
}