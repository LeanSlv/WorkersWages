using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Wages
{
    /// <summary>
    /// Результат запроса списка заработных плат.
    /// </summary>
    public class WageListResponse
    {
        /// <summary>
        /// Список заработныз плат.
        /// </summary>
        [Required]
        public WageInfo[] Wages{ get; set; }

        /// <summary>
        /// Общее количество записей.
        /// </summary>
        [Required]
        public int TotalCount { get; set; }
    }
    
    /// <summary>
    /// Информация о заработной плате.
    /// </summary>
    public class WageInfo
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
        /// Отображаемое наименование цеха.
        /// </summary>
        [Required]
        public string ManufactoryDisplayName { get; set; }

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
        /// Размер зп.
        /// </summary>
        [Required]
        public double Amount { get; set; }

        /// <summary>
        /// Размер зп с учетом надбавок.
        /// </summary>
        [Required]
        public double AmountWithAllowances { get; set; }

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
