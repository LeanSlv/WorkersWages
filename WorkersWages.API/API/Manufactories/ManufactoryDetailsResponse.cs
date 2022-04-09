using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Manufactories
{
    /// <summary>
    /// Результат запроса подробностей о цехе.
    /// </summary>
    public class ManufactoryDetailsResponse
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

        /// <summary>
        /// ФИО начальника.
        /// </summary>
        [Required]
        public string HeadFIO { get; set; }

        /// <summary>
        /// Url фотографии начальника.
        /// </summary>
        public string HeadPhotoUrl { get; set; }
    }
}
