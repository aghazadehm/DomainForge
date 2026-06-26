using System;
using System.Collections.Generic;
using System.Text;

namespace DomainForge.AcceptanceTests.Drivers;

public class WalletDriver
{
    public Task CreateWallet(decimal balance)
    {
        throw new NotImplementedException();
    }

    public Task Deposit(decimal amount)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetBalance()
    {
        throw new NotImplementedException();
    }
}
