using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Salaries
{
    /// <summary>
    /// Результат запроса получения подробностей оклада.
    /// </summary>
    public class SalaryDetailsResponse
    {
        /// <summary>
        /// ИД профессии.
        /// </summary>
        [Required]
        public int ProfessionId { get; set; }

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
    }
}
