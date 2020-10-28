@dashboard
Feature: Search
    AS A USER OF THE SEARCH ENGINE
    I SHOULD BE ABLE TO SEARCH FOR TERMS


    @search
    Scenario Template: Search For Terms
        Given   I NAVIGATE TO THE DASHBOARD
        And     I CONFIRM THAT THE PAGE TITLE CONTAINS "WebOasis"
        When    I ENTER THE TEXT "<TERM>" IN THE SEARCH BAR
        Then    THE TEXT IN THE SEARCH BAR SHOULD BE "<TERM>"

        @terms
        Scenarios:
        | TERM  |
        | FOO   |
        | BAR   |
