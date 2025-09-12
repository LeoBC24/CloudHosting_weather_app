

internal class Program
{
    private static void Main(string[] args)
    {

        string path = Directory.GetCurrentDirectory();

        Console.WriteLine("The current directory is {0}", path);

        Console.WriteLine(@$"Executing Assembly:
        {Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}");

        var builder = WebApplication.CreateBuilder(args);


        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");
        app.MapGet("lostit/", GetHello);

        app.Run();

        Console.WriteLine("This should never happen");

        string GetHello()
        {
            var helloFolder = new DirectoryInfo(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                );

            var helloPath = Path.Combine(helloFolder.FullName, "hello.txt");

            if (!File.Exists(helloPath))
            {
                return @$"Sorry, cant return. Could not find what you were looking for {helloPath}";
            }

            Console.WriteLine($"Reading hello from: {helloPath}");

            var message = File.ReadAllText(helloPath);
            return "Read from FILE:\n\n" + message;
        }
    }
}