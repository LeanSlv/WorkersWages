using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API
{
    /// <summary>
    /// Запрос постраничного списка.
    /// </summary>
    public class PaginatedListRequest
    {
        /// <summary>
        /// Количество записей, возвращаемое в запросе.
        /// </summary>
        [Required]
        public int Limit { get; set; }

        /// <summary>
        /// Количество записей для пропуска.
        /// </summary>
        [Required]
        public int Offset { get; set; }
    }
}
