using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace SupService.Managers.Connection
{
    public interface IConnectionManager
    {
        WebSocket GetSocketById(Guid id);
        ConcurrentDictionary<Guid, WebSocket> GetAll();
        Guid GetId(WebSocket socket);
        void AddSocket(WebSocket socket);
        Task RemoveSocket(Guid id);
        Guid CreateConnectionId();
    }
}