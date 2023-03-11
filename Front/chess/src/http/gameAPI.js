import { HttpTransportType, HubConnectionBuilder } from "@microsoft/signalr"

let hubConnection;
let onMoveByApponent;

export const joinToGameHub = async (onOpponentMove, gameInfoSetter, gameId) => {
    hubConnection = new HubConnectionBuilder()
        .withUrl(process.env.REACT_APP_API_URL + "game", {
            skipNegotiation: true,
            transport: HttpTransportType.WebSockets,
            accessTokenFactory: () => localStorage.getItem("token")
        })
        .build()
    
    hubConnection.on("movePiece", (pieces) => {
        onMoveByApponent(pieces)
    })

    hubConnection.on("setGame", gameInfoSetter)
    await hubConnection.start()
    await hubConnection.invoke("JoinToGame", gameId)
} 

export const movePiece = async (gameId, from, to) => {
    await hubConnection.invoke('MovePiece', {gameId: gameId, from: from, to: to})
}

export const setOnMoveByApponent = (func) => {
    onMoveByApponent = func
} 

export const leftGameHub = () => console.log(hubConnection)