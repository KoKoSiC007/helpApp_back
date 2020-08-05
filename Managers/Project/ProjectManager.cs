using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupService.Interfaces.Project;

namespace SupService.Managers.Project
{
    public class ProjectManager: IProjectManager
    {
        private readonly SupServiceContext _dbContext;
        public ProjectManager(SupServiceContext context)
        {
            _dbContext = context;
        }
        public async Task<Models.Project.Project> Create(ICreate request)
        {
            var entity = new Models.Project.Project
            {
                Id = new Guid(),
                Name = request.Name,
                ClientID = request.ClientID
            };
            await _dbContext.Projects.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Models.Project.Project> Update(IUpdate request)
        {
            var entity = await _dbContext.Projects.FindAsync(request.Id);
            entity.Name = request.Name;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Models.Project.Project>> Get()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Models.Project.Project> Get(Guid id)
        {
            return await _dbContext.Projects.FindAsync(id);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _dbContext.Projects.FindAsync(id);
            _dbContext.Projects.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Project.Project>> Search(string word)
        {
            var entity = _dbContext.Clients.Where(obj => obj.Name == word).ToList();
            return await (from project in _dbContext.Projects
                where project.Id.ToString().Contains(word)
                      || project.Name.Contains(word)
                      || word.Contains(project.ClientID.ToString())
                select project).ToListAsync();
        }
    }
}