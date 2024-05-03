﻿@User
Feature: RemoveFine
	In order to allow users to access our services
	As an administrator
	I would like to unblock a user

Background:
	Given these registered users
		| Name		| Email				 | Password | Role			| Cpf         | Phone       | Fine   | Blocked | Deleted |
		| Josh		| josh@gmail.com	 | 1234     | Admin			| 77890464037 | 54926418694 | 0.00   | False   | False   |
		| Steve		| steve@gmail.com	 | 1234     | Admin			| 48697613000 | 54934725422 | 0.00   | False   | False   |
		| Michael	| michael@gmail.com  | 1234     | Attendant		| 18116612034 | 51931696883 | 0.00   | False   | False   |
		| John		| john@gmail.com     | 1234     | Customer		| 70173805094 | 54927299016 | 0.00   | False   | False   |
		| Jim		| jim@gmail.com      | 1234     | Customer		| 53720760030 | 51928657841 | 300.00 | False   | False   |
		| Peter		| peter@gmail.com    | 1234     | Customer		| 27471571055 | 55931641434 | 0.00   | True    | False   |

Scenario: Remove fine from one user
	Given I remove the fine from "Jim"
	When I execute the remove fine action
	Then the users fine should be
		| Name  | Fine |
		| Josh  | 0.00 |
		| John  | 0.00 |
		| Jim   | 0.00 |
		| Peter | 0.00 |