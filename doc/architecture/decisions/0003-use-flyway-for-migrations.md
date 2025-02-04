# 3. Use Flyway for our migrations

Date: 2025-02-04

## Status

Accepted

## Context

We need a reliable and efficient tool to manage database migrations. The chosen tool should support version control for our database schema, ensure consistency across different environments, and integrate seamlessly with our development workflow. Additionally, it should be easy to use and familiar to us.

## Decision

We have decided to use Flyway for our database migrations. Flyway is an open-source database migration tool that supports version control for database schemas. It offers a simple and intuitive interface, ensures consistency across environments, integrates well with our development tools and CI/CD pipelines, and is supported by a large community. Our familiarity with Flyway will reduce the learning curve and increase productivity.

## Consequences

By choosing Flyway, we ensure that our database migrations are managed efficiently and consistently. The familiarity and ease of use will allow us to handle migrations effectively, while the integration with our development tools will streamline our workflow. Additionally, the community support will help us address any issues that may arise and adopt best practices for database migration management.