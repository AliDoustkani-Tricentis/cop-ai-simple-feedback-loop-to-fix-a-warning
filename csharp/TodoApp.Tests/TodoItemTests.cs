namespace TodoApp.Tests;

public class TodoItemTests
{
    [Fact]
    public void Title_And_Description_CanBeSetAndRetrieved()
    {
        var item = new TodoItem
        {
            Title = "My Task",
            Description = "My description",
            CreatedAt = DateTime.Now
        };

        Assert.Equal("My Task", item.Title);
        Assert.Equal("My description", item.Description);
    }

    [Fact]
    public void ToString_ShowsTitleWithIncompleteStatus()
    {
        var item = new TodoItem
        {
            Title = "Buy milk",
            Description = "From store",
            CreatedAt = DateTime.Now
        };

        Assert.Equal("[ ] Buy milk", item.ToString());
    }

    [Fact]
    public void ToString_ShowsTitleWithCompleteStatus_WhenMarkedComplete()
    {
        var item = new TodoItem
        {
            Title = "Done task",
            Description = "Done",
            CreatedAt = DateTime.Now
        };
        item.MarkComplete();

        Assert.Equal("[x] Done task", item.ToString());
    }

    [Fact]
    public void AddItem_WithNullTitle_StoresItemWithNullTitle()
    {
        var service = new TodoService();
        service.AddItem(null, "description", 1);

        var item = service.GetItem(0, false);
        Assert.NotNull(item);
        Assert.Null(item!.Title);
        Assert.Equal("description", item.Description);
    }

    [Fact]
    public void AddItem_WithNullDescription_StoresItemWithNullDescription()
    {
        var service = new TodoService();
        service.AddItem("Task", null, 1);

        var item = service.GetItem(0, false);
        Assert.NotNull(item);
        Assert.Equal("Task", item!.Title);
        Assert.Null(item.Description);
    }

    [Fact]
    public void AddItem_WithNullTitleAndDescription_StoresItem()
    {
        var service = new TodoService();
        service.AddItem(null, null, 1);

        var item = service.GetItem(0, false);
        Assert.NotNull(item);
        Assert.Null(item!.Title);
        Assert.Null(item.Description);
    }

    [Fact]
    public void ToString_HandlesNullTitle()
    {
        var item = new TodoItem
        {
            Title = null,
            Description = "desc",
            CreatedAt = DateTime.Now
        };

        var result = item.ToString();
        Assert.Equal("[ ] ", result);
    }
}
