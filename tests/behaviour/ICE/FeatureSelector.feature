Feature: FeatureSelector
	In order to put next task into the todo list
	As a project manager
	I want to find the most ICE score valued features amongst a list

Scenario: Empty list
	Given empty list
	When searching for the most valued feature
	Then exception raised

Scenario: Single feature in list
	Given list with a single feature
	When searching for the most valued feature
	Then this task is selected

Scenario: Multiple features in list
	Given list contains multiple features
	When searching for the most valued feature
	Then the most valued feature is selected

Scenario: Multiple features with few having same score in list
	Given list contains multiple features with few having the same score
	When searching for the most valued feature
	Then first of the most valued features is selected

Scenario:  Multiple features first
	Given list contains multiple features with the most on the first position
	When searching for the most valued feature
	Then first feature is returned

Scenario:  Multiple features last
	Given list contains multiple features with the most on the last position
	When searching for the most valued feature
	Then last feature is returned