using Xunit;
using raytracer;

namespace raytracer.Tests;

public class MyTupleTest
{
    [Fact]
    public void Test1()
    {
        Tuple<int, int, int, int> tuple1 = Tuple.Create(1, 2, 3, 4);
        Tuple<int, int, int, int> tuple2 = Tuple.Create(6, 6, 7, 8);
        var tuple3 = MyTuple.add(tuple1, tuple2);
        tuple3 = tuple1 + tuple2;
        Assert.Equal(7, tuple3.Item1);
        Assert.Equal(8, tuple3.Item2);
        Assert.Equal(10, tuple3.Item3);
        Assert.Equal(12, tuple3.Item4);
    }
}
