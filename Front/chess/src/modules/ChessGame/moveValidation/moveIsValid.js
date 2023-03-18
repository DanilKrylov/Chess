import { isCheckAfterMove } from "./isCheckAfterMove"
import { isMoveValidOnEmptyBoard } from "./isMoveValidOnEmptyBoard"
import { moveInAvailbaleCages } from "./moveInAvailableCages"

export const moveIsValid = (pieces, piece, moveTo, playerRole, moveColor) => {
    return isMoveValidOnEmptyBoard(pieces, piece.validPosition, moveTo, playerRole, moveColor) &&
           moveInAvailbaleCages(pieces, piece, moveTo) &&
           !isCheckAfterMove(pieces, piece, moveTo)
}