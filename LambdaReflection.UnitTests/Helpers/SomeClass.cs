namespace LambdaReflection.UnitTests.Helpers
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

		public void Baz(string x) { }

		public void Action(int a1, string a2, long a3, char a4, object a5) { }
	}
}