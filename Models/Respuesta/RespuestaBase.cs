namespace Api.Models.Respuesta
{
    public class RespuestaBase
    {
        public CodigoDeRespuesta Codigo { get; set; }

        public string Mensaje { get; set; }

        /// <summary>
        /// Respuesta standart que solo contiene un código de estado y un mensaje.
        /// </summary>
        /// <param name="codigo">
        /// Codigo de estado de la respuesta.
        /// </param>
        /// <param name="mensaje">
        /// Mensaje respecto al estado de la respuesta.
        /// </param>
        public RespuestaBase(CodigoDeRespuesta codigo, string mensaje)
        {
            this.Codigo = codigo;
            this.Mensaje = mensaje;
        }
    }
}
