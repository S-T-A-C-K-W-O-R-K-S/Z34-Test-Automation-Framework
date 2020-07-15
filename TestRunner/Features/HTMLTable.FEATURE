@ui
Feature: HTML Table
	AS A USER OF THE APPLICATION
	I SHOULD BE ABLE TO READ DATA FROM THE DATA TABLE


	Background: Be Logged In And On The Landing Page
		Given   I AM LOGGED IN AND ON THE LANDING PAGE
		Then    I SHOULD BE AUTHENTICATED AS THE USER "VALERIE LUNA"


	@database
	Scenario Template: Confirm Staff Details From The HTML Data Table