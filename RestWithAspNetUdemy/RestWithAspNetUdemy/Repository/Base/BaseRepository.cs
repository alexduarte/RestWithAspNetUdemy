using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestWithAspNetUdemy.Infra.Context;
using RestWithAspNetUdemy.Model.Base;
using RestWithAspNetUdemy.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Repository.Base
{
    public  class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly SQLContext _context;
        public readonly ILogger<T> _logger;
        private DbSet<T> _dbSet;

        public BaseRepository(SQLContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T item, CancellationToken cancellationToken)
        {
            try
            {
                var itemCreated = await _dbSet.AddAsync(item, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return itemCreated.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating {nameof(T)}: {ex}");
                return null;
            }
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (!Exists(id)) return false;
            var item = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            _dbSet.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
       
        public async Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken) =>
             await _dbSet.ToListAsync(cancellationToken);

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _dbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<T> UpdateAsync(T item, CancellationToken cancellationToken)
        {
            try
            {
                if (!Exists(item.Id)) return null;
                var itemToUpdate = await _context.Persons.FirstOrDefaultAsync(x => x.Id == item.Id);
                _context.Entry(itemToUpdate).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync(cancellationToken);
                return item;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating {nameof(T)}: {ex}");
                return null;
            }
        }

        public bool Exists(Guid id) => _dbSet.Any(x => x.Id == id);        
    }
}
