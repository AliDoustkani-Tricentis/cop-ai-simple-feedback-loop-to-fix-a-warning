namespace TodoApp.Tests;

public class TodoServiceTests
{
    [Fact]
    public void AddItem_AcceptsPriorityParameter()
    {
        var service = new TodoService();

        // This test verifies the API contract - priority must be accepted
        service.AddItem("Task", "description", 5);

        Assert.Single(service.GetAllItems());
    }

    [Fact]
    public void RemoveItem_AcceptsSoftDeleteParameter()
    {
        var service = new TodoService();
        service.AddItem("Task", "description", 1);

        // This test verifies the API contract - soft parameter must be accepted
        var result = service.RemoveItem(0, false);

        Assert.True(result);
    }

    [Fact]
    public void RemoveItem_HardDeletesWhenSoftIsFalse()
    {
        var service = new TodoService();
        service.AddItem("Task", "description", 1);

        service.RemoveItem(0, false);

        Assert.Empty(service.GetAllItems());
    }

    [Fact]
    public void GetItem_AcceptsReturnCopyParameter()
    {
        var service = new TodoService();
        service.AddItem("Task", "description", 1);

        // This test verifies the API contract - returnCopy must be accepted
        var item = service.GetItem(0, false);

        Assert.Equal("Task", item.Title);
    }

    [Fact]
    public void ClearAll_AcceptsKeepCompletedParameter()
    {
        var service = new TodoService();
        service.AddItem("Task", "description", 1);

        // This test verifies the API contract - keepCompleted must be accepted
        service.ClearAll(false);

        Assert.Empty(service.GetAllItems());
    }

    [Fact]
    public void AddItem_WithEmptyStrings_AddsItem()
    {
        var service = new TodoService();

        service.AddItem(string.Empty, string.Empty, 1);

        var items = service.GetAllItems();
        Assert.Single(items);
        Assert.Equal(string.Empty, items[0].Title);
        Assert.Equal(string.Empty, items[0].Description);
    }
}
