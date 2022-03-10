using System;
using System.ComponentModel.DataAnnotations;
using WorkersWages.API.Storage.Models;

namespace WorkersWages.API.API.Schedules
{
    /// <summary>
    /// Результат запроса списка графиков работ цехов.
    /// </summary>
    public class ScheduleListResponse
    {
        /// <summary>
        /// Список графиков работ цехов.
        /// </summary>
        [Required]
        public ScheduleInfo[] Schedules { get; set; }

        /// <summary>
        /// Общее количество записей.
        /// </summary>
        [Required]
        public int TotalCount { get; set; }
    }

    /// <summary>
    /// Информация о графике работы цеха.
    /// </summary>
    public class ScheduleInfo
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// ИД цеха.
        /// </summary>
        [Required]
        public int ManufactoryId { get; set; }

        /// <summary>
        /// Отображаемое название цеха.
        /// </summary>
        [Required]
        public string ManufactoryDisplayName { get; set; }

        /// <summary>
        /// День недели.
        /// </summary>
        [Required]
        public WeekDays WeekDay { get; set; }

        /// <summary>
        /// Время начала работы.
        /// </summary>
        public TimeSpan? WorkingStart { get; set; }

        /// <summary>
        /// Время окончания работы.
        /// </summary>
        public TimeSpan? WorkingEnd { get; set; }

        /// <summary>
        /// Время начала перерыва.
        /// </summary>
        public TimeSpan? BreakStart { get; set; }

        /// <summary>
        /// Время окончания перерыва.
        /// </summary>
        public TimeSpan? BreakEnd { get; set; }

        /// <summary>
        /// Дата и время создания записи.
        /// </summary>
        [Required]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Дата и время обновления записи.
        /// </summary>
        [Required]
        public DateTimeOffset Updated { get; set; }
    }
}
