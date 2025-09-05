using Api.Exceptions;
using ApiComprasMELI.DTOs;
using ApiComprasMELI.Models;
using ApiComprasMELI.Repository;

namespace ApiComprasMELI.Services
{
    /// <summary>
    /// Servicio encargado de la lógica de negocio relacionada con los productos.
    /// Valida y transforma datos antes de acceder al repositorio.
    /// </summary>
    public class ProductoService
    {
        private ProductoRepository productoRepository = new ProductoRepository();

        /// <summary>
        /// Constructor por defecto del servicio de productos.
        /// </summary>
        public ProductoService()
            : base()
        {
        }

        public ProductoDTO ObtenerProducto(int idProducto)
        {
            if (idProducto <= 0)
            {
                throw new NotFoundException("El ID del producto debe ser mayor a cero.");
            }

            Producto? producto = this.productoRepository.GetById(idProducto);

            if (producto == null)
            {
                throw new NotFoundException($"No se encontró el producto con ID {idProducto}.");
            }

            return this.GenerarProductoDTO(producto);
        }

        public void AgregarProducto(ProductoDTO productoDTO)
        {
            if (productoDTO == null)
            {
                throw new ArgumentNullException(nameof(productoDTO), "El producto no puede ser nulo.");
            }

            ValidarProductoDTO(productoDTO);

            var producto = this.GenerarProductoModel(productoDTO);
            this.productoRepository.Insert(producto);
        }

        public ProductoDTO ActualizarProducto(ProductoDTO productoDTO)
        {
            if (productoDTO == null)
            {
                throw new ArgumentNullException(nameof(productoDTO), "El producto no puede ser nulo.");
            }

            if (productoDTO.Id <= 0)
            {
                throw new ArgumentException("El ID del producto a actualizar debe ser mayor a cero.");
            }

            ValidarProductoDTO(productoDTO);

            var producto = this.GenerarProductoModel(productoDTO);

            var actualizado = this.productoRepository.Update(producto);
            if (actualizado == null)
            {
                throw new NotFoundException($"No se pudo actualizar: producto con ID {productoDTO.Id} no existe.");
            }

            return productoDTO;
        }

        public void BorrarProducto(int idProducto)
        {
            if (idProducto <= 0)
            {
                throw new ArgumentException("El ID del producto debe ser mayor a cero.");
            }

            bool eliminado = this.productoRepository.Delete(idProducto);
            if (!eliminado)
            {
                throw new NotFoundException($"No se encontró el producto con ID {idProducto} para eliminar.");
            }
        }

        private void ValidarProductoDTO(ProductoDTO producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");

            if (string.IsNullOrWhiteSpace(producto.Descripcion))
                throw new ArgumentException("La descripción del producto es obligatoria.");

            if (producto.Precio <= 0)
                throw new ArgumentException("El precio del producto debe ser mayor a cero.");

            if (producto.Especificacion == null)
                throw new ArgumentException("La especificación del producto es obligatoria.");

            if (string.IsNullOrWhiteSpace(producto.Imagen))
                throw new ArgumentException("La URL o ruta de la imagen del producto es obligatoria.");

            if (producto.Calificaciones == null)
                throw new ArgumentException("La lista de calificaciones no puede ser nula (puede estar vacía).");
        }


        private ProductoDTO GenerarProductoDTO(Producto producto)
        {
            return new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Especificacion = producto.Especificacion,
                Imagen = producto.Imagen,
                Calificaciones = producto.Calificaciones
            };
        }

        private Producto GenerarProductoModel(ProductoDTO dto)
        {
            return new Producto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Especificacion = dto.Especificacion,
                Imagen = dto.Imagen,
                Calificaciones = dto.Calificaciones
            };
        }
    }
}
