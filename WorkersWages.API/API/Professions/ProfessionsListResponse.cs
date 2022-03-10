using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Professions
{
    /// <summary>
    /// Результат запроса списка профессий.
    /// </summary>
    public class ProfessionListResponse
    {
        /// <summary>
        /// Список профессий.
        /// </summary>
        [Required]
        public ProfessionInfo[] Professions { get; set; }

        /// <summary>
        /// Общее количество записей.
        /// </summary>
        [Required]
        public int TotalCount { get; set; }
    }

    /// <summary>
    /// Информация о профессии.
    /// </summary>
    public class ProfessionInfo
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [Required]
        public string Name { get; set; }

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
