using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainForge.AcceptanceTests.Fixtures;

public class TestApplicationFactory
    : WebApplicationFactory<Program>
{
}
