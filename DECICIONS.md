# DECISIONS.md

## 1. What did AI generate for you, and what did you write or modify yourself?

I used AI as a coding assistant rather than having it build the whole project.

For the backend, AI helped generate repetitive code such as the entity classes, DTOs, and model definitions where there was little business logic involved. I wrote and integrated the application logic myself, including the Clean Architecture layers, repositories, services, API endpoints, validation, JWT authentication, and Entity Framework configuration. I also reviewed the generated code and adjusted it to match the project's requirements.

For the frontend, AI assisted with creating the initial models and some component scaffolding. I implemented the API integration, routing, filtering, navigation between pages, and adapted the frontend to match the actual responses returned by my backend. I also organized the project structure and refined the generated code where necessary.

---

## 2. What security issues did you find (or introduce) in the AI-generated code? How did you handle them?

The generated code was a useful starting point, but it did not include all of the security measures required for the project.

I secured the protected endpoints using JWT authentication and verified that only authenticated users could access them. I also added request validation to prevent invalid data from reaching the application and returned meaningful validation responses to the client. In addition, I configured CORS so that the frontend application could communicate safely with the backend during development.

Before using any generated code, I reviewed it manually to ensure it matched the application's architecture and security requirements.

---

## 3. One thing the AI got wrong that you had to fix. What was it and why was it wrong?

One issue was with the frontend models. The initial generated models assumed a different API response than the one implemented in my backend. For example, the track list expected a nested `artist` object, while my API returns a simple `artistName` property. The track details response also has a different structure than the track list response.

I updated the frontend models and service layer to match the actual API contracts instead of relying on assumptions. This ensured that the application displayed the correct data and avoided runtime mapping issues.
