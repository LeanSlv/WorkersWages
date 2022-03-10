namespace WorkersWages.API.API.Professions
{
    /// <summary>
    /// Запрос на список профессий.
    /// </summary>
    public class ProfessionListRequest : PaginatedListRequest
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}
