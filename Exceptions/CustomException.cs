using System;

namespace Api.Exceptions
{
	/// <summary>
	/// Excepción base de nuestro sistema.
	/// Se utiliza para diferenciar nuestras excepciones de las default del sistema.
	/// </summary>
	public abstract class CustomException : Exception
	{
		public CustomException(string mensaje)
			: base(mensaje)
		{
		}
	}
}
