namespace NotesWEBAPP.Models;

public class Note
{
    public Note(string title, string desc)
    {
        Title = title;
        Description = desc;
        CreatedAt = DateTime.UtcNow;
    }
    public Note()
    {

    }
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime CreatedAt { get; init; }
}
