using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace SupService.Managers.Connection
{
    public class ConnectionManager: IConnectionManager
    {
        private ConcurrentDictionary<Guid, WebSocket> _sockets = new ConcurrentDictionary<Guid, WebSocket>();
        
        public WebSocket GetSocketById(Guid id)
        {
            return _sockets.FirstOrDefault(pair => pair.Key == id).Value;
        }

        public ConcurrentDictionary<Guid, WebSocket> GetAll()
        {
            return _sockets;
        }

        public Guid GetId(WebSocket socket)
        {
            return _sockets.FirstOrDefault(pair => pair.Value == socket).Key;
        }

        public void AddSocket(WebSocket socket)
        {
            _sockets.TryAdd(CreateConnectionId(), socket);
        }

        public async Task RemoveSocket(Guid id)
        {
            WebSocket socket;
            _sockets.TryRemove(id, out socket);
            if (socket != null)
                await socket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
                    statusDescription: "Closed by the ConnectionManager",
                    cancellationToken: CancellationToken.None);
        }

        public Guid CreateConnectionId()
        {
            return Guid.NewGuid();
        }
    }
}