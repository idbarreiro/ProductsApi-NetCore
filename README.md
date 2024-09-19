<h1>Rest Api</h1>

Desarrollar API REST que gestione una lista de productos, uno usando .Net Core.

<h3>Configuracion Inicial</h3>

<li>Verficar la cadena de conexión.</li>
<li>Limpiar la solución.</li>
<li>Compilar la solución.</li>
<li>Restaurar paquetes.</li>

<h3>Ejecución de la solución</h3>
<li>Se selecciona como proyecto de inicio Products.Api.</li> 
<li>Se verifica que el depurar este seleccionado IIS Express y se da F5 para la ejecución de la Solución.</li> 
<li>Si aparece el Swagger como en esta imagen esta ejecutando correctamente.</li><br>

<img>![image](https://github.com/user-attachments/assets/f3dd4902-fb23-4b73-b25e-eed4031124ab)</img>

<h3>Aplicar las migraciones</h3>

Ir a la consola de administrador de paquetes seleccionar el proyecto de <b>Infraestructure</b> como predeterminado y ejecutar
Update-database

Migraciones a aplicar
1. 20240919034643_Initial
2. 20240919040343_Create_SPs

Al ejecutar las migraciones se debe crear la base de datos <b>ProductBD</b>, la tabla <b>dbo.Products</b> y los procedimientos almacenados
<li>dbo.DeleteProduct</li>
<li>dbo.GetAllProducts</li>
<li>dbo.GetProductById</li>
<li>dbo.InsertProduct</li>
<li>dbo.UpdateProduct</li><br>

Para la Rest Api creada con .Net Core se tiene desarrolladas las funcionalidad de 
<li>Insertar un nuevo producto</li>
<li>Obtener todos los productos creados</li>
<li>Obtener un producto por medio del Id</li>

El Id del producto se da como respuesta al momento de insertar un nuevo producto para que tenga la información ya que ese Id se pide como parametro en otras funcionalidades
