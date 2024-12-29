using System.Text.Json;
using System.Text.Json.Serialization;

namespace Playground.EF.Core.Helpers
{
    /// <summary>
    /// Clase helper para imprimir información en la consola con diversas opciones.
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Imprime un objeto en la consola en formato JSON con opciones avanzadas.
        /// </summary>
        /// <param name="obj">Objeto a serializar.</param>
        /// <param name="indent">Si true, el JSON se imprime con indentación (formato “bonito”).</param>
        /// <param name="ignoreNullValues">Si true, se ignoran valores nulos en el JSON resultante.</param>
        /// <param name="useCamelCase">Si true, se usa “camelCase” para los nombres de las propiedades.</param>
        /// <param name="ignoreCycles">Si true, se ignora la serialización de referencias cíclicas.</param>
        public static void WriteJson(
            object? obj,
            bool indent = false,
            bool ignoreNullValues = false,
            bool useCamelCase = false,
            bool ignoreCycles = false
        )
        {
            if (obj == null)
            {
                Console.WriteLine("El objeto es nulo.");
                return;
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = indent
            };

            // Ignorar valores nulos
            if (ignoreNullValues)
            {
#if NET5_0_OR_GREATER
                options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
#else
                // En versiones anteriores a .NET 5 se usa esta propiedad
                options.IgnoreNullValues = true;
#endif
            }

            // Usar camelCase
            if (useCamelCase)
            {
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            }

            // Ignorar referencias cíclicas
            if (ignoreCycles)
            {
#if NET5_0_OR_GREATER
                options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
#endif
            }

            string json = JsonSerializer.Serialize(obj, options);
            Console.WriteLine(json);
        }

        /// <summary>
        /// Imprime un mensaje de error en color rojo.
        /// </summary>
        /// <param name="message">Mensaje a imprimir.</param>
        public static void LogError(string message)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            Console.ForegroundColor = originalColor;
        }

        /// <summary>
        /// Imprime un mensaje de información en color amarillo.
        /// </summary>
        /// <param name="message">Mensaje a imprimir.</param>
        public static void LogInfo(string message)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[INFO] {message}");
            Console.ForegroundColor = originalColor;
        }

        /// <summary>
        /// Imprime un mensaje de éxito en color verde.
        /// </summary>
        /// <param name="message">Mensaje a imprimir.</param>
        public static void LogSuccess(string message)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[SUCCESS] {message}");
            Console.ForegroundColor = originalColor;
        }

        /// <summary>
        /// Imprime una colección de objetos como tabla en la consola (básico).
        /// </summary>
        /// <typeparam name="T">Tipo de los objetos en la colección.</typeparam>
        /// <param name="data">Colección de objetos.</param>
        public static void WriteAsTable<T>(IEnumerable<T> data)
        {
            if (data == null || !data.Any())
            {
                Console.WriteLine("No hay datos para mostrar en la tabla.");
                return;
            }

            // Obtenemos las propiedades públicas de T
            var properties = typeof(T).GetProperties();

            // Encabezados
            foreach (var prop in properties)
            {
                Console.Write($"{prop.Name}\t");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

            // Filas
            foreach (var item in data)
            {
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(item, null) ?? "";
                    Console.Write($"{value}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
