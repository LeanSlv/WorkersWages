using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.Storage.Models
{
    /// <summary>
    /// Цех.
    /// </summary>
    public class Manufactory
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Номер.
        /// </summary>
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// ФИО начальника.
        /// </summary>
        [Required]
        public string HeadFIO { get; set; }

        /// <summary>
        /// ИД фотографии начальника.
        /// </summary>
        public int? PhotoId { get; set; }

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
