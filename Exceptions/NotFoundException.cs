namespace Api.Exceptions
{
	/// <summary>
	/// Excepción del dominio que debe ser lanzada cuando no se encuentre el elemento solicitado.
	/// </summary>
	public class NotFoundException
		: CustomException
	{
		/// <summary>
		/// Constructor de excepción del dominio para excepciones donde no se encuentra lo solicitado.
		/// "No se encontró el objeto solicitado.".
		/// </summary>
		public NotFoundException()
			: base("No se encontró el objeto solicitado.")
		{
		}

		public NotFoundException(string message)
		: base(message)
		{
		}
	}
}
