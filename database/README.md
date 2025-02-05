# Database Approach

We have adopted a relational database approach for our application. This approach involves organizing data into tables with defined relationships between them. Each table represents an entity, and the relationships between these entities are established using foreign keys. This structure allows for efficient data management, integrity, and retrieval.

Our database schema is designed to minimize redundancy and dependency by organizing data into related tables, a process known as normalization. We use an Entity-Relationship (ER) diagram to visually represent the database structure, showing entities, their attributes, and the relationships between them. Each table has a primary key that uniquely identifies each record, and relationships between tables are established using foreign keys, ensuring referential integrity.

The relational model supports scalability, allowing us to handle growing amounts of data efficiently. Additionally, the schema can be modified and extended as the application evolves, accommodating new requirements and features. This approach ensures that our data is well-structured, consistent, and easily accessible, supporting the overall functionality and performance of the application.

## Migrations

In order to manage the state of the database, we use a database migration tool called Flyway. This tool allows us to execute specifically named migration scripts so we can control the ordering of migrations to be applied and what the database migration specifically output.

## Local Data Seed

As we develop & test locally and we repeatedly require predicatable data within our database for verification, we employ a local data seed approach for each of our databases. These tables are design to add data throughout the database so we have workouts, exercises, users, participations etc available locally as soon as we spin up the database.

NOTE: An important consideration is that we absolutely do not apply the local data seed migrations to any remote databases, they are purely for location verifications and test executions.

# Local Execution

## With Docker
We can run `docker compose up` from the root directory to spin up a database instance.

## Without Docker
In order the run the database locally you need at a minumum:

- postgres 14

- flyway

### database creation
- add a `transistor-tracker` database onto your server.
- run the command `flyway -url=jdbc:postgresql://localhost/transistor-tracker -schemas=master -user=transistor-tracker -password=password1 -connectRetries=5 migrate`


## Entity-Relationship Diagram

```mermaid
%%{init: {'theme':'forest'}}%%
erDiagram
    USERS {
        int id PK
        string name
        string email
        timestamp created_date
        timestamp modified_date
        int user_type_id FK
    }
    USER_TYPES {
        int id PK
        string type_name
    }
    HARDWARE_STATUSES {
        int id PK
        string name
    }
    HARDWARE_CONDITIONS {
        int id PK
        string name
    }
    LOCATIONS {
        int id PK
        string name
        string avatar
        string house_number
        string street
        string city
        string state
        string postal_code
        string country
        timestamp created_date
        timestamp modified_date
        int user_id FK
    }
    DEVICES {
        int id PK
        string name
        string model
        int wattage
        string colour
        bool wireless
        date release_date
        timestamp created_date
        timestamp modified_date
        int user_id FK
        int location_id FK
        int condition_id FK
    }
    PARTS {
        int id PK
        string name
        string avatar
        string description
        int wattage
        string colour
        date release_date
        timestamp created_date
        timestamp modified_date
        int device_id FK
        int user_id FK
        int location_id FK
        int category_id FK
        int condition_id FK
        int status_id FK
    }
    SOFTWARE {
        int id PK
        string name
        string avatar
        string version
        date release_date
        int category_id FK
    }
    SOFTWARE_CATEGORIES {
        int id PK
        string name
    }
    SOFTWARE_COMPATIBILITY_LEVELS {
        int id PK
        string name
        string description
    }
    SOFTWARE_COMPATIBILITIES {
        int id PK
        int software_id FK
        int part_id FK
        int device_id FK
        int software_compatibility_level_id FK
    }
    PARTS_CATEGORIES {
        int id PK
        string name
    }
    DEVICES_CATEGORIES {
        int id PK
        string name
    }
    REVIEWS {
        int id PK
        string review_text
        int rating
        timestamp created_date
        timestamp modified_date
        int user_id FK
        int device_id FK
        int part_id FK
    }

    USERS ||--o{ DEVICES : owns
    USERS ||--o{ PARTS : owns
    USERS ||--|{ LOCATIONS : has
    USERS ||--o{ REVIEWS : writes
    USER_TYPES ||--o{ USERS : determines
    LOCATIONS ||--o{ DEVICES : stores
    LOCATIONS ||--o{ PARTS : stores
    DEVICES ||--o{ PARTS : has
    DEVICES ||--o{ REVIEWS : receives
    DEVICES ||--o{ SOFTWARE_COMPATIBILITIES : has
    DEVICES_CATEGORIES ||--o{ DEVICES : defines
    PARTS ||--o{ REVIEWS : receives
    PARTS ||--o{ SOFTWARE_COMPATIBILITIES : has
    PARTS_CATEGORIES ||--o{ PARTS : defines
    HARDWARE_CONDITIONS ||--o{ DEVICES : applies
    HARDWARE_CONDITIONS ||--o{ PARTS : applies
    HARDWARE_STATUSES ||--o{ DEVICES : applies
    HARDWARE_STATUSES ||--o{ PARTS : applies
    SOFTWARE_CATEGORIES ||--o{ SOFTWARE : defines
    SOFTWARE ||--o{ SOFTWARE_COMPATIBILITIES : has
    SOFTWARE_COMPATIBILITY_LEVELS ||--o{ SOFTWARE_COMPATIBILITIES : defines