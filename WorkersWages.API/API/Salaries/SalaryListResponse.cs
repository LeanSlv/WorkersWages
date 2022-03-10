using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Salaries
{
    /// <summary>
    /// Результат запроса списка окладов.
    /// </summary>
    public class SalaryListResponse
    {
        /// <summary>
        /// Список профессий.
        /// </summary>
        [Required]
        public SalaryInfo[] Professions { get; set; }

        /// <summary>
        /// Общее количество записей.
        /// </summary>
        [Required]
        public int TotalCount { get; set; }
    }

    /// <summary>
    /// Информация об окладах.
    /// </summary>
    public class SalaryInfo
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Название профессии.
        /// </summary>
        [Required]
        public string ProfessionName { get; set; }

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
