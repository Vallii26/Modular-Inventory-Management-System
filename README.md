# Final Project: Modular Inventory Management System

For your final project, you will work together to develop an inventory management application. The system will have the following functionality:

1. Create, View, Update, and Delete individual hardware components
2. Support various DBMS, specifically SQLite3, MondgoDB, and CSV Files
3. Support various Front-ends, specifically Console, WPF, and ASP.NET
4. Automated tests covering the core business rules
5. Documentation for every deliverable

## Business Rules

### Known Requirements

* We need to track the following information about the equipment in the lab and the components inside them
    * Purchase date
    * Expected end-of-life date
    * Installation date
    * Decommissioned date
* We need to know what equipment is near the end of its lifecycle
* The software *must* be easily maintained by future work-study students
* The data *must* be exportable to a standard format (i.e. CSV)

### Unknown Requirements

These requirements should be determined by environment variables at runtime

* We do *not* know what DBMS we will be using
* We do *not* know how the application will be deployed (e.g. web, desktop, console, etc.)


## Team Structure

You will be divided into five teams:

| Team                | Size |
| ------------------- | ---- |
| Business Logic Team | 3    |
| User Interface Team | 3    |
| Database Team       | 3    |
| Testing Team        | 2    |
| Documentation Team  | 2    |
| Project Lead        | 1    |

### Business Logic Team

**Team Members:**

* Emanual Senso (Senso7)
* Jean Blignaut (JeanB)
* Mikel Valladares (mikelValla)

**Core Responsibilities:**

* Create the necessary Entity classes
* Create the core application logic
* Create the interfaces for the adapters to implement

### User Interface Team

**Team Members:**

* Rediet Yonas (redietyonas24)
* Jay Hunt (jrhuntub)
* Jacob Miller (JTMoney1226)

**Core Responsibilities:**

* Implement the input and output interfaces for the following UI environments:
    * Console
    * WPF
    * ASP.NET

### Database Team

**Team Members:**

* Peter Gilbert (pgilbert4377)
* Cameron Shockey (Sh0ck3y)
* Zac Nelson (kickenchicken)

**Core Responsibilities:**

* Implement the database interfaces for the following DBMS:
    * SQLite3
    * MongoDB
    * CSV Files

### Testing Team

**Team Members:**

* Jordon Moore  (JordonMoore)
* Nathan Tshuma (nntshuma)

**Core Responsibilities:**

* Write automated tests to verify all methods and classes
* Create mock implementations of interfaces to use during testing

### Documentation Team

**Team Members:**

* Antonio Medina (almedina2)
* Caleb Fry      (CalebJFry)

**Core Responsibilities:**

* Create and maintain/update the class diagram for the project
* Document the members of each class:
    * Fields
    * Properties
    * Methods
* Audit inline documentation (i.e. comments)

### Project Lead

* Xander Stephens (ahstephens6)

**Core Responsibilities:**

* Compile the final project
* Approve Pull Requests
* Manage the GitHub repository
* Facilitate communication between teams
* Ensures the project runs smoothly

## Timeline

### Phase 1: Planning

1. Assign teams
2. Build an initial class diagram
    1. Start with the Entities
    2. Determine the Use Cases (i.e. what the user does with the program)
    3. Determine the boundary interfaces
3. Create the project in the repository
4. Create a development branch for each team

### Phase 2: Research

**User Interface Team:**

* Research NuGet tools for creating advanced Console applications
* Research Windows Presentation Foundation
* Research ASP.NET

**Database Team:**

* Research Entity Framework Core for SQLite3
* Research the C# MongoDB Driver
* Research NuGet tools for working with CSV files 

**Testing Team:**

* Research C# automated testing frameworks
* Select and learn how to use one

**Project Lead, Business Logic and Documentation Teams:**

* Build the list of business rules
* Continue building out the class diagram
* Create User Stories describing how the user will interact with the application

## Phase 3: Coding

* Write Code
* Write Tests
* Write Documentation
* Repeat until done

## Phase 4: Presentation

* See Deliverables

## GitHub

All project artifacts will be maintained in the Git repository on GitHub. Pull Requests and Issues should be used to manage the project. Commit messages should be descriptive

Pull Requests should be used, specifically, in two scenarios:

1. Before a team's development branch is merged into the main branch
    1. These Pull Requests should be reviewed and approved by the Project Lead and at least one other none team member
    2. Only the Project Lead can merge changes into the main branch
2. When asking a team member to review your code
    1. These Pull Requests do not need to be approved

Issues can be treated like tasks that need to be completed.

## Deliverables

1. The Project (obviously)
2. Documentation
3. Pull Request, Issue, and Commit History
4. Presentation
5. Self-evaluation
6. Peer-evaluation

### Presentation

1. The Project Lead will demonstrate the completed application
2. Each team will reflect on:
    1. Technical concepts learned
    2. Challenges encountered and solutions attempted
    3. Collaboration experiences
3. Each team member will reflect on their:
    1. Most significant contributions
    2. Greatest learning moments
    3. Future growth areas
4. The Project Lead will reflect on:
    1. Team feedback quality
    2. Conflict resolution approaches
    3. Communication effectiveness