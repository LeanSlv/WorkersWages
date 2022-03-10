using System.Text.Json.Serialization;

#nullable enable

namespace WorkersWages.API.Interfaces
{
    /// <summary>
    /// Означает, что в экземпляре содержится информация о представленных в JSON-представлении элементах.
    /// </summary>
    public interface IJsonElementsPresented
    {
        /// <summary>
        /// Список свойств/элементов, представленных в JSON-объекте.
        /// </summary>
        [JsonIgnore]
        string[] JsonElements { get; set; }
    }
}
