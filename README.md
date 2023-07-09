# TestmonitorTests
## Tests checklist 
UI Tests
- Positive:
    - Verify input Name on boundary values (0, 1, 101, 102 symbols);
    - Verify that pop up message is displayed after creating project;
    - Verify creation project;
    - Verify deletion of project;
    - Verify that dialog window Create Project is displayed;
    - Verify that file is uploaded on the issue page.
 - Negative:
    - Verify that user can't login with invalid credentials;
    - Verify that dialog window Create Project is closed (artificial bug);

API Tests
- Verify that GET https://mydomain.testmonitor.com/api/v1/projects/{projectId} Request returns correct response with project parameters
- Verify that GET https://mydomain.testmonitor.com/api/v1/projects/{projectId} with invalid projectId Request returns correct response and errore message
- Verify that POST https://mydomain.testmonitor.com/api/v1/projects with valid Body Request returns correct response with created Project parameters
- Verify that POST https://mydomain.testmonitor.com/api/v1/projects with invalid Body (without 1 required parameter) Request returns correct response and errore message
 
