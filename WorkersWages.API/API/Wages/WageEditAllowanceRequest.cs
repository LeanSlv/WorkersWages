using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Wages
{
    /// <summary>
    /// Запрос на редактирование надбавки к заработной платы.
    /// </summary>
    public class WageEditAllowanceRequest
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Размер надбавки.
        /// </summary>
        [Required]
        public double Amount { get; set; }
    }
}
