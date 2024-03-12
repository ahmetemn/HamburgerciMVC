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

        public async Task<List<MenuGetAllVM>> GetAllActiveMenu()
        {

            var menu = await _menuHamburgerREPO.GetFilteredListAsync(select: x => new MenuGetAllVM() { ID = x.Id, Name = x.MenuAdi,ImagePath=x.ImagePath ,Status = x.Status },

                    where: x => x.Status != Status.Deleted, orderBy: x => x.OrderBy(x => x.MenuAdi));

            return menu; 


        }

        public async Task<List<MenuGetAllVM>> GetAllMenu()
        {


            var menu = await _menuHamburgerREPO.GetFilteredListAsync(select: x => new MenuGetAllVM()
            {

                ID = x.Id,
                Name = x.MenuAdi,
                ImagePath = x.ImagePath, 
                MenuFiyat = x.MenuFiyat,    
                Status = x.Status
            }, orderBy: x => x.OrderBy(x => x.MenuAdi));
            return menu; 
        }
         

        public async Task<MenuUpdateVM> GetMenu(int id)
        {
           
            var menu = await _menuHamburgerREPO.GetByIdAsync(id);
            return new MenuUpdateVM()
            {
                MenuAdi = menu.MenuAdi,
                
                MenuFiyat =menu.MenuFiyat  ,
             
            };
        }

        public int Update(MenuUpdateVM model)
        {

            var menu = new Menu()
            {
                MenuAdi=model.MenuAdi,
                MenuFiyat=model.MenuFiyat,
               
            };

            menu.Status = Status.Updated;
            menu.UpdatedDate = DateTime.Now; 
            return _menuHamburgerREPO.Update(menu); 
        }

        public async Task<int> UpdateStatus(int id)
        {
            var menu = await _menuHamburgerREPO.GetByIdAsync(id); 
            if(menu.Status==Status.Added)
            {
                menu.Status = Status.Deleted;
            }
            else
            {
                menu.Status = Status.Added; 
            }
            return _menuHamburgerREPO.Update(menu); 

        }
    }
}
