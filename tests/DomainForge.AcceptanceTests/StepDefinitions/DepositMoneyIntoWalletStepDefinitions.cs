using System;
using Reqnroll;

namespace DomainForge.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class DepositMoneyIntoWalletStepDefinitions
    {
        [Given("a wallet exists with balance {int} USD")]
        public void GivenAWalletExistsWithBalanceUSD(int p0)
        {
            throw new PendingStepException();
        }

        [When("I deposit {int} USD into the wallet")]
        public void WhenIDepositUSDIntoTheWallet(int p0)
        {
            throw new PendingStepException();
        }

        [Then("the wallet available balance should be {int} USD")]
        public void ThenTheWalletAvailableBalanceShouldBeUSD(int p0)
        {
            throw new PendingStepException();
        }

        [Then("a MoneyDeposited domain event should be raised")]
        public void ThenAMoneyDepositedDomainEventShouldBeRaised()
        {
            throw new PendingStepException();
        }

    }
}
