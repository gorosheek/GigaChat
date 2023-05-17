import {HubConnectionBuilder, LogLevel} from '@microsoft/signalr';
import {HubConnection} from '@microsoft/signalr/dist/esm/HubConnection';

export function buildConnection(): HubConnection {
    return new HubConnectionBuilder()
        .withUrl("http://localhost:5100/chat")
        .withAutomaticReconnect()
        .configureLogging(LogLevel.Information)
        .build();
}
export async function startConnection(connection: HubConnection): Promise<void> {
    try {
        await connection.start();
        console.log('Connected!');
    } catch (e) {
        console.log('Connection failed: ', e)
    }
}