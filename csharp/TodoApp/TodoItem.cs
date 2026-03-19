namespace TodoApp;

public class TodoItem
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }

    private int _internalId = 0;

    public void MarkComplete()
    {
        IsCompleted = true;
    }

    public override string ToString()
    {
        var status = IsCompleted ? "[x]" : "[ ]";
        return $"{status} {Title}";
    }
}
