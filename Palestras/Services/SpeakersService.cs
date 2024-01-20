using Lecture.Controllers;
using Lecture.Models;
using Lecture.ViewModels;
using Lectures.Interface;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lectures.Services
{
    public class SpeakersService
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
 
        public SpeakersService(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public SpeakersService(AppDbContext context)
        {
            this.context = context;

        }

        public async Task<bool> CreateSpeakerAsync(SpeakersViewModel model)
        {
            if (model == null || !ModelStateIsValid(model))
            {
                return false;
            }

            var speakers = new Speakers()
            {
                Name = model.Name,
                Qualification = model.Qualification,
                Experience = model.Experience,
                DateLecture = model.DateLecture,
                TimeLecture = model.TimeLecture,
                Local = model.Local,
                Picture = model.Picture
            };

            context.Add(speakers);
            await context.SaveChangesAsync();

            return true;
        }

        private bool ModelStateIsValid(SpeakersViewModel model)
        {
            // Lógica de validação do ModelState, se necessário
            return true;
        }


        //private string ProcessaUploadedFile(SpeakersViewModel model)
        //{
        //    string nomeArquivoImagem = null;

        //    if (model.SpeakersFoto != null)
        //    {
        //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
        //        nomeArquivoImagem = Guid.NewGuid().ToString() + "_" + model.SpeakersFoto.FileName;
        //        string filePath = Path.Combine(uploadsFolder, nomeArquivoImagem);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.SpeakersFoto.CopyTo(fileStream);
        //        }
        //    }

        //    return nomeArquivoImagem;
        //}
    }

}
