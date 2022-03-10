using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using WorkersWages.API.Interfaces;

namespace WorkersWages.API.Services
{
    /// <summary>
    /// Преобразователь десериализации конкретного типа с учётом представленных свойств/элементов в специальном свойстве.
    /// </summary>
    /// <typeparam name="T">Тип данных, который участвует в десериализации.</typeparam>
    public class JsonElementsPresentedConverter<T> : JsonConverter<T> where T : IJsonElementsPresented
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var instance = (T?)Activator.CreateInstance(typeToConvert);
            if (instance == null)
                throw new JsonException();

            var propNames = new List<string>();
            var properties = typeToConvert
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.CanRead && m.CanWrite && m.GetCustomAttribute<JsonIgnoreAttribute>() == null);
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    instance.JsonElements = propNames.ToArray();
                    return instance;
                }
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }
                string propName = reader.GetString()!;
                var propInfo = properties.FirstOrDefault(i => propName == (options.PropertyNamingPolicy?.ConvertName(i.Name) ?? i.Name));
                if (propInfo == null)
                {
                    var propValue = JsonSerializer.Deserialize<object>(ref reader, options);
                }
                else
                {
                    var propValue = JsonSerializer.Deserialize(ref reader, propInfo.PropertyType, options);
                    propInfo.SetValue(instance, propValue);
                    propNames.Add(propInfo.Name);
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var properties = value.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.CanRead && m.CanWrite && m.GetCustomAttribute<JsonIgnoreAttribute>() == null);
            writer.WriteStartObject();
            foreach (var property in properties)
            {
                var propValue = property.GetValue(value);
                if (propValue == null && options.IgnoreNullValues)
                {
                    continue;
                }
                writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(property.Name) ?? property.Name);
                JsonSerializer.Serialize(writer, propValue, options);
            }
            writer.WriteEndObject();
        }
    }
}
