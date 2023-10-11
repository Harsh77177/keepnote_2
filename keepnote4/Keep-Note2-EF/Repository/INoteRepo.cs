using Keep_Note4.Model;

namespace Keep_Note4.Repository
{
    public interface INoteRepo
    {
        Note CreateNote(Note note);
        bool UpdateNote(int id, Note note);
        bool DeleteNote(int noteId);
        Note GetNoteByNoteId(int noteId);
        List<Note> GetAllNotesByUserId(int userId);

    }
}
