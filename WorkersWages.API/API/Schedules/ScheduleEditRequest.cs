using System;
using System.ComponentModel.DataAnnotations;
using WorkersWages.API.Storage.Models;

namespace WorkersWages.API.API.Schedules
{
    /// <summary>
    /// Запрос на редактирование графика работы цеха.
    /// </summary>
    public class ScheduleEditRequest
    {
        /// <summary>
        /// ИД цеха.
        /// </summary>
        [Required]
        public int ManufactoryId { get; set; }

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
    }
}
