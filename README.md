 ![license](https://img.shields.io/github/license/zrusev/ddd-architecture.svg) ![size](https://img.shields.io/github/repo-size/zrusev/ddd-architecture.svg) ![last commit](https://img.shields.io/github/last-commit/zrusev/ddd-architecture.svg)

# Domain-Driven Design Architecture Project: Time-Off Manager
Time-Off Manager is a domain-driven web API for managing employee absences.
When a user submits a request, it is marked for approval.
If an approval is performed, the system reduces the user's leave balance accordingly.
When many requests are submitted for the same day, the latest one approved is considered effective. 

### Features:
+ Ability to submit, approve, reject requests
+ Customizable request types
+ Current balance visualization
+ Ability to submit partial day hours
+ Group users to teams
+ Define user groups by manager
+ Automatically workdays calculation excluding weekends and holidays
+ Manageable public holidays list
+ Reporting functionality
+ Automatic e-mail notifications of requests, approvals and rejections

### Architecture:
- Bounded Contexts
- Separation of Concerns
- Encapsulation
- Dependency Inversion
- Explicit Components
- Single Responsability
- Persistence & Infrastructure ignorance
- Presentation ignorance

### Entrypoints:
- API served @https://localhost:5001
- [Import](https://learning.postman.com/docs/getting-started/importing-and-exporting-data/#importing-data-into-postman) Postman's [collection](https://github.com/zrusev/ddd-architecture/blob/master/TimeOffManager.postman_collection.json) to access the provided endpoints