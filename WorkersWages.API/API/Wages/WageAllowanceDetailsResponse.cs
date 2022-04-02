using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Wages
{
    /// <summary>
    /// Результат получения подробностей надбавки для заработной платы.
    /// </summary>
    public class WageAllowanceDetailsResponse
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Размер.
        /// </summary>
        [Required]
        public double Amount{ get; set; }
    }
}
