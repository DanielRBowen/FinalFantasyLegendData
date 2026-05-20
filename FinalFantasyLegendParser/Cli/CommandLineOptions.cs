namespace FinalFantasyLegendParser.Cli;

internal sealed record CommandLineOptions(
    string GameKey,
    string RepositoryRoot,
    string OutputDirectory,
    bool ShowHelp)
{
    public static CommandLineOptions Parse(string[] args)
    {
        if (args.Length == 0)
        {
            return new CommandLineOptions(
                "ffl1",
                Directory.GetCurrentDirectory(),
                Path.GetFullPath(GetDefaultOutputDirectory("ffl1")),
                ShowHelp: false);
        }

        string gameKey = "ffl1";
        string repositoryRoot = Directory.GetCurrentDirectory();
        string? outputDirectory = null;
        var showHelp = false;

        for (var index = 0; index < args.Length; index++)
        {
            var argument = args[index];

            switch (argument)
            {
                case "-h":
                case "--help":
                case "help":
                    showHelp = true;
                    break;

                case "--game":
                    gameKey = GetRequiredValue(args, ref index, argument);
                    break;

                case "--root":
                    repositoryRoot = GetRequiredValue(args, ref index, argument);
                    break;

                case "--output":
                    outputDirectory = GetRequiredValue(args, ref index, argument);
                    break;

                default:
                    throw new ArgumentException($"Unknown argument '{argument}'.");
            }
        }

        var normalizedGameKey = gameKey.Trim().ToLowerInvariant();

        return new CommandLineOptions(
            normalizedGameKey,
            Path.GetFullPath(repositoryRoot),
            Path.GetFullPath(outputDirectory ?? GetDefaultOutputDirectory(normalizedGameKey)),
            showHelp);
    }

    public static string GetUsage()
    {
        return string.Join(Environment.NewLine,
        [
            "FinalFantasyLegendParser",
            string.Empty,
            "Usage:",
            "  dotnet run --project FinalFantasyLegendParser -- [--game ffl1|ffl2|ffl3] [--root <repoRoot>] [--output <outputDir>]",
            string.Empty,
            "Options:",
            "  --game   Game module key. Currently supported: ffl1, ffl2, ffl3",
            "  --root   Repository root containing FFL1/FFL2/FFL3 folders.",
            "  --output Output directory for generated CSV and markdown files.",
            "  --help   Show help."
        ]);
    }

    private static string GetRequiredValue(string[] args, ref int index, string argument)
    {
        index++;

        if (index >= args.Length)
        {
            throw new ArgumentException($"Missing value for '{argument}'.");
        }

        return args[index];
    }

    private static string GetDefaultOutputDirectory(string gameKey)
    {
        return gameKey switch
        {
            "ffl1" => Path.Combine(Directory.GetCurrentDirectory(), "Examples", "FinalFantasyLegend1Data"),
            "ffl2" => Path.Combine(Directory.GetCurrentDirectory(), "Examples", "FinalFantasyLegend2Data"),
            "ffl3" => Path.Combine(Directory.GetCurrentDirectory(), "Examples", "FinalFantasyLegend3Data"),
            _ => Path.Combine(Directory.GetCurrentDirectory(), "Examples", gameKey)
        };
    }
}
