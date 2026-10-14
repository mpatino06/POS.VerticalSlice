# 🛒 API de Gestión de Ventas

Este proyecto es una **API de gestión de ventas** desarrollada con **.NET 9** utilizando el enfoque de **Minimal API**.  
La arquitectura está basada en **Vertical Slice Architecture** y el patrón **CQRS**, con soporte de **MediatR** para la orquestación de comandos y consultas.

## 🚀 Tecnologías utilizadas
- **.NET 9** con Minimal API
- **CQRS** (Command Query Responsibility Segregation)
- **MediatR** para manejo de comandos/eventos
- **Mapster** para mapeo de objetos
- **Entity Framework Core** como ORM
- **SQL Server** como base de datos principal
- **Scalar** para documentación y pruebas de la API
- **Arquitectura Vertical Slice** para modularidad y mantenibilidad

## 📌 Características principales
- Gestión de productos, clientes y ventas
- Separación clara entre comandos y consultas
- Documentación interactiva con **Scalar**
- Persistencia en **SQL Server** con **EF Core**
- Código organizado por slices para mayor escalabilidad

## ▶️ Ejecución
Clona el repositorio y ejecuta:

```bash
dotnet run
