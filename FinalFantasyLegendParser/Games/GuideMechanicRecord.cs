namespace FinalFantasyLegendParser.Games;

internal sealed record GuideMechanicRecord(
    int SectionOrder,
    int EntryOrder,
    string SectionTitle,
    string Topic,
    string Details,
    string SourceGuides);