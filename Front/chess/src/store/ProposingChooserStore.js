import {makeAutoObservable} from 'mobx'

export class ProposingChooserStore{
    constructor(onSelectPiece, isInPieceMenu, pawnPos){
        this._onSelectPiece = onSelectPiece
        this._isInPieceMenu = isInPieceMenu
        this._pawnPos = pawnPos
        makeAutoObservable(this)
    }

    clear(){
        this.setIsInPieceMenu(null)
        this.setOnSelectPiece(null)
        this.setPawnPos(null)
    }

    setOnSelectPiece(onSelectPiece){
        this._onSelectPiece = onSelectPiece
    }

    setPawnPos(pawnPos){
        this._pawnPos = pawnPos
    }

    setIsInPieceMenu(isInPieceMenu){
        this._isInPieceMenu = isInPieceMenu
    }

    get onSelectPiece(){
        return this._onSelectPiece 
    }

    get pawnPos(){
        return this._pawnPos || {}
    }

    get isInPieceMenu(){
        return this._isInPieceMenu
    }
} 