using System;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using SupService.Managers.Connection;

namespace SupService.Controllers.socket.Handler
{
    public class WebSocketMessageHandler: WebSocketHandler
    {
        public WebSocketMessageHandler(IConnectionManager connectionManager) : base(connectionManager) {}

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);
            string socketId = WebSocketConnectionManager.GetId(socket).ToString();
            await SendMessageToAllAsync($"Socket: {socketId} is connected");
        }
        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            string socketId = WebSocketConnectionManager.GetId(socket).ToString();
            var message = $"Socket: {socketId} write: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";
            await SendMessageToAllAsync(message);
        }
    }
}