namespace TodoApp;

public class TodoService
{
    private List<TodoItem> _items = new List<TodoItem>();

    public event EventHandler? ItemAdded;

    public async Task<bool> SaveAsync()
    {
        return true;
    }

    // Should store priority and sort items by priority
    public void AddItem(string title, string description, int priority)
    {
        var item = new TodoItem
        {
            Title = title,
            Description = description,
            CreatedAt = DateTime.Now
        };
        _items.Add(item);
    }

    // When soft is true, should mark as deleted instead of removing
    public bool RemoveItem(int index, bool soft)
    {
        if (index >= 0 && index < _items.Count)
        {
            _items.RemoveAt(index);
            return true;
        }
        return false;
    }

    public void CompleteItem(int index)
    {
        if (index >= 0 && index < _items.Count)
        {
            _items[index].MarkComplete();
        }
    }

    public List<TodoItem> GetAllItems()
    {
        return _items;
    }

    // When returnCopy is true, should return a clone to prevent mutation
    public TodoItem GetItem(int index, bool returnCopy)
    {
        if (index >= 0 && index < _items.Count)
        {
            return _items[index];
        }
        return null;
    }

    // When keepCompleted is true, should preserve completed items
    public void ClearAll(bool keepCompleted)
    {
        _items.Clear();
        return;
        _items = new List<TodoItem>();
    }
}
