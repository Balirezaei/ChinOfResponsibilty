# Chain of Responsibility Pattern - C#

This project demonstrates the **Chain of Responsibility** design pattern implemented in C#.  
It allows requests to pass through a chain of handlers dynamically.

## Features

- Generic handlers for flexible usage.
- Build custom chains easily.
- Unit tests included to validate behavior.
- Sample request processing through multiple handlers.

## Folder Structure

```

/ChainOfResponsibiltySample
  /FrameWork
  │
  ├── /ChainFramework                    # abstract Handler
  ├── /CommonHandler                     # Such as NullHandler
  ├── /CustomHandler                     # Unit tests
  /Tests
  |
  └── ChainOfResponsibiltyTests.cs       # Unit tests

## Usage

Build a chain:

```csharp
var chain = new ChainBuilder<ApiRequest>()
    .With<AuthenticationHandler>()
    .With<LoggingHandler>()
    .Build();
```

Send a request:

```csharp
var response = chain.Handle(new ApiRequest { Token = "my-token" });
```

Each handler processes the request or passes it to the next handler.

## Unit Tests

Example with **xUnit**:

```csharp
[Fact]
public void Request_Without_Token_Should_Return_401_InSingle_Chain()
{
    var chain = new ChainBuilder<ApiRequest>()
    .With<AuthenticationHandler>()
    .Build(); ;

    var request = new ApiRequest
    {
        UserToken = null
    };

    chain.Handle(request);

    Assert.Equal("401 Unauthorized", request.Response);
}
```

Run tests:

```bash
dotnet test
```

## References

- [Chain of Responsibility - Wikipedia](https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern)


## Author

Bahar Alirezaei

