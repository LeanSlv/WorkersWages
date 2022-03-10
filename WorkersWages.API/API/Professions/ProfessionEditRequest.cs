using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Professions
{
    /// <summary>
    /// Запрос на редактирование профессии.
    /// </summary>
    public class ProfessionEditRequest
    {
        /// <summary>
        /// Название.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
