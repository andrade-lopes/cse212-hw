using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities
    // Expected Result: Item with highest priority is returned first
    // Defect(s) Found: 
    public void TestPriorityQueue_HighestPriority()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("A", 1);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 3);

        var result = queue.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Add items with same priority
    // Expected Result: First item added is returned first (FIFO)
    // Defect(s) Found:
    public void TestPriorityQueue_FIFO()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("A", 5);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 5);

        Assert.AreEqual("A", queue.Dequeue());
        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("C", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with duplicates
    // Expected Result: Highest priority first, FIFO for ties
    // Defect(s) Found:
    public void TestPriorityQueue_Mixed()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("A", 1);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 3);
        queue.Enqueue("D", 2);

        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("C", queue.Dequeue());
        Assert.AreEqual("D", queue.Dequeue());
        Assert.AreEqual("A", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException thrown
    // Defect(s) Found:
    public void TestPriorityQueue_Empty()
    {
        var queue = new PriorityQueue();

        try
        {
            queue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    // Add more test cases as needed below.
}