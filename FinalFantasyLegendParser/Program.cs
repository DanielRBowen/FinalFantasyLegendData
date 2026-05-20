using System.Text;
using FinalFantasyLegendParser.Cli;

Console.OutputEncoding = Encoding.UTF8;

return await App.RunAsync(args, Console.Out, Console.Error, CancellationToken.None);
