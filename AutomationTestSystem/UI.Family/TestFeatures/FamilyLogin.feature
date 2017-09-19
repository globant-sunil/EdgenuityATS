Feature: FamilyLogin
	In order to check Family Login process
	As a Family role
	I want to login in Family Portal 
@mytag
Scenario: Succesfull Family login and logout
	Given Go to QA_Family appication Portal
	When Login using r01autoparent1@gmail.com and x credentials
	Then validate that the user was successfully logged into Family
	And user clicks on signout buttton
	And validate that user is successfully signed out
