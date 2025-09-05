# 🚀 API - Gestión de Productos 🚀

💡Esta API permite realizar operaciones CRUD sobre productos de Mercado Libre (MELI). Soporta creación, consulta, actualización y eliminación de productos.

---

## ⚙️Tecnologías

- C#
- .NET 8  
- ASP.NET Core Web API  
- Swagger: https://localhost:7198/swagger/index.html
- JSON para intercambio de datos

---

## ⚙️Estructura del proyecto
- **Controllers/**: Contiene los controladores que exponen los endpoints de la API.
- **Models/**: Definición de las entidades y modelos de datos.
- **Services/**: Lógica de negocio y operaciones sobre los datos.
- **Repository/**: Capa que se ocupa de las transanciones con el modelo que almacenamiento de datos utilizado, archivos .json.
- **DTOs/**: Objetos de transferencia de datos.
- **Exceptions/**: Manejo de excepciones personalizadas.
- **Program.cs**: Configuración del host y servicios de la API.

## 📡Endpoints

| Método  | Ruta                   | Descripción                              |
|---------|------------------------|----------------------------------------|
| GET     | `/Producto/Get`        | Obtiene un producto por su ID.         |
| POST    | `/Producto/Insert`     | Agrega un nuevo producto al sistema.   |
| PUT     | `/Producto/Update`     | Actualiza los datos de un producto existente. |
| DELETE  | `/Producto/Delete`     | Elimina un producto por su ID.         |

---

## 📄Decisiones

💡La solucion aporta un CRUD que nos permite realizar las operaciones mencionada sobre los productos de Mercado Libre. 

💡Almacena los productos en un archivo JSON, que se crea localmente en el Escritorio, al ejecutar por primera vez la operacion POST. La carpeta creada toma el nombre de "ProductosMELI"

💡Se utilizó una arquitectura de capas, en la cual cada una tiene su responsabilidad y cumple una funcion. 

💡Se generaron validaciones exaustivas para cumplir con todos los casos posibles y mitigar errore a la hora de consumir los endpoints.

## 🏃‍♂️Configuración y ejecución

1. Clonar el repositorio o descargar el archivo .zip
2. Abrir (doble click) archivo .sln alojado dentro de la carpeta del proyecto.
3. Compilar el proyecto desde Visual Studio, o desde la consola con comando "donet run".

## 📢 CURL Ejemplo

```bash
curl -X 'GET' \
  'https://localhost:7198/Producto/Get?idProducto=1' \
  -H 'accept: text/plain'
  ```

  ```bash
  curl -X 'POST' \
  'https://localhost:7198/Producto/Insert' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 1,
  "nombre": "Auriculares Inalámbricos",
  "descripcion": "Auriculares Bluetooth con cancelación de ruido y batería de larga duración.",
  "precio": 2999.99,
  "especificacion": {
    "tamanio": 15,
    "materiales": [
      "Plástico", "Metal"
    ],
    "peso": "250g",
    "color": "Negro",
    "marca": "SoundMax",
    "paisOrigen": "Argentina"
  },
  "imagen": "https://example.com/images/auriculares.jpg",
  "calificaciones": [
    {
      "usuario": "juanperez",
      "comentario": "Excelente calidad de sonido y muy cómodos.",
      "puntaje": 5,
      "ventajas": [
        "Batería duradera",
        "Cancelación de ruido"
      ],
      "desventajas": [
        "Precio un poco alto"
      ],
      "fechaCalificacion": "2025-07-27T10:30:00.000Z"
    }
  ]
}'
```
```bash
curl -X 'PUT' \
  'https://localhost:7198/Producto/Update' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 1,
  "nombre": "Auriculares Inalámbricos Pro",
  "descripcion": "Auriculares Bluetooth mejorados con cancelación activa de ruido y micrófono integrado.",
  "precio": 3499.99,
  "especificacion": {
    "tamanio": 16,
    "materiales": [
      "Plástico reforzado", "Aluminio"
    ],
    "peso": "260g",
    "color": "Negro mate",
    "marca": "SoundMax",
    "paisOrigen": "Argentina"
  },
  "imagen": "https://example.com/images/auriculares-pro.jpg",
  "calificaciones": [
    {
      "usuario": "juanperez",
      "comentario": "Ahora con mejor micrófono y sonido más claro.",
      "puntaje": 5,
      "ventajas": [
        "Micrófono mejorado",
        "Calidad de sonido superior"
      ],
      "desventajas": [
        "Un poco más pesados"
      ],
      "fechaCalificacion": "2025-07-27T15:00:00.000Z"
    }
  ]
}'
```
```bash

curl -X 'DELETE' \
  'https://localhost:7198/Producto/Delete?idProducto=1' \
  -H 'accept: text/plain'
```

## 📝Plan de desarrollo
- Configuración del proyecto base y entorno de desarrollo.
- Implementación del modelo de datos y DTOs.
- Desarrollo de los servicios para las operaciones CRUD.
- Creación de los controladores con rutas y validaciones.
- Integración de Swagger para documentación.
- Pruebas funcionales.
- Preparación de documentación y entrega.

---

## 🔧Consideraciones adicionales
- Uso de excepciones personalizadas para manejo claro de errores.
- Validación de datos de entrada con anotaciones y atributos.
- Configuración para entorno de desarrollo local con HTTPS.

---

## ✅ Entrega
El proyecto será entregado en una carpeta comprimida que incluye:
- Código fuente completo.
- Documentación técnica.
- Archivo `README.md` para guiar la ejecución del proyecto y mas detalles sobre el mismo.

---

  ## ✅Autoría

- Addario, Gabriel Omar


Fin del documento.