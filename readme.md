# Hotel Backend Application

## Information

Simple hotel backend application based on .NET Core 8 created as a course application for university.

## Running the app

This application uses Docker and Docker Compose which helps with building and running the app with dependencies such as PostgreSQL16 database.<br>
```bash
# run entire application
docker-compose up --build

# run database without API
docker-compose up database
```