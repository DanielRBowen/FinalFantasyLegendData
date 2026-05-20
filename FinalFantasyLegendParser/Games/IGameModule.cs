namespace FinalFantasyLegendParser.Games;

internal interface IGameModule
{
    string Key { get; }

    Task<int> RunAsync(GameModuleContext context);
}
