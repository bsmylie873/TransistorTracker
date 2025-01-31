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
    LOCATIONS {
        int id PK
        string name
        string address
        timestamp created_date
        timestamp modified_date
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
        string description
        int wattage
        string colour
        date release_date
        timestamp created_date
        timestamp modified_date
        int device_id FK
        int category_id FK
        int condition_id FK
    }
    SOFTWARE {
        int id PK
        string name
        string version
        date release_date
        timestamp created_date
    }
    CATEGORIES {
        int id PK
        string name
        timestamp created_date
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
    CONDITIONS {
        int id PK
        string name
        string description
        timestamp created_date
    }
    USER_TYPES {
        int id PK
        string type_name
        string description
        timestamp created_date
    }

    USERS ||--o{ DEVICES : owns
    USERS ||--|{ LOCATIONS : has
    DEVICES ||--o{ PARTS : has
    DEVICES ||--o{ REVIEWS : receives
    LOCATIONS ||--o{ DEVICES : stores
    PARTS ||--o{ REVIEWS : receives
    PARTS ||--o{ SOFTWARE : supports
    PARTS ||--|{ CATEGORIES : has
    USERS ||--o{ REVIEWS : writes
    CONDITIONS ||--o{ DEVICES : applies
    CONDITIONS ||--o{ PARTS : applies
    USER_TYPES ||--o{ USERS : determines