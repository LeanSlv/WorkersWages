using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkersWages.API.Exceptions;
using WorkersWages.API.Storage;
using WorkersWages.API.Storage.Models;

namespace WorkersWages.API.API.Professions
{
    /// <summary>
    /// Работа с профессиями.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProfessionsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Получение списка профессий.
        /// </summary>
        /// <param name="request">Запрос на список профессий.</param>
        /// <returns>Список профессий.</returns>
        [HttpGet]
        public ProfessionListResponse List([Required][FromQuery] ProfessionListRequest request)
        {
            var list = _dataContext.Professions.Select(i => new ProfessionInfo
            {
                Id = i.Id,
                Name = i.Name,
                Created = i.Created,
                Updated = i.Updated
            });

            if (!string.IsNullOrEmpty(request.Name))
                list.Where(i => i.Name.Contains(request.Name));

            var totalCount = list.Count();

            list = list.Skip(request.Offset).Take(request.Limit);

            return new ProfessionListResponse
            {
                Professions = list.ToArray(),
                TotalCount = totalCount
            };
        }

        /// <summary>
        /// Добавление новой профессии.
        /// </summary>
        /// <param name="request">Запрос на добавление новой професии.</param>
        /// <returns>ИД добавленной профессии.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([Required][FromBody] ProfessionCreateRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException();

            if (_dataContext.Professions.Any(i => i.Name == request.Name))
                throw new ApiException("Профессия с таким названием уже существует.");

            var now = DateTimeOffset.Now;
            var profession = new Profession
            {
                Name = request.Name,
                Created = now,
                Updated = now
            };

            await _dataContext.Professions.AddAsync(profession);
            await _dataContext.SaveChangesAsync();

            return Ok(profession.Id);
        }

        /// <summary>
        /// Редактирование профессии.
        /// </summary>
        /// <param name="id">ИД профессии.</param>
        /// <param name="request">Запрос на редактирование профессии.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([Required][FromRoute] int id, [Required][FromBody] ProfessionEditRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException();

            var profession = _dataContext.Professions.FirstOrDefault(i => i.Id == id);

            if (profession == default)
                return NotFound($"Профессия с ИД \"{id}\" не существует.");

            profession.Name = request.Name;
            profession.Updated = DateTimeOffset.Now;

            _dataContext.Professions.Update(profession);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Удаление профессии.
        /// </summary>
        /// <param name="id">ИД профессии.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required][FromRoute] int id)
        {
            var profession = _dataContext.Professions.FirstOrDefault(i => i.Id == id);

            if (profession == default)
                return NotFound($"Профессия с ИД \"{id}\" не существует.");

            _dataContext.Professions.Remove(profession);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
