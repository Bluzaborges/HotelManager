@RoomValue
Feature: UpdateRoomValue
	In order to change the value of a room value
	As a admin
	I want to update the room value

Background:
	Given these room values
		| Number | Type         | Name         | Value  |
		| 1      | Deluxe       | Luxo         | 150.00 |
		| 2      | Conventional | Convencional | 98.00  |
	And these rooms
		| Code | RoomValue | Deleted |
		| 1A   | 1         | False   |
		| 2A   | 1         | True    |
		| 1B   | 2         | False   |
		| 2B   | 2         | False   |
		| 3B   | 2         | True    |

Scenario: Update room value
	Given I update the value of the "Conventional" room value to 110.35
	And the name to "Exclusivo"
	When I update the room value
	Then the room values should be
		| Number | Value  |
		| 1      | 150.00 |
		| 2      | 110.35 |