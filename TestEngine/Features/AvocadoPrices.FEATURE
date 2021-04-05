@End-To-End
Feature: Avocado Prices
    AS A REGISTERED QUERY HUB USER
    I SHOULD BE ABLE TO INGEST AVOCADO PRICES DATA
    AND THEN VISUALISE THE DATA IN A ZEPPELIN NOTEBOOK


    Scenario: [01/07] Log Into Query Hub
        Given   I NAVIGATE TO THE LOGIN PAGE
        And     I CONFIRM THAT THE PAGE TITLE IS "Sign in to Keycloak"
        When    I LOG IN WITH CREDENTIALS FROM A TABLE

                    | USERNAME      | PASSWORD      |
                    | qhautomation  | zaq12wsx!!    |

        Then    I CONFIRM THAT I AM LOGGED IN AS THE SELECTED USER

    Scenario: [02/07] Upload Metadata
        Given   I NAVIGATE TO THE METADATA UPLOAD PAGE
        And     I CONFIRM THAT THE METADATA UPLOAD SOURCE IS LOCAL
        And     I CONFIRM THAT NO WARNING NOTIFICATIONS EXIST
        When    I SELECT THE "Load Metadata" METADATA WORKFLOW
        And     I STAGE ALL AVOCADO PRICES METADATA FILES FOR UPLOAD
        And     I CLICK THE UPLOAD METADATA BUTTON
        Then    I CONFIRM THAT ALL METADATA FILES HAVE UPLOADED

    Scenario: [03/07] Validate Metadata
        Given   I NAVIGATE TO THE STAGING AREA
        When    I CLICK THE VALIDATE BUTTON
        And     I CONFIRM THAT ALL STAGED OBJECTS HAVE BEEN VALIDATED
        And     I CLICK THE PUBLISH BUTTON
        Then    I CONFIRM THAT ALL STAGED OBJECTS HAVE BEEN PUBLISHED

    Scenario: [04/07] Upload Data
        Given   I NAVIGATE TO THE DATA UPLOAD PAGE
        And     I CONFIRM THAT THE DATA UPLOAD SOURCE IS LOCAL
        When    I SELECT THE "Avocado Prices" DATA WORKFLOW
        And     I STAGE ALL AVOCADO PRICES DATA FILES FOR UPLOAD
        And     I CLICK THE UPLOAD DATA BUTTON
        Then    I CONFIRM THAT ALL DATA FILES HAVE UPLOADED

    Scenario: [05/07] Validate Data
        Given   I NAVIGATE TO THE IN-BASKET
        And     I CONFIRM THAT A BATCH OF TYPE "Avocado Prices" EXISTS
        Then    I CONFIRM THAT THE BATCH "Avocado Prices" COMPLETED WITH NO STEP ERRORS

    Scenario: [06/07] Import Zeppelin Notebook
        Given   I NAVIGATE TO ZEPPELIN
        And     I CONFIRM THAT I AM LOGGED INTO ZEPPELIN AS THE SELECTED USER
        When    I IMPORT THE "Avocado Prices" NOTEBOOK
        Then    I CONFIRM THAT THE "Avocado Prices" NOTEBOOK HAS BEEN IMPORTED

    Scenario: [07/07] Visualise Data In Zeppelin
        Given   I AM ON THE PAGE WITH THE TITLE "Zeppelin"
        When    I OPEN THE "Avocado Prices" NOTEBOOK
        And     I RUN ALL NOTEBOOK PARAGRAPHS
        Then    I CONFIRM THAT ALL PARAGRAPHS HAVE EXECUTED SUCCESSFULLY
