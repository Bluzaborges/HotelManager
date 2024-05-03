@RoomValue
Feature: GetAllRoomValues
	In order to view all room values
	As a admin
	I want to get all room values

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

Scenario: Get all room values
	Given all room values
	When I perform the action of getting all room values
	Then the rooms values listed must be
		| Number | RoomsCount |
		| 1      | 1          |
		| 2      | 2          |