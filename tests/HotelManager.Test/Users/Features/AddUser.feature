@User
Feature: AddUser
	In order to access the platform
	As a user
	I want to register my user

Background:
	Given these registered users
		| Name		| Email				 | Password | Role			| Cpf         | Phone       | Fine   | Blocked | Deleted |
		| Josh		| josh@gmail.com	 | 1234     | Admin			| 77890464037 | 54926418694 | 0.00   | False   | False   |
		| Steve		| steve@gmail.com	 | 1234     | Admin			| 48697613000 | 54934725422 | 0.00   | False   | False   |
		| Michael	| michael@gmail.com  | 1234     | Attendant		| 18116612034 | 51931696883 | 0.00   | False   | False   |
		| John		| john@gmail.com     | 1234     | Customer		| 70173805094 | 54927299016 | 0.00   | False   | False   |
		| Jim		| jim@gmail.com      | 1234     | Customer		| 53720760030 | 51928657841 | 300.00 | False   | False   |
		| Peter		| peter@gmail.com    | 1234     | Customer		| 27471571055 | 55931641434 | 0.00   | True    | False   |

Scenario: Add a user with existing email
	Given my name is "John", my email is "john@gmail.com", my password is "1234", my cpf is "82477025090" and my phone is "53934594541"
	When I add my user
	Then I'm told there are users registered with my email

Scenario: Add a user with existing cpf
	Given my name is "Oliver", my email is "oliver@gmail.com", my password is "1234", my cpf is "53720760030" and my phone is "53922129814"
	When I add my user
	Then I'm told there are users registered with my cpf 