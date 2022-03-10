using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.Storage.Models
{
    /// <summary>
    /// График работы цеха.
    /// </summary>
    public class Schedule
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
        /// Цех.
        /// </summary>
        [Required]
        public virtual Manufactory Manufactory { get; set; }

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
