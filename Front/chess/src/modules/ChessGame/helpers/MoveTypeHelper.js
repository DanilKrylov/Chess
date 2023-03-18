import { CASTLING_MOVE, DEFAULT_MOVE } from "../../../utils/moveTypes";
import { KING } from "../../../utils/pieceNames";

export class MoveTypeHelper{
    static getMoveType(piece, to){
        if(piece.name === KING && isMovedToCastlingPos(piece, to))
            return CASTLING_MOVE

        return DEFAULT_MOVE
    }
}

function isMovedToCastlingPos(piece, to){
    const {posX, posY} = piece.validPosition; 
    return to.posY === posY && (to.posX === posX - 2 || to.posX === posX + 2)
}