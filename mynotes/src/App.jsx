import { useEffect, useState } from 'react';
import CreateNoteForm from './components/CreateNoteForm';
import Note from './components/Note';
import Filters from './components/Filters';
import { fetchNotes, createNote } from './services/note';


function App() {
  const [notes, setNotes] = useState([]);
  const [filter, setFilter] = useState({
    search: "",
    sortItem: "date", // Поле для сортировки
    sortOrder: "desc", // "desc" для новых, "asc" для старых
  });

  useEffect(() => {
    const fetchData = async () => {
      const notes = await fetchNotes(filter);
      setNotes(notes || []);
    };
    fetchData();
  }, [filter]);

  const onCreate = async (note) => {
    await createNote(note);
    let notes = await fetchNotes();
    setNotes(notes);
  }

  return (
    <section className="p-8 flex flex-row justify-start items-start gap-12">
      <div className="flex flex-col w-1/3 gap-10">
        <CreateNoteForm onCreate={onCreate}/>
        <Filters filter={filter} setFilter={setFilter} />
      </div>
      <ul className="flex flex-col gap-5 w-1/2">
        {notes.map((note) => (
          <li key={note.Id}>
            <Note 
              title={note.title}
              description={note.description}
              createdAt={note.createdAt} 
            />
          </li>
        ))}
      </ul>
    </section>
  );
}

export default App;
