using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Wages
{
    /// <summary>
    /// Результат запроса подробностей о заработной плате.
    /// </summary>
    public class WageDetailsResponse
    {
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
        /// ИД профессии.
        /// </summary>
        [Required]
        public int ProfessionId { get; set; }

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
        /// Надбавки.
        /// </summary>
        [Required]
        public AllowanceInfo[] Allowances { get; set; }
    }
}
