using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Manufactories
{
    /// <summary>
    /// Результат запроса списка цехов.
    /// </summary>
    public class ManufactoryListResponse
    {
        /// <summary>
        /// Список профессий.
        /// </summary>
        [Required]
        public ManufactoryInfo[] Manufactories { get; set; }

        /// <summary>
        /// Общее количество записей.
        /// </summary>
        [Required]
        public int TotalCount { get; set; }
    }

    /// <summary>
    /// Информация о цехе.
    /// </summary>
    public class ManufactoryInfo
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        [Required]
        public int Id { get; set; }

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

        /// <summary>
        /// Дата и время создания записи.
        /// </summary>
        [Required]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Дата и время обновления записи.
        /// </summary>
        [Required]
        public DateTimeOffset Updated { get; set; }
    }
}
