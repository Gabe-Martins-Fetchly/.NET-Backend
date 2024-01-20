using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lecture.Models;
using Lecture.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lectures.Services;

namespace Lecture.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public SpeakersController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }


        // GET: Speakers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Speakers.ToListAsync());
        }

        // GET: Speakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Speakers = await _context.Speakers
                .FirstOrDefaultAsync(m => m.Id == id);

            var SpeakersViewModel = new SpeakersViewModel()
            {
                Id = Speakers.Id,
                Name = Speakers.Name,
                Qualification = Speakers.Qualification,
                Experience = Speakers.Experience,
                DateLecture = Speakers.DateLecture,
                TimeLecture = Speakers.TimeLecture,
                Local = Speakers.Local,
                ImagemExistente = Speakers.Picture
            };

            if (Speakers == null)
            {
                return NotFound();
            }

            return View(Speakers);
        }

        // GET: Speakers/Create
        public IActionResult Create()
        {
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpeakersViewModel model)
        {
            var speakersService = new SpeakersService(_context);

            model.Picture= ProcessaUploadedFile(model);

            if (await speakersService.CreateSpeakerAsync(model))
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public string ProcessaUploadedFile(SpeakersViewModel model)
        {
            string nomeArquivoImagem = null;

            if (model.SpeakersFoto != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                nomeArquivoImagem = Guid.NewGuid().ToString() + "_" + model.SpeakersFoto.FileName;
                string filePath = Path.Combine(uploadsFolder, nomeArquivoImagem);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.SpeakersFoto.CopyTo(fileStream);
                }
            }
            return nomeArquivoImagem;
        }

        // GET: Speakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Speakers = await _context.Speakers.FindAsync(id);

            var SpeakersViewModel = new SpeakersViewModel()
            {
                Id = Speakers.Id,
                Name = Speakers.Name,
                Qualification = Speakers.Qualification,
                Experience = Speakers.Experience,
                DateLecture = Speakers.DateLecture,
                TimeLecture = Speakers.TimeLecture,
                Local = Speakers.Local,
                ImagemExistente = Speakers.Picture
            };

            if (Speakers == null)
            {
                return NotFound();
            }
            return View(SpeakersViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpeakersViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Speakers = await _context.Speakers.FindAsync(model.Id);

                    Speakers.Name = model.Name;
                    Speakers.Qualification = model.Qualification;
                    Speakers.Experience = model.Experience;
                    Speakers.DateLecture = model.DateLecture;
                    Speakers.TimeLecture = model.TimeLecture;
                    Speakers.Local = model.Local;

                    if (model.SpeakersFoto != null)
                    {
                        if (model.ImagemExistente != null)
                        {
                            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Uploads", model.ImagemExistente);
                            System.IO.File.Delete(filePath);
                        }

                        Speakers.Picture = ProcessaUploadedFile(model);
                    }

                    _context.Update(Speakers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Speakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Speakers = await _context.Speakers
                .FirstOrDefaultAsync(m => m.Id == id);

            var SpeakersViewModel = new SpeakersViewModel()
            {
                Id = Speakers.Id,
                Name = Speakers.Name,
                Qualification = Speakers.Qualification,
                Experience = Speakers.Experience,
                DateLecture = Speakers.DateLecture,
                TimeLecture = Speakers.TimeLecture,
                Local = Speakers.Local,
                ImagemExistente = Speakers.Picture
            };

            if (Speakers == null)
            {
                return NotFound();
            }

            return View(SpeakersViewModel);
        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var Speakers = await _context.Speakers.FindAsync(id);

            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", Speakers.Picture);
            
            _context.Speakers.Remove(Speakers);

            if (await _context.SaveChangesAsync() > 0)
            {
                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        private bool SpeakersExists(int id)
        {
            return _context.Speakers.Any(e => e.Id == id);
        }
    }
}
