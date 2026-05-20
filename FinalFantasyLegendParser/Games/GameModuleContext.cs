namespace FinalFantasyLegendParser.Games;

internal sealed record GameModuleContext(
    string RepositoryRoot,
    string OutputDirectory,
    TextWriter Output,
    TextWriter Error,
    CancellationToken CancellationToken);
