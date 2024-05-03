@Reservation
Feature: AddReservation
	In order to enjoy my vacation
	As a user
	I would like to book a luxury room

Background:
	Given these room values
		| Number | Type         | Name         | Value  |
		| 1      | Deluxe       | Luxo         | 150.00 |
		| 2      | Conventional | Convencional | 98.00  |
	And these rooms
		| Code | RoomValue | Deleted |
		| 1A   | 1         | False   |
		| 2A   | 1         | False   |
		| 1B   | 2         | False   |
		| 2B   | 2         | False   |
		| 3B   | 2         | False   |
	And these registered users
		| Name  | Email           | Password | Role      | Cpf         | Phone       | Fine   | Blocked |
		| Josh  | josh@gmail.com  | 1234     | Admin     | 77890464037 | 54926418694 | 0.00   | False   |
		| John  | john@gmail.com  | 1234     | Customer  | 70173805094 | 54927299016 | 0.00   | False   |
		| Jim   | jim@gmail.com   | 1234     | Customer  | 53720760030 | 51928657841 | 0.00   | False   |
		| Peter | peter@gmail.com | 1234     | Customer  | 27471571055 | 55931641434 | 0.00   | False   |
	And all reservations start in 12 hours from now
	And all reservations ends after 5 days from start
	And these reservations
		| Reservation | Room  | User | Deleted |
		| 1           | 1A    | Jim  | False   |
		| 2           | 1B    | Jim  | False   |
		| 3           | 2A    | John | False   |
		| 4           | 2B    | John | False   |

Scenario: Add a reservation without disponible rooms
	Given my user is registered as "Peter"
	And I reserve a "Deluxe" room in 3 days
	And with a duration of 7 days
	When I add the reservation
	Then I'm told there are no rooms available

Scenario: Add a reservation where the end date is earlier than the start date
	Given my user is registered as "Peter"
	And I reserve a "Conventional" room in 10 days
	And with a duration of -1 days
	When I add the reservation
	Then I'm told there are not possible to reserve a room

Scenario: Add a reservation starting tomorrow
	Given my user is registered as "Peter"
	And I reserve a "Conventional" room in -1 days
	And with a duration of 7 days
	When I add the reservation
	Then I'm told there are not possible to reserve a room

Scenario: Add a reservation whose start date starts 2 years from now
	Given my user is registered as "Peter"
	And I reserve a "Conventional" room in 730 days
	And with a duration of 7 days
	When I add the reservation
	Then I'm told there are not possible to reserve a room

Scenario: Add a reservation whose duration is 2 months
	Given my user is registered as "Peter"
	And I reserve a "Conventional" room in 10 days
	And with a duration of 60 days
	When I add the reservation
	Then I'm told there are not possible to reserve a room

Scenario: Add a reservation
	Given my user is registered as "Peter"
	And I reserve a "Deluxe" room in 10 days
	And with a duration of 7 days
	When I add the reservation
	Then the end and start time should be 12:00
	And the duration must be 7 days
	And the room must be of the "Deluxe" type
	And the value must be calculated correctly