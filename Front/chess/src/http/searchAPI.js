import { HubConnectionBuilder, HttpTransportType } from '@microsoft/signalr'

let hubConnection


export const startSearch = async (onSearchFinish) => {
    if(hubConnection){
        hubConnection.stop()
    }

    hubConnection = new HubConnectionBuilder()
        .withUrl(process.env.REACT_APP_API_URL + 'gameSearch', {
            skipNegotiation: true,
            transport: HttpTransportType.WebSockets,
            accessTokenFactory: () => localStorage.getItem("token")
        })
        .build()

    hubConnection.on('searchFinish', onSearchFinish)
    await hubConnection.start()
    hubConnection.invoke('StartSearch')
}

export const finishSearch = async () => {
    hubConnection.stop()
    hubConnection = null;
}