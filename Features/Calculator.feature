Feature: Calculator 
Calculator which users can use to calculate numbers and metrics via the folloowing link: https://number-calculator.nakov.repl.co/



Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

	Scenario: Subtract two numbers
	Given the first number is 100
	And the second number is 60
	When the two numbers are subtracted
	Then the result should be 40

	Scenario: Divide two numbers
	Given the first number is 25
	And the second number is 5
	When the two numbers are divided
	Then the result should be 5

	Scenario: Multiply two numbers
	Given the first number is 6
	And the second number is 8
	When the two numbers are multiplied
	Then the result should be 48