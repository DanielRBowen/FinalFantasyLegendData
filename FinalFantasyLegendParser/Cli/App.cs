using FinalFantasyLegendParser.Games;

namespace FinalFantasyLegendParser.Cli;

internal static class App
{
    public static async Task<int> RunAsync(
        string[] args,
        TextWriter output,
        TextWriter error,
        CancellationToken cancellationToken)
    {
        CommandLineOptions options;

        try
        {
            options = CommandLineOptions.Parse(args);
        }
        catch (ArgumentException ex)
        {
            await error.WriteLineAsync(ex.Message);
            await error.WriteLineAsync();
            await output.WriteLineAsync(CommandLineOptions.GetUsage());
            return 1;
        }

        if (options.ShowHelp)
        {
            await output.WriteLineAsync(CommandLineOptions.GetUsage());
            return 0;
        }

        var registry = new GameModuleRegistry();
        var module = registry.Resolve(options.GameKey);

        if (module is null)
        {
            await error.WriteLineAsync($"Unknown or unsupported game module '{options.GameKey}'.");
            await error.WriteLineAsync();
            await output.WriteLineAsync(CommandLineOptions.GetUsage());
            return 1;
        }

        var context = new GameModuleContext(
            options.RepositoryRoot,
            options.OutputDirectory,
            output,
            error,
            cancellationToken);

        return await module.RunAsync(context);
    }
}
