using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Manufactories
{
    /// <summary>
    /// Запрос на получение списка цехов.
    /// </summary>
    public class ManufactoryListRequest : PaginatedListRequest
    {
        /// <summary>
        /// Название.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Номер.
        /// </summary>
        [Required]
        public string Number { get; set; }
    }
}
