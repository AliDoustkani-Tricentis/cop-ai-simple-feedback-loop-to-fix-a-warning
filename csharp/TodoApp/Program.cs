namespace TodoApp;

class Program
{
    static void Main(string[] args)
    {
        var service = new TodoService();
        var running = true;

        Console.WriteLine("=== Simple Todo App ===");
        Console.WriteLine("Commands: add, list, complete, remove, clear, quit");
        Console.WriteLine();

        while (running)
        {
            Console.Write("> ");
            var input = Console.ReadLine()?.Trim().ToLower();

            switch (input)
            {
                case "add":
                    Console.Write("Title: ");
                    var title = Console.ReadLine();
                    Console.Write("Description: ");
                    var description = Console.ReadLine();
                    service.AddItem(title, description, 1);
                    Console.WriteLine("Item added!");
                    break;

                case "list":
                    var items = service.GetAllItems();
                    if (items.Count == 0)
                    {
                        Console.WriteLine("No items.");
                    }
                    else
                    {
                        for (int i = 0; i < items.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {items[i]}");
                        }
                    }
                    break;

                case "complete":
                    Console.Write("Item number: ");
                    if (int.TryParse(Console.ReadLine(), out int completeIndex))
                    {
                        service.CompleteItem(completeIndex - 1);
                        Console.WriteLine("Item marked complete!");
                    }
                    break;

                case "remove":
                    Console.Write("Item number: ");
                    if (int.TryParse(Console.ReadLine(), out int removeIndex))
                    {
                        service.RemoveItem(removeIndex - 1, false);
                        Console.WriteLine("Item removed!");
                    }
                    break;

                case "clear":
                    service.ClearAll(false);
                    Console.WriteLine("All items cleared!");
                    break;

                case "quit":
                case "exit":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
