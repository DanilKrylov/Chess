import {makeAutoObservable} from 'mobx'


export class CurrentGameStore{
    constructor(pieces, moveTurn, playerRole, playerEmail, opponentEmail){
        this._playerRole = playerRole
        this._pieces = pieces
        this._moveTurn = moveTurn
        this._playerEmail = playerEmail
        this._opponentEmail = opponentEmail 
        this._isEnded = false;
        this.setWinnerPlayerEmail("") 
        makeAutoObservable(this)
    }

    clear(){
        this._playerRole = null
        this._pieces = null
        this._moveTurn = null
        this._playerEmail = null
        this._opponentEmail = null 
        this._isEnded = false;
        this._winnerPlayerEmail = "" 
    }

    setPieces(pieces){
        this._pieces = pieces
    }

    setMoveTurn(moveTurn){
        this._moveTurn = moveTurn
    }

    setPlayerRole(playerRole){
        this._playerRole = playerRole
    }

    setPlayerEmail(playerEmail){
        this._playerEmail = playerEmail
    }

    setOpponentEmail(opponentEmail){
        this._opponentEmail = opponentEmail
    }

    setIsEnded(isEnded){
        this._isEnded = isEnded
    }

    setWinnerPlayerEmail(winnerPlayerEmail){
        this._winnerPlayerEmail = winnerPlayerEmail
    }

    get isEnded(){
        return this._isEnded
    }

    get winnerPlayerEmail(){
        return this._winnerPlayerEmail
    }

    get playerRole(){
        return this._playerRole
    }

    get moveTurn(){
        return this._moveTurn
    }

    get pieces(){
        if(!this._pieces)
            return []
        return this._pieces
    }

    get playerEmail(){
        return this._playerEmail
    }

    get opponentEmail(){
        return this._opponentEmail
    }

    changeViewPosition(pieceIdentifier, position){
        try{
            this.getPiece(pieceIdentifier).position = position
        }
        catch{
        }
    }

    changeValidPosition(pieceIdentifier, position){
        this.getPiece(pieceIdentifier).validPosition = position
    }

    setViewPosAsValidPos(pieceIdentifier){
        const piece = this.getPiece(pieceIdentifier)
        piece.position = piece.validPosition
    }

    getPiece(pieceIdentifier){
        try{
            return this._pieces.find(p => p.pieceIdentifier === pieceIdentifier)
        }
        catch{
        }
    }
}