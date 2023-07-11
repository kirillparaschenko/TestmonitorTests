# TestmonitorTests
## Tests checklist 
UI Tests
- Positive:
    - Verify input Project Name on boundary values (1, 100, 101 symbols);
    - Verify that pop up message is displayed after creating project;
    - Verify creation project;
    - Verify deletion of project;
    - Verify that dialog window Add Requirement is displayed.
 - Negative:
    - Verify that user can't login with invalid credentials;
    - тест на ввод данных превышающих допустимые;
    - Verify that Test suite is removed;

API Tests
- Verify that GET https://mydomain.testmonitor.com/api/v1/projects/{projectId} Request returns correct response with project parameters
- Verify that GET https://mydomain.testmonitor.com/api/v1/requirements/{requirementId} Request returns correct response with requirement parameters
- Verify that GET https://mydomain.testmonitor.com/api/v1/test-suites/{testSuiteId}} Request returns correct response with test suite parameters
- Verify that Test case is created after request POST https://mydomain.testmonitor.com/api/v1/test-cases 
 
