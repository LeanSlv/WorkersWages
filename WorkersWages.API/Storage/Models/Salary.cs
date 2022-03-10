using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.Storage.Models
{
    /// <summary>
    /// Оклад.
    /// </summary>
    public class Salary
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// ИД професии.
        /// </summary>
        [Required]
        public int ProfessionId { get; set; }

        /// <summary>
        /// Профессия.
        /// </summary>
        [Required]
        public virtual Profession Profession { get; set; }

        /// <summary>
        /// Разряд.
        /// </summary>
        [Required]
        public int Rank { get; set; }

        /// <summary>
        /// Сумма оклада.
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
