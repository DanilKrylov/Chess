import { PiecesHelper } from "./PiecesHelper"

export class AvailableCagesHelper{
    static getAvailableCagesMovingWith(pieces, piece, vertDiffKoef, horDiffKoef){
        let posX = piece.validPosition.posX + horDiffKoef
        let posY = piece.validPosition.posY + vertDiffKoef
        const availableCages = []
        while(true){
            const checkedPos = {posX: posX, posY: posY}
            const canBeSetedToPositionResult = PiecesHelper.canBeSetedToPosition(pieces, checkedPos, piece.color)
            if(canBeSetedToPositionResult.canBeSetted)
                availableCages.push(checkedPos)

            if(!canBeSetedToPositionResult.canBeSetted || canBeSetedToPositionResult.isEnemyOnCage)
                return availableCages

            posX += horDiffKoef
            posY += vertDiffKoef
        }
    }
}