@chrome
Feature: SignUpFeature
	In order to only register users for facebook
	As a tester
	I want to verify sign up feature

Scenario Outline: Sign Up for facebook using random data
	Given I open Sign Up page
	And I enter the randomly generated <test> firstname 
	And  I enter the randomly generated <test> surname
	And  I enter the randomly generated <test> email
	And  I enter the randomly generated <test> password
	And  I enter the randomly generated <test> birthday
	And  I enter the randomly generated <test> gender
	When I click on Sign Up button
	Then New user should be signed up successfully
	Examples: 
	| test    |
	| valid   |
#	| invalid |
