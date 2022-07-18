using Mc2.CrudTest.Presentation.Front.ViewModels;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Front.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetALL();
        Task Create(CustomerViewModel customer);
        Task Update(CustomerViewModel customer);
        Task Delete(int id);



    }
}
