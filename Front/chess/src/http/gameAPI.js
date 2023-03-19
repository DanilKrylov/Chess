import { HttpTransportType, HubConnectionBuilder } from "@microsoft/signalr"
import { $host } from ".";
import { LONG_CASTLING, SHORT_CASTLING } from "../utils/castlingDirections";

let hubConnection;

export const joinToGameHub = async (gameInfoSet, finishGame, gameId, onGameIsNotDefined) => {
    hubConnection = new HubConnectionBuilder()
        .withUrl(process.env.REACT_APP_API_URL + "game", {
            skipNegotiation: true,
            transport: HttpTransportType.WebSockets,
            accessTokenFactory: () => localStorage.getItem("token")
        })
        .build()
    
    hubConnection.on("movePiece", gameInfoSet)
    hubConnection.on("setGame", gameInfoSet)
    hubConnection.on('finishGame', (result) => finishGame(result))

    await hubConnection.start()
    try{
        await hubConnection.invoke("JoinToGame", gameId)
    }
    catch{
        onGameIsNotDefined()
    }
} 

export const movePiece = async (gameId, from, to) => {
    await hubConnection.invoke('MovePiece', {gameId: gameId, from: from, to: to})
}

export const doCastling = async (gameId, king, to) => {
    let castlingDirection = king.validPosition.posX > to.posX ? LONG_CASTLING : SHORT_CASTLING
    await hubConnection.invoke('Castling', {gameId: gameId, kingCastlingColor: king.color, castlingDirection: castlingDirection})
}

export const doPawnPromotion = async (gameId, from, to, pieceName) => {
    await hubConnection.invoke('PawnPromotion', {gameId: gameId, from: from, to: to, promotionToPiece: pieceName})
}

export const detectCheckmate = async (gameId) => {
    await hubConnection.invoke('DetectCheckMate', gameId)
}

export const leftGameHub = () => hubConnection.stop()

export const getGameInfo = async (gameId) => {
    return (await $host.get('api/gamestore/gameInfo/' + gameId)).data
}