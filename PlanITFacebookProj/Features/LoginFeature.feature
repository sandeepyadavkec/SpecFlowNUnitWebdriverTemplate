@chrome
Feature: LoginFeature
	In order to only allow authenticated users to log in
	As a tester
	I want to verify login feature

Scenario Outline: Login
	Given I have entered username '<username>' and password '<password>'
	When I login
	Then I should be informed that login '<result>'

	Examples: 
	| testing               | username				 | password             | result   |
	| valid combination     | ss1444121@gmail.com    | ss@1984               | passed   |
	| invalid combination 1 | test					 | test                 | failed   |
	#| special characters    | $$$      | SuperSecretPassword! | failed   |