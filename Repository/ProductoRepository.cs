using System.Text.Json;
using Api.Exceptions;
using ApiComprasMELI.Models;

namespace ApiComprasMELI.Repository
{
    /// <summary>
    /// Repositorio encargado de gestionar la persistencia de productos en archivos JSON locales.
    /// </summary>
    public class ProductoRepository
    {
        private readonly string carpetaProductos;

        /// <summary>
        /// Constructor. Inicializa la ruta base al directorio de productos en el escritorio del usuario.
        /// </summary>
        public ProductoRepository()
        {
            // Inicializa la ruta base a la carpeta de productos en el escritorio del usuario
            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            carpetaProductos = Path.Combine(escritorio, "ProductosMELI");

            // Asegura que la carpeta exista
            if (!Directory.Exists(carpetaProductos))
            {
                Directory.CreateDirectory(carpetaProductos);
            }
        }

        public Producto? GetById(int idProducto)
        {
            string rutaArchivo = ObtenerRutaArchivoProducto(idProducto);

            if (!File.Exists(rutaArchivo))
            {
                throw new NotFoundException("No se encontró el archivo del producto.");
            }

            string json = File.ReadAllText(rutaArchivo);
            return DeserializarProducto(json);
        }

        public Producto Insert(Producto model)
        {
            string rutaArchivo = ObtenerRutaArchivoProducto(model.Id);

            // Verificar si el archivo ya existe
            if (File.Exists(rutaArchivo))
                throw new NotFoundException($"El producto con ID {model.Id} ya existe.");

            string json = SerializarProducto(model);
            File.WriteAllText(rutaArchivo, json);
            return model;
        }

        public Producto? Update(Producto model)
        {
            string rutaArchivo = ObtenerRutaArchivoProducto(model.Id);

            if (!File.Exists(rutaArchivo))
            {
                return null;
            }

            string json = SerializarProducto(model);
            File.WriteAllText(rutaArchivo, json);
            return model;
        }

        public bool Delete(int idProducto)
        {
            string rutaArchivo = ObtenerRutaArchivoProducto(idProducto);

            if (!File.Exists(rutaArchivo))
            {
                return false; // No hay archivo para borrar
            }

            File.Delete(rutaArchivo);
            return true; // Existía un archivo a borrar
        }

        // ---------------------
        // Métodos auxiliares
        // ---------------------

        private string ObtenerRutaArchivoProducto(int id)
        {
            return Path.Combine(carpetaProductos, $"producto_{id}.json");
        }

        private string SerializarProducto(Producto producto)
        {
            return JsonSerializer.Serialize(producto, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        private Producto? DeserializarProducto(string json)
        {
            return JsonSerializer.Deserialize<Producto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
