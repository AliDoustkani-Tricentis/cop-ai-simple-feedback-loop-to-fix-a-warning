namespace TodoApp;

public class TodoItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }

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
