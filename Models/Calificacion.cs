namespace ApiComprasMELI.Models
{
    /// <summary>
    /// Representa una calificación hecha por un usuario sobre un producto.
    /// </summary>
    public class Calificacion
    {
        /// <summary>
        /// Nombre o identificador del usuario que realizó la calificación.
        /// </summary>
        public required string Usuario { get; set; }

        /// <summary>
        /// Comentario libre del usuario sobre su experiencia con el producto.
        /// </summary>
        public required string Comentario { get; set; }

        /// <summary>
        /// Puntuación otorgada al producto, generalmente entre 1 y 5.
        /// </summary>
        public int Puntaje { get; set; }

        /// <summary>
        /// Lista de aspectos positivos destacados por el usuario.
        /// </summary>
        public required List<string> Ventajas { get; set; }

        /// <summary>
        /// Lista de aspectos negativos mencionados por el usuario.
        /// </summary>
        public required List<string> Desventajas { get; set; }

        /// <summary>
        /// Fecha en la que se realizó la calificación.
        /// </summary>
        public required DateTime FechaCalificacion { get; set; }
    }
}
