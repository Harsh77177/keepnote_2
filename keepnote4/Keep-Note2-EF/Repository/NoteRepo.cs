using Keep_Note4.Context;
using Keep_Note4.Model;

namespace Keep_Note4.Repository
{
    public class NoteRepo : INoteRepo
    {
        KeepDbContext _context;
        public NoteRepo(KeepDbContext context)
        {
            _context = context;
        }
        public Note CreateNote(Note note)
        {
            _context.notes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public bool DeleteNote(int noteId)
        {
            var obj = _context.notes.FirstOrDefault(x => x.NoteId == noteId);
            if (obj != null)
            {
                _context.notes.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Note> GetAllNotesByUserId(int userId)
        {
            var obj = _context.notes.Where(x => x.CreatedBy == userId).ToList();
            return obj;
        }

        public Note GetNoteByNoteId(int noteId)
        {
            var obj = _context.notes.FirstOrDefault(x => x.NoteId == noteId);
            if (obj != null)
                return obj;
            return null;
        }

        public bool UpdateNote(int id, Note note)
        {
            var obj = _context.notes.FirstOrDefault(x => x.NoteId == note.NoteId);
            if (obj != null)
            {
                obj.NoteTitle = note.NoteTitle;
                obj.NoteContent = note.NoteContent;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
