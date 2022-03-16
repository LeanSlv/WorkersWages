using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkersWages.API.Exceptions;
using WorkersWages.API.Storage;
using WorkersWages.API.Storage.Models;

namespace WorkersWages.API.API.Wages
{
    /// <summary>
    /// Работа с заработными платами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WagesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public WagesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Получение списка заработных плат.
        /// </summary>
        /// <param name="request">Запрос на получение списка заработных плат.</param>
        /// <returns>Список заработных плат.</returns>
        [HttpGet]
        public WageListResponse List([Required][FromQuery] WageListRequest request)
        {
            var list = _dataContext.Wages.AsQueryable();

            if (!string.IsNullOrEmpty(request.WorkerLastName))
                list = list.Where(i => i.WorkerLastName.Contains(request.WorkerLastName));
            if (request.ManufactoryId.HasValue)
                list = list.Where(i => i.ManufactoryId == request.ManufactoryId.Value);
            if (request.ProfessionId.HasValue)
                list = list.Where(i => i.ProfessionId == request.ProfessionId.Value);
            if (request.Rank.HasValue)
                list = list.Where(i => i.Rank == request.Rank.Value);

            var totalCount = list.Count();
            list = list.OrderBy(i => i.WorkerLastName).Skip(request.Offset).Take(request.Limit);

            var wages = list.Select(i => new WageInfo
            {
                Id = i.Id,
                WorkerLastName = i.WorkerLastName,
                ManufactoryId = i.ManufactoryId,
                ManufactoryDisplayName = $"{i.Manufactory.Name} - №{i.Manufactory.Number}",
                ProfessionName = i.Profession.Name,
                Rank = i.Rank,
                Amount = i.Amount,
                Created = i.Created,
                Updated = i.Updated,
            });

            foreach (var wage in wages)
                wage.AmountWithAllowances = CalculateWageAmountWithAllowances(wage.Id, wage.Amount);

            return new WageListResponse
            {
                Wages = wages.ToArray(),
                TotalCount = totalCount
            };
        }

        /// <summary>
        /// Получение подробностей о заработной плате.
        /// </summary>
        /// <param name="id">ИД заработной платы.</param>
        /// <returns>Подробности о заработной плате</returns>
        [HttpGet("{id}")]
        public ActionResult<WageDetailsResponse> Details([Required][FromQuery] int id)
        {
            var wage = _dataContext.Wages.FirstOrDefault(i => i.Id == id);
            if (wage == default)
                return NotFound($"Заработной платы с ИД \"{id}\" не существует.");

            var allowances = _dataContext.Allowances
                .Where(i => i.WageId == wage.Id)
                .Select(i => new AllowanceInfo
                {
                    Id = i.Id,
                    Name = i.Name,
                    Amount = i.Amount
                });

            return new WageDetailsResponse
            {
                WorkerLastName = wage.WorkerLastName,
                ManufactoryDisplayName = $"{wage.Manufactory.Name} - №{wage.Manufactory.Number}",
                ProfessionName = wage.Profession.Name,
                Rank = wage.Rank,
                Amount = wage.Amount,
                AmountWithAllowances = CalculateWageAmountWithAllowances(wage.Id, wage.Amount),
                Allowances = allowances.ToArray()
            };
        }

        /// <summary>
        /// Создание новой заработной платы.
        /// </summary>
        /// <param name="request">Запрос на создание новой заработной платы.</param>
        /// <returns>ИД созданной заработной платы.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([Required][FromBody] WageCreateRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException();

            if (_dataContext.Wages.Any(i => i.WorkerLastName == request.WorkerLastName))
                throw new ApiException($"Заработная плата для сотрудника \"{request.WorkerLastName}\" уже существует.", "WorkerLastName");

            var salaryAmount = _dataContext.Salaries.FirstOrDefault(i => i.ProfessionId == request.ProfessionId && i.Rank == request.Rank);
            if (salaryAmount == default)
                throw new ApiException("Для выбранных профессии и разряда не существует оклада.");

            var now = DateTimeOffset.Now;
            var wage = new Wage
            {
                WorkerLastName = request.WorkerLastName,
                ManufactoryId = request.ManufactoryId,
                ProfessionId = request.ProfessionId,
                Rank = request.Rank,
                Amount = salaryAmount.Amount,
                Created = now,
                Updated = now
            };

            await _dataContext.Wages.AddAsync(wage);
            await _dataContext.SaveChangesAsync();

