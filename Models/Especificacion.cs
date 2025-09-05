namespace ApiComprasMELI.Models
{
    /// <summary>
    /// Representa las especificaciones técnicas de un producto.
    /// </summary>
    public class Especificacion
    {
        /// <summary>
        /// Tamaño del producto expresado como valor numérico.
        /// </summary>
        public int Tamanio { get; set; }

        /// <summary>
        /// Lista de materiales con los que está fabricado el producto.
        /// </summary>
        public required List<string> Materiales { get; set; }

        /// <summary>
        /// Peso del producto, expresado como texto (por ejemplo, "1.2kg").
        /// </summary>
        public required string Peso { get; set; }

        /// <summary>
        /// Color principal del producto.
        /// </summary>
        public required string Color { get; set; }

        /// <summary>
        /// Marca del producto.
        /// </summary>
        public required string Marca { get; set; }

        /// <summary>
        /// País de origen donde fue fabricado el producto.
        /// </summary>
        public required string PaisOrigen { get; set; }
    }
}