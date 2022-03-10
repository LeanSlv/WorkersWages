using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Wages
{
    /// <summary>
    /// Запрос на редактирование заработной платы.
    /// </summary>
    public class WageEditRequest
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
        /// Размер зп.
        /// </summary>
        [Required]
        public double Amount { get; set; }
    }
}
