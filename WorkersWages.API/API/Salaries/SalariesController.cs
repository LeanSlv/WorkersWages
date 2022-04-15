using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkersWages.API.Exceptions;
using WorkersWages.API.Storage;
using WorkersWages.API.Storage.Models;

namespace WorkersWages.API.API.Salaries
{
    /// <summary>
    /// Работа с окладами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalariesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SalariesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Получение списка окладов.
        /// </summary>
        /// <param name="request">Запрос на получение списка окладов.</param>
        /// <returns>Список окладов.</returns>
        [HttpGet]
        public SalaryListResponse List([Required][FromQuery] SalaryListRequest request)
        {
            var list = _dataContext.Salaries.AsQueryable();

            if (request.ProfessionId.HasValue)
                list = list.Where(i => i.ProfessionId == request.ProfessionId.Value);
            if (request.Rank.HasValue)
                list = list.Where(i => i.Rank == request.Rank.Value);

            var totalCount = list.Count();

            list = list.OrderBy(i => i.Profession.Name).Skip(request.Offset).Take(request.Limit);

            var salaries = list.Select(i => new SalaryInfo
            {
                Id = i.Id,
                ProfessionName = i.Profession.Name,
                Rank = i.Rank,
                Amount = i.Amount,
                Created = i.Created,
                Updated = i.Updated
            });

            return new SalaryListResponse
            {
                Salaries = salaries.ToArray(),
                TotalCount = totalCount
            };
        }

        /// <summary>
        /// Получение подробностей оклада.
        /// </summary>
        /// <param name="id">ИД оклада.</param>
        /// <returns> Подробности оклада.</returns>
        [HttpGet("{id}")]
        public ActionResult<SalaryDetailsResponse> Details([Required][FromRoute] int id)
        {
            var salary = _dataContext.Salaries.FirstOrDefault(i => i.Id == id);
            if(salary == default)
                return NotFound($"Оклад с ИД \"{id}\" не существует.");

            return new SalaryDetailsResponse
            {
                ProfessionId = salary.ProfessionId,
                Rank = salary.Rank,
                Amount = salary.Amount
            };
        }

        /// <summary>
        /// Добавление нового оклада.
        /// </summary>
        /// <param name="request">Запрос на добавление нового оклада.</param>
        /// <returns>ИД созданного оклада.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([Required][FromBody] SalaryCreateRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException();

            var now = DateTimeOffset.Now;
            var salary = new Salary
            {
                ProfessionId = request.ProfessionId,
                Rank = request.Rank,
                Amount = request.Amount,
                Created = now,
                Updated = now
            };

            await _dataContext.Salaries.AddAsync(salary);
            await _dataContext.SaveChangesAsync();

            return Ok(salary.Id);
        }

        /// <summary>
        /// Редактирование оклада.
        /// </summary>
        /// <param name="id">ИД оклада.</param>
        /// <param name="request">Запрос на редактирование оклада.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([Required][FromRoute] int id, [Required][FromBody] SalaryEditRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException();

            var salary = _dataContext.Salaries.FirstOrDefault(i => i.Id == id);
            if (salary == default)
                return NotFound($"Оклад с ИД \"{id}\" не существует.");

            salary.ProfessionId = request.ProfessionId;
            salary.Rank = request.Rank;
            salary.Amount = request.Amount;
            salary.Updated = DateTimeOffset.Now;

            _dataContext.Salaries.Update(salary);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Удаление оклада.
        /// </summary>
        /// <param name="id">ИД оклада.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required][FromRoute] int id)
        {
            var salary = _dataContext.Salaries.FirstOrDefault(i => i.Id == id);
            if (salary == default)
                return NotFound($"Оклад с ИД \"{id}\" не существует.");

            _dataContext.Salaries.Remove(salary);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
