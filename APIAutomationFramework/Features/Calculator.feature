Feature: Calculator

@TestTag
Scenario: Add two numbers
	#Given the first number is 2
	And the second number is 70
	When the two numbers are added
	Then the result should be 120