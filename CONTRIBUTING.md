# Contribution Guidelines

## Table of Contents

- [Design guideline](#design-guideline)
- [Style guideline](#style-guideline)
- [Testing](#testing)
- [References](#references)

## Design guideline

- __ApplicationCore__
  - __Models:__ Database table models
  - __Repositories:__ Repository abstractions
  - __Services:__ Service abstractions
- __Infrastructure__
  - __Data:__ Entity Framework Core database context
  - __Repositories:__ Repositories
  - __Services:__ Services
- __Web__
  - __AppStart:__ Startup configuration files
  - __ClientApp:__ SPA frontend files
  - __Models:__ Request & Response models

## Style guideline

System usings must be first then others alphabetically sorted

```csharp
using System;
using System.Threading.Tasks;
using Architect.ApplicationCore.Services;
using Architect.Web.Models;
using Microsoft.IdentityModel.Tokens;
```

Use `expression-bodied members` if possible

```csharp
public string Name
{
    get => _name;
    set => _name = value;
}

public override string ToString() => $"{_name} {_surname}".Trim();
```

## Testing

- __Unit Tests:__ Logical operation must be covered by unit tests
- __Integration Tests:__ Endpoints must be covered by integration tests

## References

- Test framework: [xUnit](https://xunit.net/#documentation)
