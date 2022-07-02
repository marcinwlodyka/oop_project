using OOP.domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EF.Services
{
    public class GenericDataService<T> : IDataService<T> where T : class
    {
        private readonly PizzeriaDBContextFactory _contextFactory;
        private readonly NonqueryDataService<T> _nonQueryDataService;

        public GenericDataService(PizzeriaDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonqueryDataService<T>(contextFactory);

        }


        public async Task<T> Create(T entity)
        {

            return await _nonQueryDataService.Create(entity);

        }

        public async Task<bool> Delete(T entity)
        {

            return await _nonQueryDataService.Delete(entity);

        }

        public async Task<T> Get(int id)
        {
            using PizzeriaDBContext context = _contextFactory.CreateDbContext();
            return await context.Set<T>().FindAsync(id);
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            using PizzeriaDBContext context = _contextFactory.CreateDbContext();
            return await context.Set<T>().ToListAsync();

        }

        public async Task<T> Update(T entity)
        {

            return await _nonQueryDataService.Update(entity);
        }
    }
}