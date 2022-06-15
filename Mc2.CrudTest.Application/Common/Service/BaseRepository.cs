using Mc2.CrudTest.Application.Common.Interfaces.DbContext;
using Mc2.CrudTest.Application.Common.Interfaces.Repository;
using Mc2.CrudTest.Domain.Common;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Application.Common.Service
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly IApplicationDbContext _dbContext;

        public BaseRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddToTabase(T entity)
        {
            var resultOfAdd = await _dbContext.SetDbContext<T>().AddAsync(entity);
            _dbContext.SaveChanges();
            return resultOfAdd.Entity.Id;
        }


        public bool DateOfBirthIsExist(string userDateOfBirth)
        {
            var queryResult = _dbContext.Customers.Where(a => a.DateOfBirth.Equals(userDateOfBirth)).AsNoTracking().ToList();
            if (queryResult.Count is 0)
                return true;
            else
                return false;
        }

        public bool EmailIsExist(string userEmail)
        {
            var queryResult = _dbContext.Customers.Where(a => a.Email.Equals(userEmail)).AsNoTracking().ToList();
            if (queryResult.Count is 0)
                return true;
            else
                return false;
        }

        public T FindById(Guid id)
            => _dbContext.SetDbContext<T>().Find(id);

        public T Update(T entity)
        {
            _dbContext.Entry<T>(entity);
            _dbContext.SaveChanges();
            return entity;

        }

        public bool LastNameIsExist(string userLastName)
        {
            var queryResult = _dbContext.Customers.Where(a => a.Lastname.Equals(userLastName)).AsNoTracking().ToList();
            if (queryResult.Count is 0)
                return true;
            else
                return false;
        }

        public bool UserFirstNameIsExist(string userFirstName)
        {
            var queryResult = _dbContext.Customers.Where(a => a.Firstname.Equals(userFirstName)).AsNoTracking().ToList();
            if (queryResult.Count is 0)
                return true;
            else
                return false;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.SetDbContext<T>().Find(id);
            _dbContext.SetDbContext<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<T> GetAll()
           => _dbContext.SetDbContext<T>().ToList();
    }
}
