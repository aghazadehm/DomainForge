using System;
using System.Collections.Generic;
using System.Text;

namespace DomainForge.AcceptanceTests.Support;

public class ScenarioContext
{
    public Guid WalletId { get; set; }

    public decimal InitialBalance { get; set; }

    public decimal ExpectedBalance { get; set; }

    public IReadOnlyCollection<object> Events { get; set; }
        = Array.Empty<object>();
}
