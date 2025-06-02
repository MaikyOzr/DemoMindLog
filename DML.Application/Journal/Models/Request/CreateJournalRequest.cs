namespace DML.Application.Journal.Models.Request;

public class CreateJournalRequest
{
    public string? Note { get; set; }

    public Models.Enums.MoodEnum? Mood { get; set; }

    public string? Tag { get; set; }
}
