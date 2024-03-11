using HamburgerciMVC.DATA.Concrate;
using HamburgerciMVC.DATA.Enums;
using HamburgerciMVC.REPO.Abstract;
using HamburgerMVC.SERVICE.Models.Dtos;
using HamburgerMVC.SERVICE.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerMVC.SERVICE.Service.MenuService
{
    public class MenuService : IMenuService
    {

        private readonly IMenuHamburgerREPO _menuHamburgerREPO;

        public MenuService(IMenuHamburgerREPO menuHamburgerREPO)
        {
                this._menuHamburgerREPO=menuHamburgerREPO;  

        }
        public int Create(MenuCreateDTO model)
        {
            var menu = new Menu
            {
                MenuAdi = model.MenuAdi,
                MenuFiyat = model.MenuFiyat,
                ImagePath = model.ImagePath,
            };
            return  _menuHamburgerREPO.Create(menu);    
        }

        public async Task<int> Delete(int id)
        {
              var menu = await _menuHamburgerREPO.GetByIdAsync(id);
             
            menu.Status=Status.Deleted; 

            menu.DeletedDate= DateTime.Now; 

            return _menuHamburgerREPO.Delete(menu); 
        }

        public Task<List<MenuUpdateVM>> GetAllActiveMenu()
        {
            
        }

        public Task<List<MenuUpdateVM>> GetAllMenu()
        {
            throw new NotImplementedException();
        }

        public Task<MenuUpdateVM> GetMenu(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MenuUpdateVM model)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateStatus(int id)
        {
            throw new NotImplementedException();
        }

        int IMenuService.Update(MenuUpdateVM model)
        {
            throw new NotImplementedException();
        }
    }
}
