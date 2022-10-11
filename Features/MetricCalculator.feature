Feature: MetricCalculator 
Calculator which users can use to calculate numbers and metrics via the folloowing link: https://number-calculator.nakov.repl.co/



Scenario: Convert meters to centimeters
	Given input value is 10
	And the source metric is "m"
	And the destination metric is "cm"
	When the conversion is performed
	Then the result should be 1000

	Scenario: Convert kilometers to meters
	Given input value is 321
	And the source metric is "km"
	And the destination metric is "m"
	When the conversion is performed
	Then the result should be 321000

	Scenario: Convert kilometers to milimeters
	Given input value is 2
	And the source metric is "km"
	And the destination metric is "mm"
	When the conversion is performed
	Then the result should be 2000000

	Scenario: Invalid Input
	Given input value is abv
	And the source metric is "km"
	And the destination metric is "mm"
	When the conversion is performed
	Then the result should be invalid input