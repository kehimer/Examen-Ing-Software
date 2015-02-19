Feature: DominoTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Random Order of the pieces
	Given I have the following pieces in the stack
	| head | tail |
	| 0    | 0    |
	| 0    | 1    |
	| 0    | 2    |
	| 0    | 3    |
	| 0    | 4    |
	| 0    | 5    |
	| 0    | 6    |
	| 1    | 1    |
	| 1    | 2    |
	| 1    | 3    |
	| 1    | 4    |
	| 1    | 5    |
	| 1    | 6    |
	| 2    | 2    |
	| 2    | 3    |
	| 2    | 4    |
	| 2    | 5    |
	| 2    | 6    |
	| 3    | 3    |
	| 3    | 4    |
	| 3    | 5    |
	| 3    | 6    |
	| 4    | 4    |
	| 4    | 5    |
	| 4    | 6    |
	| 5    | 5    |
	| 5    | 6    |
	| 6    | 6    |
	And I have the following seed 1
	When I desorneno las peizas
	Then the result should be
	| head | tail |
	| 1    | 0    |
	| 0    | 1    |
	| 0    | 2    |
	| 0    | 3    |
	| 0    | 4    |
	| 0    | 5    |
	| 0    | 6    |
	| 1    | 1    |
	| 1    | 2    |
	| 1    | 3    |
	| 1    | 4    |
	| 1    | 5    |
	| 1    | 6    |
	| 2    | 2    |
	| 2    | 3    |
	| 2    | 4    |
	| 2    | 5    |
	| 2    | 6    |
	| 3    | 3    |
	| 3    | 4    |
	| 3    | 5    |
	| 3    | 6    |
	| 4    | 4    |
	| 4    | 5    |
	| 4    | 6    |
	| 5    | 5    |
	| 5    | 6    |
	| 6    | 6    |
