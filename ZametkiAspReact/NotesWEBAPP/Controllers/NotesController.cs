using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesWEBAPP.Contracts;
using NotesWEBAPP.DataAcess;
using NotesWEBAPP.Models;
using System.Linq.Expressions;

namespace NotesWEBAPP.Controllers;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
   private readonly NotesDbContext _context;
    public NotesController(NotesDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNoteRequest request, CancellationToken cts)
    {
        var note = new Note(request.Title, request.Description);

        await _context.Notes.AddAsync(note, cts);
        await _context.SaveChangesAsync();

        return Ok(note);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetNotesRequest request, CancellationToken cts)
    {
        var notesQuery = _context.Notes
            .Where(n => string.IsNullOrWhiteSpace(request.Search) ||
                        n.Title.ToLower().Contains(request.Search.ToLower()));

        Expression<Func<Note, object>> selectorKey = request.SortItem?.ToLower() switch
        {
            "date" => note => note.CreatedAt,
            "title" => note => note.Title,
            _ => note => note.Id
        };

        notesQuery = request.SortOrder?.ToLower() switch
        {
            "desc" => notesQuery.OrderByDescending(selectorKey),
            "asc" or null => notesQuery.OrderBy(selectorKey), // Если null, сортировка по умолчанию - "asc"
            _ => notesQuery // Если SortOrder имеет некорректное значение, оставить без сортировки
        };

        var noteDtos= await notesQuery
            .Select(n => new NoteDTO(n.Id, n.Title, n.Description, n.CreatedAt))
            .ToListAsync(cancellationToken: cts);

        return Ok(new GetNotesResponse(noteDtos));
    }

}
