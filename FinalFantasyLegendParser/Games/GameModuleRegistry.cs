using FinalFantasyLegendParser.Games.Ffl1;
using FinalFantasyLegendParser.Games.Ffl2;
using FinalFantasyLegendParser.Games.Ffl3;

namespace FinalFantasyLegendParser.Games;

internal sealed class GameModuleRegistry
{
    private readonly Dictionary<string, IGameModule> _modules;

    public GameModuleRegistry()
    {
        _modules = new Dictionary<string, IGameModule>(StringComparer.OrdinalIgnoreCase)
        {
            ["ffl1"] = new Ffl1Module(),
            ["ffl2"] = new Ffl2Module(),
            ["ffl3"] = new Ffl3Module()
        };
    }

    public IGameModule? Resolve(string key)
    {
        return _modules.TryGetValue(key, out var module) ? module : null;
    }
}
