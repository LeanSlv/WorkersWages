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
        public Time? WorkingStart { get; set; }

        /// <summary>
        /// Время окончания работы.
        /// </summary>
        public Time? WorkingEnd { get; set; }

        /// <summary>
        /// Время начала перерыва.
        /// </summary>
        public Time? BreakStart { get; set; }

        /// <summary>
        /// Время окончания перерыва.
        /// </summary>
        public Time? BreakEnd { get; set; }

        /// <summary>
        /// Время (для удобного взаимодействия с клиентом).
        /// </summary>
        public class Time
        {
            /// <summary>
            /// Часы.
            /// </summary>
            [Required]
            public int Hours { get; set; }

            /// <summary>
            /// Минуты.
            /// </summary>
            [Required]
            public int Minutes { get; set; }
        }
    }
}
