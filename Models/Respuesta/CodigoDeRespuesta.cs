namespace Api.Models.Respuesta
{
	public enum CodigoDeRespuesta
	{
		/// <summary>
		/// Respuesta cxitosa.
		/// </summary>
		SUCCESS = 200,

		/// <summary>
		/// Consulta mal realizada.
		/// </summary>
		BAD_REQUEST = 400,

		/// <summary>
		/// No posee autorización.
		/// </summary>
		UNAUTHORIZED = 401,

		/// <summary>
		/// No se encontro lo buscado.
		/// </summary>
		NOT_FOUND = 404,

		/// <summary>
		/// Operaciones que el sistema no puede resolver y se resuelven manualmente.
		/// </summary>
		CONFLICT = 409,

		/// <summary>
		/// Error en el servidor.
		/// </summary>
		INTERNAL_SERVER_ERROR = 500,
	}
}
