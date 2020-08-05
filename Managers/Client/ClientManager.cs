using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupService.Interfaces.Client;

namespace SupService.Managers.Client
{
    public class ClientManager: IClientManager
    {
        private readonly SupServiceContext _dbContext;

        public ClientManager(SupServiceContext context)
        {
            _dbContext = context;
        }
        
        public async Task<Models.Client.Client> Create(ICreate request)
        {
            var entity = new Models.Client.Client
            {
                Id = new Guid(),
                Name = request.Name,
                OrgID = request.OrgID
            };

            await _dbContext.Clients.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Models.Client.Client> Update(IUpdate request)
        {
            var entity = await _dbContext.Clients.FindAsync(request.Id);
            entity.Name = request.Name;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Models.Client.Client>> Get()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<Models.Client.Client> Get(Guid id)
        {
            return await _dbContext.Clients.FindAsync(id);
        }

        public async Task<IEnumerable<Models.Project.Project>> GetProjects(Guid clientId)
        {
            return await _dbContext.Projects.Where(project => project.ClientID == clientId).ToListAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _dbContext.Clients.FindAsync(id);
            _dbContext.Clients.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Models.Client.Client>> Search(string word)
        {
            return await (from client in _dbContext.Clients
                where client.Id.ToString().Contains(word)
                      || client.Name.Contains(word)
                      || word.Contains(client.OrgID.ToString())
                select client).ToListAsync();
        }
    }
}