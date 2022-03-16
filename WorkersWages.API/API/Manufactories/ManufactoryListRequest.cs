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
        public string Name { get; set; }

        /// <summary>
        /// Номер.
        /// </summary>
        public string Number { get; set; }
    }
}
