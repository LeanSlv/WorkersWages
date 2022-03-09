using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.Storage.Models
{
    /// <summary>
    /// Профессия.
    /// </summary>
    public class Profession
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [Required]
        public string Name { get; set; }

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
