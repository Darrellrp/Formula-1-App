using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Formula_1_API.Configurations
{
    public class CommandHandler
    {
        private WebApplication App { get; set; }
        private List<string> Args { get; set; }
        private IDictionary<string, string[]> Options = new Dictionary<string, string[]>();

        public CommandHandler(WebApplication app, IEnumerable<string> args)
        {
            App = app;
            Args = args.ToList();
            Options.Add("seed", new string[] { "-s", "--seed" });
            Options.Add("migrate", new string[] { "-m", "--migrate" });
        }

        public async Task InvokeCommands()
        {
            var seed = Options["seed"].Intersect(Args).Any();
            var migrate = Options["migrate"].Intersect(Args).Any();

            if (seed)
            {
                var seedLimit = ParseLimit();
                await App.SeedDatabase(seedLimit);
            }

            if (migrate)
            {
                await App.RunMigrations();
            }

            Environment.Exit(1);
        }

        private int? ParseLimit()
        {
            var seedArg = Args.First(x =>
                x.StartsWith(Options["seed"][0]) ||
                x.StartsWith(Options["seed"][1])
            );

            var argParts = seedArg.Split("=");

            if (argParts.Length < 2)
            {
                return null;
            }

            var value = argParts[1];

            if (!int.TryParse(value, out var limit))
            {
                Console.WriteLine("Invalid second parameter: seeding limit must be an integer");
            }

            return limit;
        }
    }
}