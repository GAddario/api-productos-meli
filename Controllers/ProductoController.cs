using System.ComponentModel.DataAnnotations;
using Api.Exceptions;
using Api.Models.Respuesta;
using ApiComprasMELI.DTOs;
using ApiComprasMELI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiComprasMELI.Controllers
{
    /// <summary>
    /// Controlador para gestionar productos.
    /// Permite obtener, agregar, actualizar y eliminar productos en el sistema.
    /// </summary>
    [ApiController]
    [Route("/[controller]")]
    public class ProductoController
    {
        private ProductoService productoService = new ProductoService();

        public ProductoController()
            : base()
        {
        }

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="idProducto">ID del producto a obtener.</param>
        /// <returns>Datos del producto solicitado.</returns>
        /// <response code="200">Producto encontrado y devuelto correctamente.</response>
        /// <response code="400">El ID es inválido o el producto no existe.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(RespuestaConContenido<ProductoDTO>), 200)]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 400)]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 500)]
        public RespuestaConContenido<object> ObtenerProducto([Required] int idProducto)
        {
            try
            {
                var productoDTO = this.productoService.ObtenerProducto(idProducto);

                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.SUCCESS,
                    "Producto devuelto con exito",
                    productoDTO);
            }
            catch (CustomException excepcion)
            {
                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.BAD_REQUEST,
                    excepcion.Message,
                    null);
            }
            catch (Exception)
            {
                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.INTERNAL_SERVER_ERROR,
                    "Ha ocurrido un error desconocido.",
                    null);
            }

        }

        /// <summary>
        /// Agrega un nuevo producto al sistema.
        /// </summary>
        /// <param name="productoDTO">Objeto con los datos del producto a agregar.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">Producto agregado exitosamente.</response>
        /// <response code="400">Datos inválidos o conflicto en reglas de negocio.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost("Insert")]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 200)]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 400)]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 500)]
        public RespuestaConContenido<object> AgregarProducto([Required] ProductoDTO productoDTO)
        {
            try
            {
                this.productoService.AgregarProducto(productoDTO);

                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.SUCCESS,
                    "Producto agregado con exito",
                    null);
            }
            catch (CustomException excepcion)
            {
                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.BAD_REQUEST,
                    excepcion.Message,
                    null);
            }
            catch (Exception)
            {
                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.INTERNAL_SERVER_ERROR,
                    "Ha ocurrido un error desconocido.",
                    null);
            }
        }

        /// <summary>
        /// Actualiza los datos de un producto existente.
        /// </summary>
        /// <param name="productoDTO">Objeto con los datos actualizados del producto.</param>
        /// <returns>Resultado de la operación con el producto actualizado.</returns>
        /// <response code="200">Producto actualizado correctamente.</response>
        /// <response code="400">Datos inválidos o el producto no existe.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPut("Update")]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 200)]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 400)]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 500)]
        public RespuestaConContenido<object> ActualizarProducto([Required] ProductoDTO productoDTO)
        {
            try
            {
                var response = this.productoService.ActualizarProducto(productoDTO);

                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.SUCCESS,
                    "Producto actualizado con exito",
                    response);
            }
            catch (CustomException excepcion)
            {
                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.BAD_REQUEST,
                    excepcion.Message,
                    null);
            }
            catch (Exception)
            {
                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.INTERNAL_SERVER_ERROR,
                    "Ha ocurrido un error desconocido.",
                    null);
            }
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="idProducto">ID del producto a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        /// <response code="200">Producto eliminado correctamente.</response>
        /// <response code="400">El ID es inválido o el producto no existe.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 200)]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 400)]
        [ProducesResponseType(typeof(RespuestaConContenido<object>), 500)]
        public RespuestaConContenido<object> BorrarProducto([Required] int idProducto)
        {
            try
            {
                this.productoService.BorrarProducto(idProducto);

                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.SUCCESS,
                    "Producto eliminado con exito",
                    null);
            }
            catch (CustomException excepcion)
            {
                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.BAD_REQUEST,
                    excepcion.Message,
                    null);
            }
            catch (Exception)
            {
                return new RespuestaConContenido<object>(
                    CodigoDeRespuesta.INTERNAL_SERVER_ERROR,
                    "Ha ocurrido un error desconocido.",
                    null);
            }
        }

        [HttpGet("Error")]
        public IActionResult GetError()
        {
            // Captura un mensaje en Sentry
            SentrySdk.CaptureMessage("Hola desde mi API!");

            // Forzar un error para ver el stacktrace
            throw new Exception("Error de prueba - Sentry funcionando!");
        }

        [HttpGet("Error 2")]
        public IActionResult GetErrorPrueba2()
        {
            // Captura un mensaje en Sentry
            SentrySdk.CaptureMessage("Hola, esto es una prueba!");

            // Forzar un error para ver el stacktrace
            throw new Exception("Error de prueba - Sentry funcionando OK!");
        }
    }
}
