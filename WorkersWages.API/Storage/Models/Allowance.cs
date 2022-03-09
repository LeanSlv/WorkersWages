using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.Storage.Models
{
    /// <summary>
    /// Надбавка.
    /// </summary>
    public class Allowance
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// ИД заработной платы.
        /// </summary>
        [Required]
        public int WageId { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Размер надбавки.
        /// </summary>
        [Required]
        public double Amount { get; set; }

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
