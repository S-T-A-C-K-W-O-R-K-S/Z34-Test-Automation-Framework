﻿@ui
Feature: Login
	IN ORDER TO ACCESS MY ACCOUNT
	AS A USER OF THE APPLICATION
	I SHOULD BE ABLE TO LOG IN WITH MY EMAIL ADDRESS AND PASSWORD


	@authentication
	Scenario: Assert Login With Valid Credentials From A BDD Table
		Given   I HAVE NAVIGATED TO THE LOGIN PAGE
		And     I CONFIRM THAT THE LOGIN FORM IS DISPLAYED
		When    I ENTER A RANDOM EMAIL ADDRESS AND PASSWORD FROM A BDD TABLE

				| EMAIL                   | PASSWORD  |
				| localhost@microsoft.com | syspass   |
				| root@ubuntu.org         | sudologin |
				| admin@stackworks.online | letmein   |

		And     I CHOOSE TO REMEMBER MY CREDENTIALS
		And     I CLICK THE LOGIN BUTTON
		Then    I SHOULD BE REDIRECTED TO THE DASHBOARD
		And     I SHOULD BE AUTHENTICATED AS THE USER "VALERIE LUNA"


	@authentication
	Scenario: Assert Login With Valid Credentials From A Spreadsheet
		Given   I HAVE NAVIGATED TO THE LOGIN PAGE
		And     I CONFIRM THAT THE LOGIN FORM IS DISPLAYED
		When    I ENTER A RANDOM EMAIL ADDRESS AND PASSWORD FROM A SPREADSHEET
		And     I CHOOSE TO REMEMBER MY CREDENTIALS
		And     I CLICK THE LOGIN BUTTON
		Then    I SHOULD BE REDIRECTED TO THE DASHBOARD
		And     I SHOULD BE AUTHENTICATED AS THE USER "VALERIE LUNA"
