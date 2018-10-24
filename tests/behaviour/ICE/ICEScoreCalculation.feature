Feature: ICEScoreCalculation
	In order to understand feature's comparable value
	As a project manager
	I want to know it's calculated ICE score

Scenario: Calculate ICE score for feature 1
	Given having a feature
	When feature's impact equals 7
	And feature's confidence equals 2
	And feature's ease equals 8
	Then the score should be 112

Scenario: Calculate ICE score for feature 2
	Given having a feature
	When feature's impact equals 5
	And feature's confidence equals 5
	And feature's ease equals 3
	Then the score should be 75

Scenario: Calculate ICE score for feature 3
	Given having a feature
	When feature's impact equals 8
	And feature's confidence equals 1
	And feature's ease equals 5
	Then the score should be 40

Scenario: Calculate ICE score for feature 4
	Given having a feature
	When feature's impact equals 1
	And feature's confidence equals 4
	And feature's ease equals 3
	Then the score should be 12