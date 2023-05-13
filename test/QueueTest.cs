using System.Diagnostics;
using Wooly905.DataStructures;
using Xunit;

namespace Test;

public class RecentItemQueueTests
{
    [Fact]
    public void GetEmptyTest()
    {
        RecentItemQueue<QueueTest> queue = new(10);
        IReadOnlyList<QueueTest> result = queue.GetItems();

        Assert.Equal(0, result.Count);
    }

    [Fact]
    public void SetItemsTest()
    {
        RecentItemQueue<QueueTest> queue = new(10);
        queue.SetItem(new QueueTest(1));
        queue.SetItem(new QueueTest(2));
        queue.SetItem(new QueueTest(3));
        IReadOnlyList<QueueTest> result = queue.GetItems();

        Assert.Equal(3, result.Count);
        Assert.Equal(3, result[0].Id);
        Assert.Equal(2, result[1].Id);
        Assert.Equal(1, result[2].Id);
    }

    [Fact]
    public void MutlipleSetItemsTest()
    {
        RecentItemQueue<QueueTest> queue = new(10);
        queue.SetItem(new QueueTest(1));
        queue.SetItem(new QueueTest(2));
        queue.SetItem(new QueueTest(3));
        queue.SetItem(new QueueTest(1));
        IReadOnlyList<QueueTest> result = queue.GetItems();

        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0].Id);
        Assert.Equal(3, result[1].Id);
        Assert.Equal(2, result[2].Id);
    }

    [Fact]
    public void SetItemsInCircularRoundTest()
    {
        int size = 4;
        RecentItemQueue<QueueTest> queue = new(size);
        queue.SetItem(new QueueTest(1));
        IReadOnlyList<QueueTest> result = queue.GetItems();
        Assert.Equal(1, result.Count);
        Assert.Equal(1, result[0].Id);

        queue.SetItem(new QueueTest(2));
        result = queue.GetItems();
        Assert.Equal(2, result.Count);
        Assert.Equal(2, result[0].Id);
        Assert.Equal(1, result[1].Id);

        queue.SetItem(new QueueTest(3));
        result = queue.GetItems();
        Assert.Equal(3, result.Count);
        Assert.Equal(3, result[0].Id);
        Assert.Equal(2, result[1].Id);
        Assert.Equal(1, result[2].Id);

        queue.SetItem(new QueueTest(4));
        result = queue.GetItems();
        Assert.Equal(4, result.Count);
        Assert.Equal(4, result[0].Id);
        Assert.Equal(3, result[1].Id);
        Assert.Equal(2, result[2].Id);
        Assert.Equal(1, result[3].Id);

        queue.SetItem(new QueueTest(5));
        result = queue.GetItems();
        Assert.Equal(size, result.Count);
        Assert.Equal(5, result[0].Id);
        Assert.Equal(4, result[1].Id);
        Assert.Equal(3, result[2].Id);
        Assert.Equal(2, result[3].Id);

        queue.SetItem(new QueueTest(6));
        result = queue.GetItems();
        Assert.Equal(size, result.Count);
        Assert.Equal(6, result[0].Id);
        Assert.Equal(5, result[1].Id);
        Assert.Equal(4, result[2].Id);
        Assert.Equal(3, result[3].Id);

        queue.SetItem(new QueueTest(7));
        result = queue.GetItems();
        Assert.Equal(size, result.Count);
        Assert.Equal(7, result[0].Id);
        Assert.Equal(6, result[1].Id);
        Assert.Equal(5, result[2].Id);
        Assert.Equal(4, result[3].Id);

        queue.SetItem(new QueueTest(8));
        result = queue.GetItems();
        Assert.Equal(size, result.Count);
        Assert.Equal(8, result[0].Id);
        Assert.Equal(7, result[1].Id);
        Assert.Equal(6, result[2].Id);
        Assert.Equal(5, result[3].Id);
    }

    [Fact]
    public void MultipleSetItemsInCircularRoundTest()
    {
        int size = 4;
        RecentItemQueue<QueueTest> queue = new(size);
        queue.SetItem(new QueueTest(1));
        queue.SetItem(new QueueTest(2));
        queue.SetItem(new QueueTest(3));
        queue.SetItem(new QueueTest(4));
        queue.SetItem(new QueueTest(5));
        IReadOnlyList<QueueTest> result = queue.GetItems();

        Assert.Equal(size, result.Count);
        Assert.Equal(5, result[0].Id);
        Assert.Equal(4, result[1].Id);
        Assert.Equal(3, result[2].Id);
        Assert.Equal(2, result[3].Id);

        queue.SetItem(new QueueTest(5));
        IReadOnlyList<QueueTest> result2 = queue.GetItems();

        Assert.Equal(size, result2.Count);
        Assert.Equal(5, result2[0].Id);
        Assert.Equal(4, result2[1].Id);
        Assert.Equal(3, result2[2].Id);
        Assert.Equal(2, result2[3].Id);
    }

    [Fact]
    public void MultipleSetItemsInCircularRound2Test()
    {
        int size = 4;
        RecentItemQueue<QueueTest> queue = new(size);
        queue.SetItem(new QueueTest(1));
        queue.SetItem(new QueueTest(2));
        queue.SetItem(new QueueTest(3));
        queue.SetItem(new QueueTest(4));
        queue.SetItem(new QueueTest(5));
        IReadOnlyList<QueueTest> result = queue.GetItems();

        Assert.Equal(size, result.Count);
        Assert.Equal(5, result[0].Id);
        Assert.Equal(4, result[1].Id);
        Assert.Equal(3, result[2].Id);
        Assert.Equal(2, result[3].Id);

        queue.SetItem(new QueueTest(2));
        IReadOnlyList<QueueTest> result2 = queue.GetItems();

        Assert.Equal(size, result2.Count);
        Assert.Equal(2, result2[0].Id);
        Assert.Equal(5, result2[1].Id);
        Assert.Equal(4, result2[2].Id);
        Assert.Equal(3, result2[3].Id);
    }
}

[DebuggerDisplay("Id = {Id}")]
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
internal class QueueTest
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
{
    public QueueTest(int id)
    {
        Id = id;
    }

    public int Id { get; }

    public override bool Equals(object obj)
    {
        return obj is QueueTest t && t.Id == Id;
    }
}
