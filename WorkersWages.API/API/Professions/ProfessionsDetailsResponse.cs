using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Professions
{
    /// <summary>
    /// Результат запроса получения подробностей профессии.
    /// </summary>
    public class ProfessionDetailsResponse
    {
        /// <summary>
        /// Название.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
