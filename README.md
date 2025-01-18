### **PickAPod**

PickAPod is a scalable microservices-based web application that allows users to explore NASA's Astronomy Picture of the Day (APOD), like their favorite photos, and manage their accounts. 

This project showcases best practices in full-stack development, including:

- API-first architecture
- Containerized deployment using Docker
- Asynchronous logging with RabbitMQ
- SQL database integration for data persistence


**Features**

- Explore NASA's Astronomy Picture of the Day (APOD)
- Browse previous APODs
- Like and manage favorite photos
- User account creation and management
- Structured logging for user actions and system events
- Scalable microservice architecture


**Future Enhancements**
- Add analytics for user activity
- Implement email verification for user registration
- Explore distributed database for scalability
- Enhance caching stategies for NASA APOD responses

**Project Architecture**

PickAPod is designed as a collection on independently deployable microservices:

- **Frontend:** Built with React and TypeScript for a dynamic, user-friendly interface.
- **Backend:** 
      - **Photo Service:** Handles fetching and caching NASA APOD data.
      - **User Management Service:** Manages user authentication and account operations.
      - **Favorites Service:** Tracks and manages user-liked photos.
      - **Logging Service:** Consumes logs asynchronously from other services.

- **Database:** PostgresSQL stores user accounts, liked photos, and cached APOD data.
- **API Gateway:** Routes client requests to appropriate microservices.
- **Message Broker:** RabbitMQ for decoupled logging.


**Tech Stack**
**Frontend:** React, Typescript, CSS/SCSS
**Backend:** ASP.NET Core Web API, Entity Framework Core, Serilog, RabbitMQ
**Database:** PostgreSQL
**Deployment** Docker, Docker Compose, Free-tier hosting solutions (Render, Railway, Vercel)


**Getting Started**

Ensure the following tools are installed on your system:
- Docker
- Node.js
- .NET SDK
- PostgreSQL
