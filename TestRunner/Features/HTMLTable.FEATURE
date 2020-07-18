@ui
Feature: HTML Table
	AS A USER OF THE APPLICATION
	I SHOULD BE ABLE TO READ DATA FROM HTML TABLES


	Background: Be Logged In And On The Landing Page
		Given   I AM LOGGED IN AND ON THE LANDING PAGE
		Then    I SHOULD BE AUTHENTICATED AS THE USER "VALERIE LUNA"


	@database
	Scenario Template: Confirm Staff Details From The HTML Data Table
		Given   I NAVIGATE TO THE TABLES PAGE
		And     CONFIRM THAT THE TABLE IS DISPLAYED ON THE PAGE
		When    I NAVIGATE TO TABLE <TAB>
		Then    STAFF MEMBER <NAME> SHOULD HAVE <POSITION>

	Examples:
		| TAB | NAME               | POSITION               |
		| 1   | Brielle Williamson | Integration Specialist |
		| 3   | Jenette Caldwell   | Development Lead       |
		| 5   | Serge Baldwin      | Data Coordinator       |
