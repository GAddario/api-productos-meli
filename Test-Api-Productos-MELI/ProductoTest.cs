using ApiComprasMELI.Controllers;
using ApiComprasMELI.DTOs;

namespace Test_Api_Productos_MELI
{
    public class ProductoTest
    {
        [Fact]
        public void Producto3Null()
        {
            //Controller
            var controller = new ProductoController();

            // Funcion que devuelve el producto N°3
            var resultado = controller.ObtenerProducto(3);

            // Verificamos que el resultado no sea nulo
            Assert.NotNull(resultado);

            // Ahora verificamos el contenido dentro de la respuesta
            ProductoDTO? productoDTO = resultado.Contenido as ProductoDTO;
            Assert.Null(productoDTO);        
        }
    }
}