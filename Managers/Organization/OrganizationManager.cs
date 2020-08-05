using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupService.Interfaces.Organization;

namespace SupService.Managers.Organization
{
    public class OrganizationManager: IOrganizationManager
    {
        private readonly SupServiceContext _dbContext;

        public OrganizationManager(SupServiceContext context)
        {
            _dbContext = context;
        }
        public async Task<Models.Organization.Organization> Create(ICreate request)
        {
            var entity = new Models.Organization.Organization
            {
                Id = new Guid(),
                Name = request.Name
            };

            await _dbContext.Organizations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Models.Organization.Organization> Update(IUpdate request)
        {
            var entity =  await _dbContext.Organizations.FindAsync(request.Id);
            entity.Name = request.Name;
            await _dbContext.SaveChangesAsync();;
            return entity;
        }

        public async Task<IEnumerable<Models.Organization.Organization>> Get()
        {
            return await _dbContext.Organizations.ToListAsync();
        }

        public async Task<Models.Organization.Organization> Get(Guid id)
        {
            return await _dbContext.Organizations.FindAsync(id);
        }

        public async Task<IEnumerable<Models.Client.Client>> GetClients(Guid id)
        {
            return await _dbContext.Clients.Where(client => client.OrgID == id).ToListAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _dbContext.Organizations.FindAsync(id);
            _dbContext.Organizations.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Organization.Organization>> Search(string word)
        {
            return await (from org in _dbContext.Organizations
                where org.Id.ToString().Contains(word) || org.Name.Contains(word)
                select org).ToListAsync();;
        }
    }
}