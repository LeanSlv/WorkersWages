namespace WorkersWages.API.API.Wages
{
    /// <summary>
    /// Результат запроса надбавок для заработной платы.
    /// </summary>
    public class WageAllowanceListResponse
    {
        /// <summary>
        /// Список надбавок.
        /// </summary>
        public AllowanceInfo[] Allowances { get; set; }
    }
}
