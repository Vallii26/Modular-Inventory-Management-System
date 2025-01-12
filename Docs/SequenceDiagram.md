```mermaid
sequenceDiagram
    Interface->>+Business Logic: Call Method for data
    Business Logic->>+Data Base: Ask for data from DB
    Data Base-->>-Business Logic: Return Data
    Business Logic-->>-Interface: Return Data
```
