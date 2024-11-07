using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeCore.Models;
using System.Collections.Generic;

namespace ProjeCore.Controllers
{
    public class PersonelimController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {

            var degerler = c.Personels.Include(x=>x.Birim).ToList();
            return View(degerler);
        }

        [HttpGet]//bu fonksiyon sadece sayfa ilk yüklediği zaman çalışacak
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler=(from x in c.Birims.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.BirimAd,//bu kullanıcın dropdownlistte gördüğü kısım
                                             Value=x.BirimID.ToString()//bu arkada dönen işlem
                                         } ).ToList();//en sona koyduğum tolst bana bu ifadeyi liste olarak gönder demek
           
            ViewBag.dgr= degerler;
            
            return View();



            //buradaki seleectlistitemle bizim seçmiş old değerin textini birimaddan valuesinide birim id den almış olacak
        }
        public IActionResult YeniPersonel(Personel p)
        {
            var per =c.Birims.Where(x=>x.BirimID==p.Birim.BirimID).FirstOrDefault();
            p.Birim = per;
            //yukarıdaki 2 satırla dropdowndan gelecek olan veriyi getirdim
            c.Personels.Add(p); //daha sonra bunu parametrenin içerisine dahil ettim
            c.SaveChanges();
            return RedirectToAction("Index");
        }


		public IActionResult PersonelSil(int id)
           //burası için view eklmeye gerek yok yani silme işleminde sonra seni neden bir yereatasınki ztn sayfa olarak
		{
			var dep = c.Personels.Find(id); // Gönderilen id'ye göre kaydı bul


			c.Personels.Remove(dep); // Eğer kayıt bulunduysa, silme işlemini yap
			c.SaveChanges();
			return RedirectToAction("Index"); // Index sayfasına yönlendir
		}


		public IActionResult PersonelGetir(int id)
		{
			var dan= c.Personels.Find(id);
			return View("PersonelGetir", dan);//bak yukarıdaki tanımlaya göre beni başka bir sayfaya atmıyor
											  //ztn öyle bir sayfa oluşturmadım ama bu yeni bir sayfa yaptı ve oluşturdu

		}


		public IActionResult PersonelGuncelle(Personel d)
		{
			//şimdi bu dep id,ad ,özellikler vb tüm değerleri tutuyor yukaeıdaki paramerdeki d
			//o kutucaktaki benim gönderdiğim değeri tutuyor
			var dep = c.Personels.Find(d.BirimID);
            dep.Ad = d.Ad;
            //burada yeni verdiğim değerin yeni d nin değerini eskiye yani dep e ataadım


			c.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
