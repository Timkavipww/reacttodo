namespace NotesWEBAPP.Contracts;

public record GetNotesRequest(string? Search, string? SortItem, string SortOrder = "asc");
