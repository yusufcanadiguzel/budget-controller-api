# Budget Controller Api

This is the final project for Patika+ Back-End Program. 

Used technologies used in the project. They are:

- C#
- ASP.NET Web Api

Used tools and frameworks used in the project.

- Entity Framework Core
- AutoMapper
- Autofac
- JWT

## Purpose

This project is designed to help users keep track of their expenses effectively. The API facilitates 
managing essential entities such as expenses, stores, products, and receipts, enabling CRUD 
operations with validation through DTOs. Users can monitor spending across various stores and track 
where specific products are available and at what prices. The application architecture is organized 
into distinct layers and ensuring clean separation of concerns and maintainability. Dependency 
Injection is implemented using Autofac for modularity, and Entity Framework Core is used for 
database operations and migrations. Basic authentication and input validation are implemented to 
secure data integrity and control access to endpoints.

## About Features

### Architecture
  
Clean Architecture is used in this project to ensure a clear separation of concerns, maintainability, and testability. By organizing the code into independent layers, such as Presentation, Business, Data Access, and WebApi, it becomes easier to modify or extend each part without affecting the others. This approach also enhances the project's scalability and flexibility, making it adaptable to future requirements and technology changes.

### IoC Container

Autofac is used as the IoC (Inversion of Control) container in this project to manage dependency injection efficiently. By leveraging Autofac, dependencies are automatically resolved, making the codebase more modular, maintainable, and testable. This approach also reduces tight coupling between components, allowing for easier substitution and configuration of services across different layers of the application.

### Logging

NLog is used in this project to implement efficient and flexible logging. With NLog, we can easily track application events, errors, and performance metrics, which aids in debugging and monitoring. NLog's configurability allows for logging to various outputs (e.g., files, databases, and consoles), making it a reliable tool for maintaining application stability and diagnosing issues in production environments.

### Exception Handling

Global error handling is implemented using HTTP handlers to ensure a consistent and centralized way of managing exceptions across the application. This approach captures unhandled exceptions and returns standardized error responses, improving the API's reliability and user experience. By handling errors at a global level, we can reduce repetitive error-checking code and focus on a clean, maintainable codebase.

### Mapping

AutoMapper is used in this project to simplify object-to-object mapping, particularly for converting entities to DTOs and vice versa. By automating the mapping process, AutoMapper reduces boilerplate code, improves readability, and minimizes the risk of manual mapping errors. This approach enhances productivity and maintains a clean separation between different layers of the application.

### Validation

Validation is implemented using data annotations on DTOs to ensure data integrity and enforce business rules at the boundary of the API. By applying validation directly to DTOs, we prevent invalid data from reaching the business logic layer, which improves security and reliability. This approach keeps validation rules close to the data model, enhancing code readability and maintainability.

### Cross Cutting Concerns

Logging and validation are implemented using action filters on controllers to provide a centralized and reusable approach to cross-cutting concerns. By utilizing action filters, we can handle logging and validation consistently across all endpoints without cluttering the business logic. This approach enhances code cleanliness, reduces duplication, and ensures that logging and validation are applied uniformly across the application.

### User Management

Microsoft Identity and JWT are used in this project to implement secure and scalable user management and authentication. Microsoft Identity provides a robust framework for managing user accounts, roles, and authentication flows, while JWT allows for stateless authentication by issuing tokens. This combination enhances security and performance, making it easy to authenticate users and manage permissions across the application.

### Pagination

Pagination is implemented in this project to efficiently manage large data sets and improve response times. By fetching and displaying data in smaller, manageable chunks, pagination reduces server load and enhances user experience. This approach not only optimizes performance but also provides a more user-friendly way for clients to navigate through extensive lists of data.

## Upcoming Features

- Caching
- Transaction
- More Detailed Queries
  
