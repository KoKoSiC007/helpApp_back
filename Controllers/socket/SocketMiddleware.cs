using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SupService.Controllers.socket.Handler;

namespace SupService.Controllers.socket
{
    public class SocketMiddleware
    {
        private readonly RequestDelegate _next;
        private WebSocketHandler WebSocketHandler { get; set; }

        public SocketMiddleware(RequestDelegate next,
            WebSocketHandler webSocketHandler)
        {
            _next = next;
            WebSocketHandler = webSocketHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            if(!context.WebSockets.IsWebSocketRequest)
                return;

            var socket = await context.WebSockets.AcceptWebSocketAsync();
            await WebSocketHandler.OnConnected(socket);

            await Receive(socket, async(result, buffer) =>
            {
                if(result.MessageType == WebSocketMessageType.Text)
                {
                    await WebSocketHandler.ReceiveAsync(socket, result, buffer);
                }
                else if(result.MessageType == WebSocketMessageType.Close)
                {
                    await WebSocketHandler.OnDisconnected(socket);
                }

            });
        }
        private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            var buffer = new byte[1024 * 4];

            while(socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                    cancellationToken: CancellationToken.None);

                handleMessage(result, buffer);
            }
        }
    }
    
}