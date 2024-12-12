using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NotesWEBAPP.Models;

namespace NotesWEBAPP.DataAcess;

public class NotesDbContext : DbContext
{
    public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
    {
    }
    public DbSet<Note> Notes { get; set; }
}