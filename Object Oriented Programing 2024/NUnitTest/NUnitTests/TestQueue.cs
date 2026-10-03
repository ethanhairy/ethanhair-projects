using NUnitTest;

namespace NUnitTests;

public class Tests
{

    private IntegerQueue myQueue;

    [SetUp]
    public void Setup()
    {
        myQueue = new IntegerQueue();
        myQueue.Enqueue(12345);
    }
    

    [Test]
    public void TestEnqueue()
    {
        int myCount = myQueue.Count;

        Assert.That(myCount, Is.EqualTo(1));

        Assert.That(myQueue._elements.Count, Is.EqualTo(1));
        Assert.That(myQueue._elements[0], Is.EqualTo(12345));
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
