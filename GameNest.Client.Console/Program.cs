using GameNest.Client.Console;
using GameNest.Shared.Services;
using Grpc.Net.Client;
using MagicOnion.Client;

var channel = GrpcChannel.ForAddress("https://localhost:5001");
var authFilter = new WithAuthenticationFilter(channel);
var authService = MagicOnionClient.Create<IAuthService>(channel);

IAccountService accountService = null;
ILoadoutService loadoutService = null;

while (true)
{
    Console.WriteLine("\nSelect an option:");
    Console.WriteLine("1 - Register");
    Console.WriteLine("2 - Login");
    Console.WriteLine("3 - GetAccountInfo");
    Console.WriteLine("4 - Loadout Menu");
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

        var registerResponse = await authService.RegisterAsync(new GameNest.Shared.MessagePacks.RegisterMessage
        {
            Username = username,
            Password = password,
            Email = email
        });

        Console.WriteLine(registerResponse.Success ? "Registration successful!" : "Registration failed: " + registerResponse.Message);
        
    }
    else if (choice == "2")
    {
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();

        var loginResponse = await authService.LoginAsync(new GameNest.Shared.MessagePacks.LoginMessage
        {
            Username = username,
            Password = password
        });

        Console.WriteLine(!string.IsNullOrEmpty(loginResponse.Token) ? $"Login successful! Token: {loginResponse.Token}" : "Login failed.");
        
        if(!string.IsNullOrEmpty(loginResponse.Token))
        {
            authFilter.SetAuthentication(loginResponse.Token);
            Console.WriteLine($"User ID: {loginResponse.UserId}, Username: {loginResponse.Username}");
        }
        else
        {
            Console.WriteLine("Login failed.");
        }
    }
    else if (choice == "3")
    {
        accountService = MagicOnionClient.Create<IAccountService>(channel, new[] { authFilter });
        var accountInfo = await accountService.GetCurrentAccountAsync();
        if (accountInfo != null)
        {
            Console.WriteLine($"Account Info: Username: {accountInfo.Name}, Email: {accountInfo}, Id: {accountInfo.Id}");
            // Accounts Items
            Console.WriteLine("Your items:");
            foreach (var item in accountInfo.Items)
            {
                Console.WriteLine($"Item ID: {item.Id}, Name: {item.Item.Name}, Description: {item.Item.Description}");
            }

            // Loadout
            Console.WriteLine("Your loadout:");
            Console.WriteLine($"Main: {accountInfo.Loadout.Main.Item.Name}");
            Console.WriteLine($"Secondary: {accountInfo.Loadout.Secondary.Item.Name}");
            Console.WriteLine($"Chest: {accountInfo.Loadout.Chest.Item.Name}");
        }
        else
        {
            Console.WriteLine("Account info could not be retrieved.");
        }
    }
    else if (choice == "4")
    {
        loadoutService = MagicOnionClient.Create<ILoadoutService>(channel, new[] { authFilter });
        Console.WriteLine("Loadout Menu:");
        Console.WriteLine("1 - View Loadout");
        Console.WriteLine("2 - Save Loadout (dummy)");
        Console.Write("Your choice: ");
        var loadoutChoice = Console.ReadLine();
        if (loadoutChoice == "1")
        {
            var loadout = await loadoutService.GetLoadoutAsync();
            if (loadout != null)
            {
                Console.WriteLine($"Loadout Id: {loadout.Id}");
                Console.WriteLine($"Main: {loadout.Main?.Item?.Name ?? "-"}");
                Console.WriteLine($"Secondary: {loadout.Secondary?.Item?.Name ?? "-"}");
                Console.WriteLine($"Helmet: {loadout.Helmet?.Item?.Name ?? "-"}");
                Console.WriteLine($"Chest: {loadout.Chest?.Item?.Name ?? "-"}");
            }
            else
            {
                Console.WriteLine("No loadout found.");
            }
        }
        else if (loadoutChoice == "2")
        {
            // Dummy save example (real implementation would require user input)
            var loadout = await loadoutService.GetLoadoutAsync();
            if (loadout != null)
            {
                var result = await loadoutService.SaveLoadoutAsync(loadout);
                Console.WriteLine(result != null ? "Loadout saved!" : "Failed to save loadout.");
            }
            else
            {
                Console.WriteLine("No loadout to save.");
            }
        }
        else
        {
            Console.WriteLine("Invalid loadout menu choice.");
        }
    }
    else
    {
        Console.WriteLine("Invalid choice. Please try again.");
    }
}
