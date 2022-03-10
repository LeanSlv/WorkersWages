using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.Storage.Models
{
    /// <summary>
    /// Заработная плата.
    /// </summary>
    public class Wage
    {
        /// <summary>
        /// Ид записи.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Фамилия рабочего.
        /// </summary>
        [Required]
        public string WorkerLastName { get; set; }

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
        /// ИД профессии.
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
        /// Размер зп.
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
