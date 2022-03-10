using WorkersWages.API.Interfaces;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace WorkersWages.API.Services
{
    /// <summary>
    /// Фабрика, возвращающая экземпляр преобразователя десериализации для конкретного типа.
    /// </summary>
    public class JsonElementsPresentedConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(IJsonElementsPresented).IsAssignableFrom(typeToConvert);

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(JsonElementsPresentedConverter<>)
                    .MakeGenericType(new Type[] { typeToConvert }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: null,
                culture: null)!;
            return converter;
        }
    }
}
