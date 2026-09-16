public class Journal
{
  private readonly List<Entry> _entries = new List<Entry>();

  public int EntryCount => _entries.Count;

  public void AddEntry(Entry entry)
  {
    _entries.Add(entry);
  }

  public void DisplayEntries()
  {
    if (_entries.Count == 0)
    {
      Console.WriteLine("The journal is empty.");
      return;
    }

    foreach (Entry entry in _entries)
    {
      entry.Display();
    }
  }

  public void SaveToFile(string fileName)
  {
    File.WriteAllLines(fileName, _entries.Select(entry => entry.ToFileLine()));
  }

  public void LoadFromFile(string fileName)
  {
    _entries.Clear();

    if (!File.Exists(fileName))
    {
      return;
    }

    foreach (string line in File.ReadAllLines(fileName))
    {
      if (!string.IsNullOrWhiteSpace(line))
      {
        _entries.Add(Entry.FromFileLine(line));
      }
    }
  }
}