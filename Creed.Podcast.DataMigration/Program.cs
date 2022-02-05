//Upgrade the database using sql files in scripts folder.
//Scripts are executed in alphabetical order.
//Script files must be marked as embedded resource in build action property.
//This is very usefull for cd pippeline.

using DbUp;
using System.Reflection;

var connectionString = args.FirstOrDefault();

if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Connection string cannot be empty");
    Console.ResetColor();
    return -1;
}

//Create database if not exists.
EnsureDatabase.For.SqlDatabase(connectionString);

var upgrader =
    DeployChanges.To
        .SqlDatabase(connectionString)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .WithTransactionPerScript()
        .LogToConsole()
        .Build();

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
return 0;
