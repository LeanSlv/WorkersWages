namespace WorkersWages.API.API.Wages
{
    /// <summary>
    /// Запрос на получение списка заработных плат.
    /// </summary>
    public class WageListRequest : PaginatedListRequest
    {
        /// <summary>
        /// Фамилия рабочего.
        /// </summary>
        public string WorkerLastName { get; set; }

        /// <summary>
        /// ИД цеха.
        /// </summary>
        public int? ManufactoryId { get; set; }

        /// <summary>
        /// ИД профессии.
        /// </summary>
        public int? ProfessionId { get; set; }

        /// <summary>
        /// Разряд.
        /// </summary>
        public int? Rank { get; set; }
    }
}
