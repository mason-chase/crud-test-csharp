using Mc2.CrudTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Common.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        bool EmailIsExist(string userEmail);
        bool UserFirstNameIsExist(string userFirstName);
        bool LastNameIsExist(string userLastName);
        bool DateOfBirthIsExist(string userDateOfBirth);
        Task<Guid> AddToTabase(T entity);
        T FindById(Guid id);
        T Update(T entity);
        void Delete(Guid id);
        List<T> GetAll();
    }
}
