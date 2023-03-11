import {makeAutoObservable} from 'mobx'


export class CurrentGameStore{
    constructor(pieces, moveTurn, playerRole){
        this._playerRole = playerRole
        this._pieces = pieces
        this._moveTurn = moveTurn
        makeAutoObservable(this)
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

    get playerRole(){
        return this._playerRole
    }

    get moveTurn(){
        return this._moveTurn
    }

    get pieces(){
        return this._pieces
    }
}