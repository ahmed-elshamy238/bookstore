## Code Generation
- Prefer asynchronous functions over synchronous functions
- Use N-tier architecture
- Use EF Core for data access layer
- Implement repository, unit of work and specification patterns with in-memory database
- Use dependency injection for services
- Install any required packages
- Remove any unnecessary files
- Each file should contain only one class, interface, ...etc with the same file name
- Provide a json file for each entity for data seeding with some dummy data
- Each command you execute should do only one thing
- Maintain a descriptive folder structure
- Don't create a new solution

## Naming Conventions
- Use PascalCase for functions and classes
- Use camelCase for variables
- Use UPPER_SNAKE_CASE for constants
- Prefix private class members with underscore (_)
- Suffix asynchronous functions with "Async"

## Coding Style
- Use 4 spaces for indentation
- Use XML Documentation comments
- Use fat arrow when possible
- Use "var" for long data types and collections
- Leave a blank line between functions

## API Design
- Avoid business logic in controllers
- Use role-based authorization
- Enable CORS
- Expose databse models as DTOs
- Keep sensitive data in appsettings.json file
- Use JWT Token for authentication
- Validate all user inputs
- Maintain a short, concise URL
- Consider API Versioning
- Use in-memory caching
- Seed data at startup

## Error Handling
- Use try/catch blocks
- Implement error handling middleware
- Always log errors with contextual information in console
- Use custom error types and unify the error response in the following format:
  (status code - error type - description)

## Testing
- Mock dependencies with Moq
- Test cases should have descriptive names including expected and actual results
- Test cases should make only one assertion and follow single responsibility principle

## N-tier Architecture:
- Data Access Layer: for database entities 
- Business Logic Layer: for services and DTOs (references DAL)
- Presentations Layer: for controllers (references BLL)
- Each Layer is in a separate project
- Use .NET 8.0 and Swagger for documentation
- Unit tests should be in a separate project using XUnit
- Write test cases for each layer in a separate folder