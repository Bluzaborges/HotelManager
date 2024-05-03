@User
Feature: DeleteUser
	In order to remove a user from the list
	As an administratior
	I would like to delete the user

Background:
	Given these registered users
		| Name		| Email				 | Password | Role			| Cpf         | Phone       | Fine   | Blocked | Deleted |
		| Josh		| josh@gmail.com	 | 1234     | Admin			| 77890464037 | 54926418694 | 0.00   | False   | False   |
		| Steve		| steve@gmail.com	 | 1234     | Admin			| 48697613000 | 54934725422 | 0.00   | False   | False   |
		| Michael	| michael@gmail.com  | 1234     | Attendant		| 18116612034 | 51931696883 | 0.00   | False   | False   |
		| John		| john@gmail.com     | 1234     | Customer		| 70173805094 | 54927299016 | 0.00   | False   | False   |
		| Jim		| jim@gmail.com      | 1234     | Customer		| 53720760030 | 51928657841 | 300.00 | False   | False   |
		| Peter		| peter@gmail.com    | 1234     | Customer		| 27471571055 | 55931641434 | 0.00   | True    | False   |

Scenario: Delete one user as admin
	Given my user is registered as "Josh"
	And I delete the user "Peter"
	When I execute the user delete action
	Then the users deleted should be
		| Name  | Deleted |
		| Josh  | False   |
		| John  | False   |
		| Jim   | False   |
		| Peter | True    |

Scenario: Delete one admin as admin
	Given my user is registered as "Josh"
	And I delete the user "Steve"
	When I execute the user delete action
	Then I was told it is not possible to delete a admin

Scenario: Delete one user as attendant
	Given my user is registered as "Michael"
	And I delete the user "Jim"
	When I execute the user delete action
	Then I was told it is not possible to delete a user

Scenario: Delete one user as customer
	Given my user is registered as "Jim"
	And I delete the user "John"
	When I execute the user delete action
	Then I was told it is not possible to delete a user