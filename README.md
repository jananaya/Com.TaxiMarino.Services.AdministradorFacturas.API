# API de Administración de Facturas - Taxi Marino

Este proyecto es una API para la administración de facturas en **Taxi Marino**, desarrollada en **ASP.NET 8** y ejecutada con **Docker Compose**. A continuación, se detallan las instrucciones para su instalación y ejecución.  

## 🚀 Requisitos Previos  
Antes de ejecutar la API, es necesario contar con los siguientes componentes instalados:  

- [Docker](https://www.docker.com/get-started) (Docker Desktop en Windows/macOS o Docker Engine en Linux)  
- [Docker Compose](https://docs.docker.com/compose/) (si no está incluido con Docker)  

## 📦 Construcción y Ejecución  
Para ejecutar la API con Docker Compose, sigue estos pasos:  

1. **Clonar el repositorio:**  
   ```sh
   git clone https://github.com/jananaya/Com.TaxiMarino.Services.AdministradorFacturas.API.git
   cd Com.TaxiMarino.Services.AdministradorFacturas.API
   ```

2. **Construir las imágenes de Docker:**  
   ```sh
   docker compose build
   ```

3. **Levantar los contenedores:**  
   ```sh
   docker compose up -d
   ```  
   > 🔹 La opción `-d` ejecuta los contenedores en segundo plano.  

4. **Verificar que el servicio está corriendo:**  
   ```sh
   docker ps
   ```  

5. **Acceder a la API:**  
   - Si la API está corriendo correctamente, se puede acceder a través de:  
     ```
     http://localhost:5119
     ```
     *(El puerto puede variar según la configuración en `docker-compose.yml`)*  

## 📝 Notas Adicionales  
- Es recomendable verificar que no haya conflictos de puertos en el sistema.  
- Para reconstruir las imágenes después de realizar cambios en el código, se puede ejecutar:  
  ```sh
  docker compose up --build -d
  ```  

---

📌 Con esto, la API de administración de facturas en **Taxi Marino** queda lista para su uso. 🚀