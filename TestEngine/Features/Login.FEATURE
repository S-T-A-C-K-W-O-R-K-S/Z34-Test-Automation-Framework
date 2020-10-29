@auth
Feature: Login
    AS A REGISTERED QUERY HUB USER
    I SHOULD BE ABLE TO LOG INTO THE APPLICATION
    AND LAND ON THE HOME PAGE


    @login
    Scenario: Log Into Query Hub
        Given   I NAVIGATE TO THE LOGIN PAGE
        And     I CONFIRM THAT THE PAGE TITLE IS "Query Hub"
        When    I LOG IN WITH CREDENTIALS FROM A BDD TABLE

                    | USERNAME  | PASSWORD  |
                    | ...       | ...       |

        And     I CONFIRM THAT THE PAGE TITLE IS "Query Hub | Query Hub"
        Then    I TRIGGER A JAVASCRIPT ALERT WITH A MESSAGE
