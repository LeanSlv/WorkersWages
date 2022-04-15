using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkersWages.API.Exceptions;
using WorkersWages.API.Storage;
using WorkersWages.API.Storage.Models;

namespace WorkersWages.API.API.Schedules
{
    /// <summary>
    /// Работа с графиками работы цехов.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SchedulesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SchedulesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Получение списка графиков работ цехов.
        /// </summary>
        /// <param name="request">Запрос на получение списка графиков работ цехов.</param>
        /// <returns>Список графиков работ цехов.</returns>
        [HttpGet]
        public ScheduleListResponse List([Required][FromQuery] ScheduleListRequest request)
        {
            var list = _dataContext.Schedules.Select(i => new ScheduleInfo
            {
                Id = i.Id,
                ManufactoryId = i.ManufactoryId,
                ManufactoryDisplayName = $"{i.Manufactory.Name} - №{i.Manufactory.Number}",
                WeekDay = i.WeekDay,
                WorkingStart = i.WorkingStart,
                WorkingEnd = i.WorkingEnd,
                BreakStart = i.BreakStart,
                BreakEnd = i.BreakEnd,
                Created = i.Created,
                Updated = i.Updated
            });

            if (request.ManufactoryId.HasValue)
                list = list.Where(i => i.ManufactoryId == request.ManufactoryId.Value);
            if (request.WeekDay.HasValue)
                list = list.Where(i => i.WeekDay == request.WeekDay.Value);

            var totalCount = list.Count();
            list = list.OrderBy(i => i.ManufactoryId).Skip(request.Offset).Take(request.Limit);

            return new ScheduleListResponse
            {
                Schedules = list.ToArray(),
                TotalCount = totalCount
            };
        }

        /// <summary>
        /// Получение подробностей графика работы цеха.
        /// </summary>
        /// <param name="id">ИД графика работы цеха.</param>
        /// <returns>Подробности графика работы цеха.</returns>
        [HttpGet("{id}")]
        public ActionResult<ScheduleDetailsResponse> Details([Required][FromRoute] int id)
        {
            var schedule = _dataContext.Schedules.FirstOrDefault(i => i.Id == id);
            if(schedule == default)
                return NotFound($"Графика работы для цеха с ИД \"{id}\" не существует.");

            return new ScheduleDetailsResponse
            {
                ManufactoryId = schedule.ManufactoryId,
                WeekDay = schedule.WeekDay,
                WorkingStart = schedule.WorkingStart,
                WorkingEnd = schedule.WorkingEnd,
                BreakStart = schedule.BreakStart,
                BreakEnd = schedule.BreakEnd
            };
        }

        /// <summary>
        /// Добавление нового графика работы для цеха.
        /// </summary>
        /// <param name="request">Запрос на добавление графика работы для цеха.</param>
        /// <returns>ИД созданного графика работы для цеха.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([Required][FromBody] ScheduleCreateRequest request)
        {
            if (_dataContext.Schedules.Any(i => i.ManufactoryId == request.ManufactoryId && i.WeekDay == request.WeekDay))
                throw new ApiException($"График работы для цеха с ИД \"{request.ManufactoryId}\" для дня недели \"{request.WeekDay}\" уже существует.");

            var now = DateTimeOffset.Now;
            var schedule = new Schedule
            {
                ManufactoryId = request.ManufactoryId,
                WeekDay = request.WeekDay,
                WorkingStart = request.WorkingStart != null ? new TimeSpan(request.WorkingStart.Hours, request.WorkingStart.Minutes, 0) : null,
                WorkingEnd = request.WorkingEnd != null ? new TimeSpan(request.WorkingEnd.Hours, request.WorkingEnd.Minutes, 0) : null,
                BreakStart = request.BreakStart != null ? new TimeSpan(request.BreakStart.Hours, request.BreakStart.Minutes, 0) : null,
                BreakEnd = request.BreakEnd != null ? new TimeSpan(request.BreakEnd.Hours, request.BreakEnd.Minutes, 0) : null,
                Created = now,
                Updated = now
            };

            await _dataContext.Schedules.AddAsync(schedule);
            await _dataContext.SaveChangesAsync();

            return Ok(schedule.Id);
        }

        /// <summary>
        /// Редактирование графика работы цеха.
        /// </summary>
        /// <param name="id">ИД графика работы цеха.</param>
        /// <param name="request">Запрос на редактирование графика работы цеха.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([Required][FromRoute] int id, [Required][FromBody] ScheduleEditRequest request)
        {
            var schedule = _dataContext.Schedules.FirstOrDefault(i => i.Id == id);
            if (schedule == default)
                return NotFound($"Графика работы для цеха с ИД \"{id}\" не существует.");

            if (_dataContext.Schedules.Any(i => i.Id != id && i.ManufactoryId == request.ManufactoryId && i.WeekDay == request.WeekDay))
                throw new ApiException($"График работы для цеха с ИД \"{request.ManufactoryId}\" для дня недели \"{request.WeekDay}\" уже существует.");

            schedule.ManufactoryId = request.ManufactoryId;
            schedule.WeekDay = request.WeekDay;
            schedule.WorkingStart = request.WorkingStart != null ? new TimeSpan(request.WorkingStart.Hours, request.WorkingStart.Minutes, 0) : null;
            schedule.WorkingEnd = request.WorkingEnd != null ? new TimeSpan(request.WorkingEnd.Hours, request.WorkingEnd.Minutes, 0) : null;
            schedule.BreakStart = request.BreakStart != null ? new TimeSpan(request.BreakStart.Hours, request.BreakStart.Minutes, 0) : null;
            schedule.BreakEnd = request.BreakEnd != null ? new TimeSpan(request.BreakEnd.Hours, request.BreakEnd.Minutes, 0) : null;
            schedule.Updated = DateTimeOffset.Now;

            _dataContext.Schedules.Update(schedule);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Удаление графика работы цеха.
        /// </summary>
        /// <param name="id">ИД графика работы цеха.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required][FromRoute] int id)
        {
            var schedule = _dataContext.Schedules.FirstOrDefault(i => i.Id == id);
            if (schedule == default)
                return NotFound($"Графика работы для цеха с ИД \"{id}\" не существует.");

            _dataContext.Schedules.Remove(schedule);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
