using System;

namespace raytracer
{
	public class MyTuple
	{
		public MyTuple()
		{
		}

		public static Tuple<int, int, int, int> add(Tuple<int, int, int, int> a, Tuple<int, int, int, int> b)
		{
			return Tuple.Create(a.Item1 + b.Item1, a.Item2 + b.Item2, a.Item3 + b.Item3, a.Item4 + b.Item4);
		}
	}
}

