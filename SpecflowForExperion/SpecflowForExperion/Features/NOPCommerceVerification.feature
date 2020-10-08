Feature: NOPCommerceVerification

@chrome
Scenario: Verify the All time pending order total value
	Given I have access to the NOPCommerceWebsite
	When I navigate to the admin page
	Then Verify the All time pending order value is 2468.80

