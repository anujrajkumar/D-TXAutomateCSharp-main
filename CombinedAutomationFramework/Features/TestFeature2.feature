Feature: This is test feature2

@tag1
Scenario: This is a test scenario1
	Given This is a prerequisite step where read "TestData1" from sheet "Login" in excel
	When This is a condition step for reading for "TestData2" data

@tag1
Scenario: This is a test scenario2
	Given This is a prerequisite step to test set of data:
		| TestData		  | SheetName |
		| TestData1       | Login    |
		| TestData2       | Login    |