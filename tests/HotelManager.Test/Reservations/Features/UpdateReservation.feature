@Reservation
Feature: UpdateReservation
	In order to enjoy my vacation that was delayed
	As a user
	I would like to update my reservation

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

Scenario: Update a reservation without disponible rooms
	Given my user is registered as "Jim"
	And I update the reservation 4
	And I reserve a "Deluxe" room in 3 days
	And with a duration of 7 days
	When I update the reserbation
	Then I'm told there are no rooms available