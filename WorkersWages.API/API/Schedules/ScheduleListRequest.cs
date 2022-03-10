using WorkersWages.API.Storage.Models;

namespace WorkersWages.API.API.Schedules
{
    /// <summary>
    /// Запрос на получение списка графиков работ цехов.
    /// </summary>
    public class ScheduleListRequest : PaginatedListRequest
    {
        /// <summary>
        /// ИД цеха.
        /// </summary>
        public int? ManufactoryId { get; set; }

        /// <summary>
        /// День недели.
        /// </summary>
        public WeekDays? WeekDay { get; set; }
    }
}
