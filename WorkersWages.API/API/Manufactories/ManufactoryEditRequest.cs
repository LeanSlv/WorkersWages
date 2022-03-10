using System.ComponentModel.DataAnnotations;

namespace WorkersWages.API.API.Manufactories
{
    /// <summary>
    /// Запрос на редактирование цеха.
    /// </summary>
    public class ManufactoryEditRequest
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
        /// ИД фотографии начальника.
        /// </summary>
        public int? HeadPhotoId { get; set; }
    }
}
