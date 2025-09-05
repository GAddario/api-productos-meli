namespace Api.Models.Respuesta
{
    public class RespuestaConContenido<T> : RespuestaBase
    {
        public T Contenido { get; set; }

        /// <summary>
        /// Respuesta extendida contiene un código de estado, un mensaje y un objeto.
        /// </summary>
        /// <param name="codigo">
        /// Codigo de estado de la respuesta.
        /// </param>
        /// <param name="mensaje">
        /// Mensaje respecto al estado de la respuesta.
        /// </param>
        /// <param name="contenido">
        /// Objeto con datos. Es de tipo generico por lo que se adapta a la necesidad.
        /// </param>
        public RespuestaConContenido(CodigoDeRespuesta codigo, string mensaje, T contenido)
            : base(codigo, mensaje)
        {
            this.Contenido = contenido;
        }
    }
}
