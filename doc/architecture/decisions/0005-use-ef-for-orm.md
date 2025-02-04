# 6. Use Entity Framework for our ORM

Date: 2025-02-20

## Status

Accepted

## Context

We need an Object-Relational Mapping (ORM) tool to simplify database interactions in our application. The chosen ORM should support rapid development, provide robust performance, and integrate seamlessly with our chosen backend framework (.NET with ASP.NET). Additionally, it should be familiar to us and easy to use.

## Decision

We have decided to use Entity Framework as our ORM. Entity Framework is a powerful and flexible ORM that integrates seamlessly with .NET and ASP.NET. It supports a wide range of database providers, simplifies data access, and allows for rapid development through its code-first and database-first approaches. Our familiarity with Entity Framework will reduce the learning curve and increase productivity.

## Consequences

By choosing Entity Framework, we ensure that our database interactions are simplified and efficient. The familiarity and ease of use will allow us to manage data access effectively, while the seamless integration with .NET and ASP.NET will streamline our development process. Additionally, the support for various database providers and the flexibility of Entity Framework will accommodate our application's current and future data needs.