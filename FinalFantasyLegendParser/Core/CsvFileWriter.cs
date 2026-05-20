using System.Globalization;
using System.Reflection;
using System.Text;

namespace FinalFantasyLegendParser.Core;

internal static class CsvFileWriter
{
    public static void WriteRecords<T>(string path, IReadOnlyCollection<T> records)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);

        var properties = typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(property => property.CanRead)
            .ToArray();

        using var writer = new StreamWriter(path, append: false, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        writer.WriteLine(string.Join(',', properties.Select(property => Escape(property.Name))));

        foreach (var record in records)
        {
            writer.WriteLine(string.Join(',', properties.Select(property => Escape(ConvertToString(property.GetValue(record))))));
        }
    }

    private static string ConvertToString(object? value)
    {
        return value switch
        {
            null => string.Empty,
            IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
            _ => value.ToString() ?? string.Empty
        };
    }

    private static string Escape(string value)
    {
        if (!value.Contains(',') && !value.Contains('"') && !value.Contains('\n') && !value.Contains('\r'))
        {
            return value;
        }

        return $"\"{value.Replace("\"", "\"\"")}\"";
    }
}
