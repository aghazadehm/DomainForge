Feature: Deposit money into wallet

    As a wallet owner
    I want to deposit money into my wallet
    So that my available balance increases


Scenario: Successfully deposit money

    Given a wallet exists with balance 100 USD

    When I deposit 50 USD into the wallet

    Then the wallet available balance should be 150 USD

    And a MoneyDeposited domain event should be raised