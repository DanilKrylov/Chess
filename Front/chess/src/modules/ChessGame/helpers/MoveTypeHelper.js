import { BLACK, WHITE } from "../../../utils/colors";
import { CASTLING_MOVE, DEFAULT_MOVE, PAWN_PROMOTE_MOVE } from "../../../utils/moveTypes";
import { KING, PAWN } from "../../../utils/pieceNames";

export class MoveTypeHelper{
    static getMoveType(piece, to){
        const {posY} = piece.validPosition

        if(piece.name === KING && isMovedToCastlingPos(piece, to))
            return CASTLING_MOVE

        if(piece.name === PAWN && ((piece.color === WHITE && posY === 7) || (piece.color === BLACK && posY === 2)))
            return PAWN_PROMOTE_MOVE
        
        return DEFAULT_MOVE
    }
}

function isMovedToCastlingPos(piece, to){
    const {posX, posY} = piece.validPosition; 
    return to.posY === posY && (to.posX === posX - 2 || to.posX === posX + 2)
}