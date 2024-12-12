namespace NotesWEBAPP.Contracts;

public record NoteDTO(Guid Id, string Title, string Description, DateTime CreatedAt);
