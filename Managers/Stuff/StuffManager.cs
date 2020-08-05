using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupService.Interfaces.Stuff;

namespace SupService.Managers.Stuff
{
    public class StuffManager: IStuffManager
    {

        private readonly SupServiceContext _dbContext;

        public StuffManager(SupServiceContext context)
        {
            _dbContext = context;
        }
        public async Task<Models.Stuff.Stuff> Create(ICreate request)
        {
            var entity = new Models.Stuff.Stuff
            {
                Id = new Guid(),
                FName = request.FName,
                LName = request.LName,
                Phone = request.Phone,
                Email = request.Email,
                Password = request.Password
            };

            await _dbContext.Managers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Models.Stuff.Stuff> Update(IUpdate request)
        {
            var entity = await _dbContext.Managers.FindAsync(request.Id);
            entity.FName = request.FName;
            entity.LName = request.LName;
            entity.Phone = request.Phone;
            entity.Email = request.Email;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Models.Stuff.Stuff>> Get()
        {
            return await _dbContext.Managers.ToListAsync();
        }

        public async Task<Models.Stuff.Stuff> Get(Guid id)
        {
            return await _dbContext.Managers.FindAsync(id);
        }

        public async Task<Models.Stuff.Stuff> Get(string email, string password)
        {
            return await _dbContext.Managers
                .AsQueryable()
                .FirstOrDefaultAsync(obj =>
                    obj.Email == email && obj.Password == password
                );
        }

        public async Task Delete(Guid id)
        {
            var entity = await _dbContext.Managers.FindAsync(id);
            _dbContext.Managers.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}