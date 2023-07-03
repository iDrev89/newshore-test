# newshore-test

Esta solución la desarrollé en muy corto tiempo por temas de disponibilidad por trabajo, sin embargo cumple con todos los requisitos. Es importante destacar que mejoraría el sistema para mostrar los precios en diferentes moneda ya que solamente muestra tres (USD, AUD, CAD). Espero esta prueba sea de su agrado.

Frontend:

Angular 14
TailwindCSS
Angular Material

Para ejecutar el frontend es necesario ejecutar los siguientes comandos:
1. npm-install
2. ng serve

Existe una ventana de login que permite autenticar la API para su consumo y demostrar el uso de interceptores, guards, enrutamiento y demás. El usuario y la contraseña aparecen en la pantalla de login.

Usuario de prueba: jdoe@jdoe.com - Admin1!

Backend:

La solución se creó utilizando la versión .NET 7.
Se implementó una arquitectura limpia.
Los patrones utilizados principalmente son: Mediator CQRS, DTO, e Inyección de dependencias.

La configuración se realiza a través del archivo appsettings, donde se especifica el servidor y la base de datos para el sistema de autenticación (Identity). No es necesario crear manualmente la base de datos, ya que la solución se encarga de crearla y migrarla automáticamente al ejecutar el proyecto por primera vez. Existe un método llamado "Login" que permite autenticarse y genera un token de acceso.


![image](https://github.com/iDrev89/newshore-test/assets/15843004/e43a6460-19d9-4dfd-9d01-bbb485c4b1a4)

![image](https://github.com/iDrev89/newshore-test/assets/15843004/ae25eef0-5f52-4b0a-866c-485afdceb134)

