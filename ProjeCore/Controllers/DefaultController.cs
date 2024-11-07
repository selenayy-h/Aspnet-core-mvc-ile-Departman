using Microsoft.AspNetCore.Mvc;
using ProjeCore.Models;

namespace ProjeCore.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Birims.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniBirim()
        {

            return View();
        }

        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {

            c.Birims.Add(b);//departmanlars ın içine ekle d den gelen değeri
                                   //bu d nin geldiği yer:  @Html.TextBoxFor(x=>x.departmanad,new {@class="form-control"})

            c.SaveChanges();

            return RedirectToAction("Index");//beni index actionuna yönlendir

        }
        public IActionResult BirimSil(int id)
        {
            var dep = c.Birims.Find(id); // Gönderilen id'ye göre kaydı bul

            
            c.Birims.Remove(dep); // Eğer kayıt bulunduysa, silme işlemini yap
            c.SaveChanges();
            return RedirectToAction("Index"); // Index sayfasına yönlendir
        }


        public IActionResult BirimGetir(int id)
        {
            var depart = c.Birims.Find(id);
            return View("BirimGetir", depart);//bak yukarıdaki tanımlaya göre beni başka bir sayfaya atmıyor
                                                  //ztn öyle bir sayfa oluşturmadım ama bu yeni bir sayfa yaptı ve oluşturdu

        }


        public IActionResult BirimGuncelle(Birim d)
        {
            //şimdi bu dep id,ad ,özellikler vb tüm değerleri tutuyor yukaeıdaki paramerdeki d
            //o kutucaktaki benim gönderdiğim değeri tutuyor
            var dep = c.Birims.Find(d.BirimID);
            dep.BirimAd = d.BirimAd; //burada yeni verdiğim değerin yeni d nin değerini eskiye yani dep e ataadım


            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult BirimDetay(int id)
        {
            var degerler=c.Personels.Where(x=>x.BirimID==id).ToList();
            //birimıd si dışarıdan gönderilen id ye eşit olan olarak değiştirdik
           
            var brmad=c.Birims.Where(x => x.BirimID == id).Select(y=>y.BirimAd).FirstOrDefault();//firstoredfault sadece bir tame vriyi getiriyor
           
            ViewBag.brm=brmad;
            return View(degerler);
        }




    }

}

