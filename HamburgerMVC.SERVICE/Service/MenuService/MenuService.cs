using HamburgerciMVC.DATA.Concrate;
using HamburgerciMVC.DATA.Enums;
using HamburgerciMVC.REPO.Abstract;
using HamburgerciMVC.REPO.ConcrateREPO;
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
		private readonly IIceceklerREPO _icecekRepo;

		public MenuService(IMenuHamburgerREPO menuHamburgerREPO, IIceceklerREPO ıceceklerREPO)
		{
			this._menuHamburgerREPO = menuHamburgerREPO;
			this._icecekRepo = ıceceklerREPO;


		}
		public int Create(MenuCreateDTO model)
		{
			var menu = new Menu
			{
				MenuAdi = model.MenuAdi,
				MenuFiyat = model.MenuFiyat,
				ImagePath = model.ImagePath,
			};
			return _menuHamburgerREPO.Create(menu);
		}

		public async Task<int> Delete(int id)
		{
			var menu = await _menuHamburgerREPO.GetByIdAsync(id);

			menu.Status = Status.Deleted;

			menu.DeletedDate = DateTime.Now;

			return _menuHamburgerREPO.Delete(menu);
		}

		public async Task<List<MenuGetAllVM>> GetAllActiveMenu()
		{

			var menu = await _menuHamburgerREPO.GetFilteredListAsync(select: x => new MenuGetAllVM() { ID = x.Id, Name = x.MenuAdi, ImagePath = x.ImagePath, Status = x.Status },

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
				//Description=x.Description,
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
				ID = menu.Id,
				Name = menu.MenuAdi,

				MenuFiyati = menu.MenuFiyat,

				ImagePath = menu.ImagePath,
			};
		}

		public int Update(MenuUpdateVM model)
		{

			var menu = new Menu()
			{
				Id = model.ID,
				MenuAdi = model.Name,
				MenuFiyat = model.MenuFiyati,
				ImagePath = model.ImagePath,

			};

			menu.Status = Status.Updated;
			menu.UpdatedDate = DateTime.Now;
			return _menuHamburgerREPO.Update(menu);
		}

		public async Task<int> UpdateStatus(int id)
		{
			var menu = await _menuHamburgerREPO.GetByIdAsync(id);
			if (menu.Status == Status.Added)
			{
				menu.Status = Status.Deleted;
			}
			else
			{
				menu.Status = Status.Added;
			}
			return _menuHamburgerREPO.Update(menu);

		}





		

		async Task<List<IcecekListeVM>> IMenuService.İcecekMenuList()
		{
			var icecekListesi = await _icecekRepo.GetFilteredListAsync(select: icecek => new IcecekListeVM()
			{
				Id = icecek.Id,
				Name = icecek.IcecekAdi,
				Fiyat = icecek.Fiyat,
                ImagePath = icecek.ImagePath

			}, orderBy: x => x.OrderBy(x => x.IcecekAdi));
			return icecekListesi;
		}
	}
}
