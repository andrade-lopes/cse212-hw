/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>

public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 1");

        var cs1 = new CustomerService(-5);
        Console.WriteLine(cs1);

        Console.WriteLine("Expected: max_size should be 10");

        Console.WriteLine("=================");

        // Test 2
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 2");

        var cs2 = new CustomerService(5);

        // Add first customer
        // Add second customer (should fail)
        try
        {
            var method = typeof(CustomerService).GetMethod("ServeCustomer",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            method.Invoke(cs2, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Program crashed: " + ex.Message);
        }

        Console.WriteLine("Expected Result: The queue is empty message");

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        Console.WriteLine("Test 3");

        var cs3 = new CustomerService(1);

        // Try to serve when empty
        Console.WriteLine("Attempt to add two customers when max size is 1.");
        Console.WriteLine("Manual input required for two customers.");

        var addMethod = typeof(CustomerService).GetMethod("AddNewCustomer",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        addMethod.Invoke(cs3, null);
        addMethod.Invoke(cs3, null);

        Console.WriteLine("Expected Result: Second customer should not be added.");

        // Defect(s) Found:
        // Condition uses '>' instead of '>=' allowing one extra customer.


        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("The queue is empty.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}