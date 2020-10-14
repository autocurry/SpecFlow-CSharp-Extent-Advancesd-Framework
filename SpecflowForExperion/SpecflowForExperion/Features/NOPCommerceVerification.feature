Feature: NOPCommerceVerification
As a user of nop commerce websire
I want to ensure the total value and email search functionalites are working 
So that user can successfully use the application

#This will opens up the Login page of the NOP Commerce Website
Background:
	Given I navigate to the login page

#This scenario  verifies that the Total Order table shows expected value for the All time pending order
@browser_chrome
Scenario: Verify the All time pending order total value
	Given I have access to the NOPCommerceWebsite
	When I navigate to the admin page
	Then Verify the All time pending order value is $2,469.80

#This scenario will verify that the firstname based search is working as expeceted for the customers tab
@browser_chrome
Scenario Outline: Verify customer email address
	Given I have access to the NOPCommerceWebsite
	When I navigate to the customer page
	And Enter the first name <name> and Search
	Then the Email id displayed will be <email>

	Examples:
		| name     | email                             |
		| John     | aaadmin@yourStore.com               |
		| Victoria | victoria_victoria@nopCommerce.com |