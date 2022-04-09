using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkersWages.API.Storage;

namespace WorkersWages.API.API.Files
{
    /// <summary>
    /// Работа с файлами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _appEnvironment;

        public FilesController(DataContext dataContext, IWebHostEnvironment appEnvironment)
        {
            _dataContext = dataContext;
            _appEnvironment = appEnvironment;
        }

        /// <summary>
        /// Загружает новый файл.
        /// </summary>
        /// <param name="formFile">Файл для загрузки.</param>
        [HttpPost]
        public async Task<ActionResult<int>> Upload([Required] IFormFile formFile)
        {
            Storage.Models.File file = null;
            try
            {
                var extension = Path.GetExtension(formFile.FileName);
                var path = Path.Combine("Files", Guid.NewGuid() + extension);
                using (var fileStream = new FileStream(Path.Combine(_appEnvironment.ContentRootPath, path), FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }

                var now = DateTimeOffset.Now;
                file = new Storage.Models.File 
                { 
                    Name = formFile.FileName, 
                    Url = path,
                    MimeType = formFile.ContentType,
                    Created = now,
                    Updated = now
                };
                _dataContext.Files.Add(file);
                _dataContext.SaveChanges();
            }
            catch (FileLoadException ex)
            {
                ModelState.AddModelError("File", ex.Message);
            }

            return Ok(file.Id);
        }

        /// <summary>
        /// Скачивает файл.
        /// </summary>
        /// <param name="id">ИД файла.</param>
        /// <returns>Файл.</returns>
        [HttpGet("{id}")]
        public IActionResult Download([Required][FromRoute] int id)
        {
            var file = _dataContext.Files.FirstOrDefault(i => i.Id == id);
            if (file == default)
                return NotFound($"Файла с ИД \"{id}\" не существует.");

            try
            {
                string path = Path.Combine(_appEnvironment.ContentRootPath, file.Url);
                var fs = new FileStream(path, FileMode.Open);
                return File(fs, file.MimeType, file.Name);
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
