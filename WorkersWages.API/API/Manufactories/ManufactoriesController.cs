using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkersWages.API.Exceptions;
using WorkersWages.API.Storage;
using WorkersWages.API.Storage.Models;

namespace WorkersWages.API.API.Manufactories
{
    /// <summary>
    /// Работа с цехами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManufactoriesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ManufactoriesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Получение списка цехов.
        /// </summary>
        /// <param name="request">Запрос на получение списка цехов.</param>
        /// <returns>Список цехов.</returns>
        [HttpGet]
        public ManufactoryListResponse List([Required][FromQuery] ManufactoryListRequest request)
        {
            var list = _dataContext.Manufactories.Select(i => new ManufactoryInfo
            {
                Id = i.Id,
                Name = i.Name,
                Number = i.Number,
                Created = i.Created,
                Updated = i.Updated
            });

            if (!string.IsNullOrEmpty(request.Name))
                list = list.Where(i => i.Name.Contains(request.Name));
            if (!string.IsNullOrEmpty(request.Number))
                list = list.Where(i => i.Number.Contains(request.Number));

            var totalCount = list.Count();

            list = list.OrderBy(i => i.Name).Skip(request.Offset).Take(request.Limit);

            return new ManufactoryListResponse
            {
                Manufactories = list.ToArray(),
                TotalCount = totalCount
            };
        }

        /// <summary>
        /// Подробности о цехе.
        /// </summary>
        /// <param name="id">ИД цеха.</param>
        /// <returns>Подробности о цехе.</returns>
        [HttpGet("{id}")]
        public ActionResult<ManufactoryDetailsResponse> Details([Required][FromRoute] int id)
        {
            var manufactory = _dataContext.Manufactories.FirstOrDefault(i => i.Id == id);
            if (manufactory == default)
                return NotFound($"Цех с ИД \"{id}\" не существует.");

            return new ManufactoryDetailsResponse
            {
                Name = manufactory.Name,
                Number = manufactory.Number,
                HeadFIO = manufactory.HeadFIO,
                HeadPhotoUrl = manufactory.HeadPhotoId.HasValue ? $"{Request.Scheme}://{Request.Host}/api/Files/{manufactory.HeadPhotoId}" : null
            };
        }

        /// <summary>
        /// Создание нового цеха.
        /// </summary>
        /// <param name="request">Запрос на создание нового цеха.</param>
        /// <returns>ИД созданого цеха.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([Required][FromBody] ManufactoryCreateRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException();

            if (_dataContext.Manufactories.Any(i => i.Number == request.Number))
                throw new ApiException("Цех с таким номером уже существует.", "Number");

            var now = DateTimeOffset.Now;
            var manufactory = new Manufactory
            {
                Name = request.Name,
                Number = request.Number,
                HeadFIO = request.HeadFIO,
                HeadPhotoId = request.HeadPhotoId,
                Created = now,
                Updated = now
            };

            await _dataContext.Manufactories.AddAsync(manufactory);
            await _dataContext.SaveChangesAsync();

            return Ok(manufactory.Id);
        }

        /// <summary>
        /// Редактирование цеха.
        /// </summary>
        /// <param name="id">ИД цеха.</param>
        /// <param name="request">Запрос на редактирование цеха.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([Required][FromRoute] int id, [Required][FromBody] ManufactoryEditRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException();

            var manufactory = _dataContext.Manufactories.FirstOrDefault(i => i.Id == id);
            if (manufactory == default)
                return NotFound($"Цех с ИД \"{id}\" не существует.");

            if (_dataContext.Manufactories.Any(i => i.Id != id && i.Number == request.Number))
                throw new ApiException("Цех с таким номером уже существует.", "Number");

            manufactory.Name = request.Name;
            manufactory.Number = request.Number;
            manufactory.HeadFIO = request.HeadFIO;
            manufactory.HeadPhotoId = request.HeadPhotoId;
            manufactory.Updated = DateTimeOffset.Now;

            _dataContext.Manufactories.Update(manufactory);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Удаление цеха.
        /// </summary>
        /// <param name="id">ИД цеха.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required][FromRoute] int id)
        {
            var manufactory = _dataContext.Manufactories.FirstOrDefault(i => i.Id == id);

            if (manufactory == default)
                return NotFound($"Цех с ИД \"{id}\" не существует.");

            _dataContext.Manufactories.Remove(manufactory);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
