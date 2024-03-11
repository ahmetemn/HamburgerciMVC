using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerMVC.SERVICE.Service.SiparisService
{
    public  interface ISiparisService
    {
        int Create(CategoryCreateDTO model);
        int Update(CategoryGetAllVM model);

        Task<int> UpdateStatus(int id);
        Task<int> Delete(int id);

        Task<List<CategoryGetAllVM>> GetAllCategory();

        Task<List<CategoryGetAllVM>> GetAllCategoryActive();

        Task<CategoryGetAllVM> GetCategory(int id);
    }
}