            return Ok(wage.Id);
        }

        /// <summary>
        /// Редактирование заработной платы.
        /// </summary>
        /// <param name="id">ИД заработной платы.</param>
        /// <param name="request">Запрос на редактирование заработной платы.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([Required][FromRoute] int id, [Required][FromBody] WageEditRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException();

            var wage = _dataContext.Wages.FirstOrDefault(i => i.Id == id);
            if (wage == default)
                return NotFound($"Заработной платы с ИД \"{id}\" не существует.");

            var amount = wage.Amount;
            if(wage.ProfessionId != request.ProfessionId || wage.Rank != request.Rank)
            {
                var salaryAmount = _dataContext.Salaries.FirstOrDefault(i => i.ProfessionId == request.ProfessionId && i.Rank == request.Rank);
                if (salaryAmount == default)
                    throw new ApiException("Для выбранных профессии и разряда не существует оклада.");

                amount = salaryAmount.Amount;
            }

            wage.WorkerLastName = request.WorkerLastName;
            wage.ManufactoryId = request.ManufactoryId;
            wage.ProfessionId = request.ProfessionId;
            wage.Rank = request.Rank;
            wage.Amount = amount;
            wage.Updated = DateTimeOffset.Now;

            _dataContext.Wages.Update(wage);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Удаление заработной платы.
        /// </summary>
        /// <param name="id">ИД заработной платы.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required][FromRoute] int id)
        {
            var wage = _dataContext.Wages.FirstOrDefault(i => i.Id == id);
            if (wage == default)
                return NotFound($"Заработной платы с ИД \"{id}\" не существует.");

            var allowences = _dataContext.Allowances.Where(i => i.WageId == wage.Id).ToList();
            _dataContext.Allowances.RemoveRange(allowences);

            _dataContext.Wages.Remove(wage);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Получение списка надбавок для заработной платы.
        /// </summary>
        /// <param name="wageId">ИД заработной платы.</param>
        /// <returns>Список надбавок для заработной платы.</returns>
        [HttpGet("{wageId}/allowances")]
        public ActionResult<WageAllowanceListResponse> AllowanceList([Required][FromRoute] int wageId)
        {
            if (!_dataContext.Wages.Any(i => i.Id == wageId))
                return NotFound($"Заработной платы с ИД \"{wageId}\" не существует.");

            var allowances = _dataContext.Allowances
                .Where(i => i.WageId == wageId)
                .Select(i => new AllowanceInfo
                {
                    Id = i.Id,
                    Name = i.Name,
                    Amount = i.Amount
                });

            return new WageAllowanceListResponse
            {
                Allowances = allowances.ToArray()
            };
        }

        /// <summary>
        /// Добавление надбавки к заработной плате.
        /// </summary>
        /// <param name="wageId">ИД заработной платы.</param>
        /// <param name="request">Запрос на добавление надбавки к заработной плате.</param>
        /// <returns>ИД созданной надбавки.</returns>
        [HttpPost("{wageId}/add-allowance")]
        public async Task<IActionResult> AddAllowance([Required][FromRoute] int wageId, [Required][FromBody] WageAddAllowanceRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException();

            if (!_dataContext.Wages.Any(i => i.Id == wageId))
                return NotFound($"Заработной платы с ИД \"{wageId}\" не существует.");

            var now = DateTimeOffset.Now;
            var allowance = new Allowance
            {
                WageId = wageId,
                Name = request.Name,
                Amount = request.Amount,
                Created = now,
                Updated = now
            };

            await _dataContext.AddAsync(allowance);
            await _dataContext.SaveChangesAsync();

            return Ok(allowance.Id);
        }

        /// <summary>
        /// Редактирование надбавки к заработной плате.
        /// </summary>
        /// <param name="wageId">ИД заработной платы.</param>
        /// <param name="allowanceId">ИД надбавки.</param>
        /// <param name="request">Запрос на редактирование надбавки к заработной плате.</param>
        [HttpPut("{wageId}/edit-allowance/{allowanceId}")]
        public async Task<IActionResult> EditAllowance([Required][FromRoute] int wageId, [Required][FromRoute] int allowanceId, [Required][FromBody] WageEditAllowanceRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException();

            if (!_dataContext.Wages.Any(i => i.Id == wageId))
                return NotFound($"Заработной платы с ИД \"{wageId}\" не существует.");

            var allowance = _dataContext.Allowances.FirstOrDefault(i => i.Id == allowanceId);
            if (allowance == default)
                return NotFound($"Надбавки с ИД \"{allowanceId}\" не существует.");

            allowance.Name = request.Name;
            allowance.Amount = request.Amount;
            allowance.Updated = DateTimeOffset.Now;

            _dataContext.Allowances.Update(allowance);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Удаление надбавки к заработной плате.
        /// </summary>
        /// <param name="wageId">ИД заработной платы.</param>
        /// <param name="allowanceId">ИД надбавки.</param>
        [HttpDelete("{wageId}/delete-allowance/{allowanceId}")]
        public async Task<IActionResult> DeleteAllowance([Required][FromRoute] int wageId, [Required][FromRoute] int allowanceId)
        {
            if (!_dataContext.Wages.Any(i => i.Id == wageId))
                return NotFound($"Заработной платы с ИД \"{wageId}\" не существует.");

            var allowance = _dataContext.Allowances.FirstOrDefault(i => i.Id == allowanceId);
            if (allowance == default)
                return NotFound($"Надбавки с ИД \"{allowanceId}\" не существует.");

            _dataContext.Allowances.Remove(allowance);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        [NonAction]
        private double CalculateWageAmountWithAllowances(int wageId, double wageAmount)
        {
            if (!_dataContext.Wages.Any(i => i.Id == wageId))
                throw new ApiException($"Вычисление размера ЗП: заработной платы с ИД \"{wageId}\" не существует.");

            var allowancesAmount = _dataContext.Allowances.Where(i => i.WageId == wageId).Select(i => i.Amount).Sum();
            return wageAmount + allowancesAmount;
        }
    }
}
