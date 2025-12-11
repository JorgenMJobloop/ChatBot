# Demonstration of mutability in C#

### This demo uses the Bcrypt package
```sh
dotnet add package BCrypt.Net-Next --version 4.0.3
```

## Immutable classes (static)
the class in this example, has a SINGLE purpose, has no need to be mutated or changed externally outside of it's body.
```cs
using Bcrypt.Net-Next;

public static class HashAPassword 
{
    public static string HashPasswordWrapper(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}

```

### Example of using the class above, in Program.cs
```cs
class Program 
{
    static void Main(string[] args) 
    {
        string password = "my-secure-password-1234";
        HashAPassword.HashPasswordWrapper(password); // creates a BCrypt hash on the password.
    }
}

```

## Mutable classes

### interface
```cs
```

In this example, we create a mutable class and implement the interface corresponding to the class
```cs
public abstract class SystemLogger : ISystemLogger 
{

}
```
