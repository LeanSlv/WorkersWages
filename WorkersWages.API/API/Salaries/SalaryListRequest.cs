namespace WorkersWages.API.API.Salaries
{
    /// <summary>
    /// Запрос на список окладов.
    /// </summary>
    public class SalaryListRequest : PaginatedListRequest
    {
        /// <summary>
        /// Название профессии.
        /// </summary>
        public string ProfessionName { get; set; }

        /// <summary>
        /// Разряд.
        /// </summary>
        public int? Rank { get; set; }
    }
}
