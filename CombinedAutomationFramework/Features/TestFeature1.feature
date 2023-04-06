Feature: This is test feature1

@Special
Scenario Outline: Verify that scenario runs for all data examples.
	Given Read data from sheet '<SheetName>' in excel
	And Navigate to application URL using data '<TestData>'
	And Navigate to login page
	When Entering login credential from '<TestData>'
	And Click on login button
	Then Validating the login status

Examples:
	| TestData  | SheetName |
	| TestData1 | Login    |
	| TestData2 | Login    |