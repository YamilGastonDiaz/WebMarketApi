# 📦 WebMarket API – Proyecto Web API en .NET

## Descripción

Este proyecto es una **API REST desarrollada en .NET** que simula la gestión de un minimarket.  
Permite administrar entidades como:

- Categorías
- Marcas
- Tipos Empaques  
- Usuarios  
- Productos  
- Proveedores  
- Stock  

El objetivo principal fue aprender y aplicar **buenas prácticas de arquitectura backend**.

---

## ¿Qué aprendí?

Durante el desarrollo de este proyecto trabajé con:

### Arquitectura en capas

Separación de responsabilidades en:

- **Controllers** → Manejo de HTTP  
- **Services** → Lógica de negocio  
- **Repositories** → Acceso a datos  
- **Models** → Entidades de base de datos  
- **DTOs** → Objetos de transferencia  

---

### Repository

Implementé el patrón Repository para:

- Abstraer el acceso a datos  
- Facilitar mantenimiento  
- Mejorar la escalabilidad  

---

### Service (Lógica de negocio)

Aprendí a:

- Validar datos antes de guardarlos  
- Aplicar reglas de negocio  
- Evitar duplicados  
- Controlar errores  

---

### DTOs (Data Transfer Objects)

Uso de DTOs para:

- No exponer datos sensibles  
- Controlar lo que entra y sale de la API  
- Separar lógica interna de la externa  

---

### Mappers (Manual)

Implementación de métodos para convertir:

- Entidad → DTO  
- DTO → Entidad  

---

### Paginación

Implementé paginación con:

`Skip((Pagina - 1) * RegistrosPorPagina)
Take(RegistrosPorPagina)`

---

### Captura de Pantalla
![Api Web](<img width="758" height="520" alt="image" src="https://github.com/user-attachments/assets/12a4e277-f937-4cf1-8a51-a87a54d03e5f" />
)


