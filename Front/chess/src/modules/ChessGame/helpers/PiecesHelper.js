export class PiecesHelper{
    static pieceExist(pieces, position){
        return !!this.getPiece(pieces, position)
    }

    static getPiece(pieces, position){
        return pieces.find(p => p.validPosition.posX === position.posX && p.validPosition.posY === position.posY)
    }

    static canBeSetedToPosition(pieces, position, pieceColor){
        if(position.posX > 8 || position.posY > 8 || position.posX < 1 || position.posY < 1)
            return {canBeSetted: false}

        const pieceInCage = this.getPiece(pieces, position)
        if(pieceInCage){
            if(pieceInCage.color === pieceColor)
                return {canBeSetted: false}

            return {canBeSetted: true, isEnemyOnCage: true}
        }

        return {canBeSetted: true, isEnemyOnCage: false}
    }

    static getPiecesWithMovedPiece(pieces, piece, toPos){
        const resultPieces = JSON.parse(JSON.stringify(pieces))
            .filter(p => !this.positionsIsEquals(p.validPosition, piece.validPosition) &&
                         !this.positionsIsEquals(p.validPosition, toPos))
        
        resultPieces.push({...JSON.parse(JSON.stringify(piece)), validPosition: toPos})
        return resultPieces
    }

    static positionsIsEquals(pos1, pos2){
        return pos1.posX === pos2.posX &&
               pos1.posY === pos2.posY
    }
}