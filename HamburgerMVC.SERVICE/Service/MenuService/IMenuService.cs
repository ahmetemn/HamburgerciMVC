using HamburgerMVC.SERVICE.Models.Dtos;
using HamburgerMVC.SERVICE.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerMVC.SERVICE.Service.MenuService
{
    public  interface IMenuService
    {

        int Create(MenuCreateDTO model);

        int Update(MenuUpdateVM model);


        Task<int> UpdateStatus(int id);

        Task<int> Delete(int id);

        Task<List<MenuGetAllVM>> GetAllMenu();

        Task<List<MenuGetAllVM>> GetAllActiveMenu();

        Task<MenuGetByIdVM> GetMenu(int id);
    }
}
