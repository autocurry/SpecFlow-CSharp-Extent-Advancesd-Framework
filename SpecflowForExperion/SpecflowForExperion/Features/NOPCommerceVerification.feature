Feature: NOPCommerceVerification

Background: 
Given : I navigate to the login page

@chrome
Scenario: Verify the All time pending order total value
	Given I have access to the NOPCommerceWebsite
	When I navigate to the admin page
	Then Verify the All time pending order value is $2,468.80

Scenario Outline: Verify customer email address
	Given I have access to the NOPCommerceWebsite
	When I navigate to the customer page
	And Enter the first name <name> and Search
	Then the Email id displayed will be <email>
Examples: 
	| name     | email                             |
	| John     | admin@yourStore.com               |
	| Victoria | victoria_victoria@nopCommerce.com |

