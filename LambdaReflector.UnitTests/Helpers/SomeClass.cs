namespace LambdaReflector.UnitTests.Helpers
{
	class SomeClass
	{
		public string Prop { get; set; }
		public int GetterOnly { get; private set; }
		public long SetterOnly { private get; set; }

		public int Foo()
		{
			return 1;
		}

		public int Foo(string arg, int x)
		{
			return 0;
		}

		public static int Bar()
		{
			return 5;
		}
	}
}