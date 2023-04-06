Feature: Amazon Features for Demo

@Amazon
Scenario Outline: Verify Amazon login scenario for invalid credentials
	Given Read data from sheet '<SheetName>' in excel
	And Navigate to application URL using data '<TestData>'
	And Navigate to Amazon login page
	When Entering Amazon login credential from '<TestData>'
	And Click on continue button
	When Entering Amazon login credential password from '<TestData>'
	And Click amazon login button
	Then Validating the amazon login status

Examples:
	| TestData  | SheetName |
	| AmazonData1 | Login    |
