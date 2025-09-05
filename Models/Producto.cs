namespace ApiComprasMELI.Models
{
    /// <summary>
    /// Representa la entidad Producto jnto con sus atributos.
    /// </summary>
    public class Producto
    {
        /// <summary>
		/// Id del producto.
		/// </summary>
		public int Id { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public required string Nombre { get; set; }

        /// <summary>
        /// Descripcion del Producto.
        /// </summary>
        public required string Descripcion { get; set; }

        /// <summary>
        /// Precio del producto.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Especificacion del producto.
        /// </summary>
        public required Especificacion Especificacion { get; set; }

        /// <summary>
        /// Imagen del producto.
        /// </summary>
        public required string Imagen { get; set; }

        /// <summary>
        /// Calificaciones del producto.
        /// </summary>
        public required List<Calificacion> Calificaciones { get; set; }
    }
}
