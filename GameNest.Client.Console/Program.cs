using GameNest.Shared.Services;
using Grpc.Net.Client;
using MagicOnion.Client;

var channel = GrpcChannel.ForAddress("https://localhost:5001");
var accountService = MagicOnionClient.Create<IAccountService>(channel);

while (true)
{
    Console.WriteLine("\nSelect an option:");
    Console.WriteLine("1 - Register");
    Console.WriteLine("2 - Login");
    Console.WriteLine("0 - Exit");
    Console.Write("Your choice: ");
    var choice = Console.ReadLine();

    if (choice == "0")
        break;

    if (choice == "1")
    {
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();
        Console.Write("Email: ");
        var email = Console.ReadLine();

        var registerResponse = await accountService.RegisterAsync(new GameNest.Shared.MessagePacks.RegisterMessage
        {
            Username = username,
            Password = password,
            Email = email
        });

        Console.WriteLine(registerResponse.Success ? "Registration successful!" : "Registration failed: " + registerResponse.Message);
        // Accounts Items
        Console.WriteLine("Your items:");
        foreach (var item in registerResponse.Account.Items)
        {
            Console.WriteLine($"Item ID: {item.Id}, Name: {item.Item.Name}, Description: {item.Item.Description}");
        }
        
        // Loadout
        Console.WriteLine("Your loadout:");
        if (registerResponse.Account.Loadout != null)
        {
            Console.WriteLine($"Main: {registerResponse.Account.Loadout.Main.Item.Name}");
            Console.WriteLine($"Secondary: {registerResponse.Account.Loadout.Secondary.Item.Name}");
            Console.WriteLine($"Chest: {registerResponse.Account.Loadout.Chest.Item.Name}");
        }
        else
        {
            Console.WriteLine("No loadout found.");
        }
    }
    else if (choice == "2")
    {
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();

        var loginResponse = await accountService.LoginAsync(new GameNest.Shared.MessagePacks.LoginMessage
        {
            Username = username,
            Password = password
        });

        Console.WriteLine(!string.IsNullOrEmpty(loginResponse.Token) ? $"Login successful! Token: {loginResponse.Token}" : "Login failed.");
    }
    else
    {
        Console.WriteLine("Invalid choice. Please try again.");
    }
}
