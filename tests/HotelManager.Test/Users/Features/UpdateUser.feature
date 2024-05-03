@User
Feature: UpdateUser
	In order to change my account details
	As a user
	I would like to update my account

Background:
	Given these registered users
		| Name		| Email				 | Password | Role			| Cpf         | Phone       | Fine   | Blocked | Deleted |
		| Josh		| josh@gmail.com	 | 1234     | Admin			| 77890464037 | 54926418694 | 0.00   | False   | False   |
		| Steve		| steve@gmail.com	 | 1234     | Admin			| 48697613000 | 54934725422 | 0.00   | False   | False   |
		| Michael	| michael@gmail.com  | 1234     | Attendant		| 18116612034 | 51931696883 | 0.00   | False   | False   |
		| John		| john@gmail.com     | 1234     | Customer		| 70173805094 | 54927299016 | 0.00   | False   | False   |
		| Jim		| jim@gmail.com      | 1234     | Customer		| 53720760030 | 51928657841 | 300.00 | False   | False   |
		| Peter		| peter@gmail.com    | 1234     | Customer		| 27471571055 | 55931641434 | 0.00   | True    | False   |

Scenario: Update account with existing email
	Given my user is registered as "John"
	And I update my email to "peter@gmail.com"
	When I update my user
	Then I'm told there are users registered with my email

Scenario: Update account with existing cpf
	Given my user is registered as "John"
	And I update my cpf to "48697613000"
	When I update my user
	Then I'm told there are users registered with my cpf 