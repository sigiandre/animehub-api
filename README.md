# ⚙️ AnimeHub API — Backend RESTful (.NET 8 + PostgreSQL)

API RESTful desarrollada en **ASP.NET Core 8 Web API** y **PostgreSQL** que impulsa la plataforma **AnimeHub**. Proporciona gestión completa de catálogos de anime, sagas, episodios, personajes, habilidades, videos multimedia, reseñas, foros de discusión, favoritos, notificaciones y autenticación segura mediante **JWT**.

🔗 **Repositorio Frontend:** [animehub-web](https://github.com/sigiandre/animehub-web)

---

## 🛠️ Stack Tecnológico

* **.NET 8** — ASP.NET Core Web API
* **PostgreSQL** — Base de datos relacional (Npgsql)
* **Entity Framework Core** — ORM, migraciones y consultas relacionales
* **JWT Bearer Authentication** — Autenticación y autorización basada en tokens
* **Swagger / OpenAPI** — Documentación interactiva de endpoints
* **Arquitectura en Capas** — Separación limpia entre Controladores, Servicios, Repositorios, DTOs y Entidades

---

## 🧩 Módulos y Endpoints Principales

| Módulo | Ruta Base | Descripción |
| :--- | :--- | :--- |
| **Autenticación** | `/api/Auth` | Registro e inicio de sesión con emisión de JWT |
| **Animes** | `/api/Animes` | CRUD de series, sinopsis, año, estado, estudio y mangaka |
| **Categorías** | `/api/Categories` | Clasificación por género y asignación por anime |
| **Sagas y Episodios** | `/api/Sagas`, `/api/Episodes` | Estructura ordenada por arcos argumentales y capítulos |
| **Personajes y Habilidades** | `/api/Characters`, `/api/Abilities` | Fichas de personajes, actores de voz y técnicas |
| **Videos** | `/api/AnimeVideos` | Gestión de Openings, Endings, Trailers y Clips |
| **Comunidad** | `/api/Reviews`, `/api/ForumPosts` | Reseñas con calificación (1–10) e hilos de debate |
| **Usuario** | `/api/Favorites`, `/api/Notifications` | Lista de favoritos y notificaciones de actividad |
| **Catálogos Auxiliares** | `/api/Studios`, `/api/Mangakas` | Gestión de estudios de animación y autores |

---

## 🚀 Instalación y Ejecución Local

### Prerrequisitos
* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* [PostgreSQL 15+](https://www.postgresql.org/)

### Pasos
1. Clonar el repositorio:
   ```bash
   git clone [https://github.com/sigiandre/animehub-api.git](https://github.com/sigiandre/animehub-api.git)
   cd animehub-api

2. Configurar la conexión a PostgreSQL y la clave JWT en appsettings.Development.json:

JSON
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=AnimeHubDb;Username=postgres;Password=TU_PASSWORD"
  },
  "Jwt": {
    "Key": "CLAVE_SECRETA_DE_AL_MENOS_32_CARACTERES",
    "Issuer": "AnimeApp.API",
    "Audience": "AnimeHub.Web"
  }
}

3. Aplicar las migraciones de Entity Framework Core:
dotnet ef database update

5. Ejecutar la aplicación:
dotnet run

6. 👨‍💻 Autor
Sigi Andre Diaz Quiroz — Ingeniero de Software
