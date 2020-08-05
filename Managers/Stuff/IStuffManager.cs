using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupService.Interfaces.Stuff;

namespace SupService.Managers.Stuff
{
    public interface IStuffManager
    {
        
        Task<Models.Stuff.Stuff> Create(ICreate request);
        Task<Models.Stuff.Stuff> Update(IUpdate request);
        Task<IEnumerable<Models.Stuff.Stuff>> Get();
        Task<Models.Stuff.Stuff> Get(Guid id);
        Task<Models.Stuff.Stuff> Get(string email, string password);
        Task Delete(Guid id);
    }
}