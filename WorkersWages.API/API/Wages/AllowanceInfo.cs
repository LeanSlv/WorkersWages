using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Wages
{
    /// <summary>
    /// Информация о надбавках.
    /// </summary>
    public class AllowanceInfo
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        [Required]
        public int Id { get; set; }

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
