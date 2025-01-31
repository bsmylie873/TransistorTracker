# Transistor Tracker
A document to track personal hardware devices and their specifications, compatibility, and other relevant details.
## Problem Definition
With an increasing number of devices such as personal computers, peripherals, and gaming consoles, it becomes difficult to track their specifications, operating system compatibility, and software restrictions. This document serves as a structured way to record and manage hardware details for easy reference.
## Priorities
### Must Have
- A user must be able to login and logout
- A user must be able to create a new account
- A user must be able to list personal hardware devices and categorise them
- Each device should have relevant specifications recorded
- Compatibility with operating systems and software should be noted
- Ability to track whether the device is still in use, retired, partially defective or defective
- Option to add custom notes per device
### Should Have
- Shareable hardware lists
- Search filters for device types, OS compatibility, or status (active/retired/partially defective/defective)
### Could Have
- Ability to track warranty and purchase details
- Record of past upgrades (e.g., RAM, SSD upgrades)
- Maintenance history (e.g., repairs, replacements)
- Password reset
### Will Not Have
- Automatic hardware detection or monitoring
## Domain Model Diagram
```mermaid
%%{init: {'theme':'default'}}%%
erDiagram
    CATEGORIES ||--|{ PARTS : has
    DEVICES ||--o{ PARTS : has
    DEVICES ||--o{ REVIEWS : receives
    LOCATIONS ||--o{ DEVICES : stores
    PARTS ||--o{ REVIEWS : receives
    PARTS ||--o{ SOFTWARE : supports
    USERS ||--|{ LOCATIONS : has
    USERS ||--o{ DEVICES : owns
    USERS ||--o{ REVIEWS : writes
``````