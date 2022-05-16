using Project.BL.Repositories;
using Project.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using X.PagedList;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class SliderController : Controller
    {
        SqlRepo<Slider> repoSlider;
        public SliderController(SqlRepo<Slider> _repoSlider)
        {
            repoSlider = _repoSlider;
        }

        public IActionResult Index(int? page)
        {
            return View(repoSlider.GetAll().ToPagedList(page ?? 1, 10));
        }

        public IActionResult Create()
        {
            return View(new Slider());
        }

        [HttpPost]
        public IActionResult Create(Slider model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    string sliderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slider");
                    if (!Directory.Exists(sliderPath)) Directory.CreateDirectory(sliderPath);
                    using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slider", Request.Form.Files["Picture"].FileName), FileMode.Create))
                    {
                        Request.Form.Files["Picture"].CopyTo(stream);
                    }
                    model.Picture = "/img/slider/" + Request.Form.Files["Picture"].FileName;
                }

                repoSlider.Add(model);
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Update(int id)
        {
            return View(repoSlider.GetBy(x => x.ID == id));
        }

        [HttpPost]
        public IActionResult Update(Slider model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    string sliderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slider");
                    if (!Directory.Exists(sliderPath)) Directory.CreateDirectory(sliderPath);
                    using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slider", Request.Form.Files["Picture"].FileName), FileMode.Create))
                    {
                        Request.Form.Files["Picture"].CopyTo(stream);
                    }
                    model.Picture = "/img/slider/" + Request.Form.Files["Picture"].FileName;
                }
                repoSlider.Update(model);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repoSlider.Remove(repoSlider.GetBy(x => x.ID == id));
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}
