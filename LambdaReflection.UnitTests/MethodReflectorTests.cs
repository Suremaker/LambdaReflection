using System;
using LambdaReflection.Generic;
using LambdaReflection.UnitTests.Helpers;
using NUnit.Framework;

namespace LambdaReflection.UnitTests
{
	[TestFixture]
	public class MethodReflectorTests
	{
		[Test]
		public void Should_find_method_based_on_call()
		{
			var methodInfo = typeof(SomeClass).GetMethod("Foo", new Type[0]);
			Assert.That(MethodReflector<SomeClass>.FromMethodCall(inst => inst.Foo()), Is.EqualTo(methodInfo));
		}

		[Test]
		public void Should_find_method_based_on_call_with_no_result()
		{
			var methodInfo = typeof(SomeClass).GetMethod("Baz", new[] { typeof(string) });
			Assert.That(MethodReflector<SomeClass>.FromMethodCall(inst => inst.Baz(null)), Is.EqualTo(methodInfo));
		}

		[Test]
		public void Should_find_method_based_on_call_with_const_params()
		{
			var methodInfo = typeof(SomeClass).GetMethod("Foo", new[] { typeof(string), typeof(int) });
			Assert.That(MethodReflector<SomeClass>.FromMethodCall(inst => inst.Foo(null, 0)), Is.EqualTo(methodInfo));
		}

		[Test]
		public void Should_find_function_based_on_returned_delegate()
		{
			var methodInfo = typeof(SomeClass).GetMethod("Foo", new Type[0]);
			Assert.That(MethodReflector<SomeClass>.FromMethodDelegate<int>(inst => inst.Foo), Is.EqualTo(methodInfo));
		}

		[Test]
		public void Should_find_function_based_on_returned_delegate_and_arguments()
		{
			var methodInfo = typeof(SomeClass).GetMethod("Foo", new[] { typeof(string), typeof(int) });
			Assert.That(MethodReflector<SomeClass>.FromMethodDelegate<string, int, int>(inst => inst.Foo), Is.EqualTo(methodInfo));
		}

		[Test]
		public void Should_find_action_based_on_returned_delegate_and_arguments()
		{
			var methodInfo = typeof(SomeClass).GetMethod("Action");
			Assert.That(MethodReflector<SomeClass>.FromMethodDelegate<int, string, long, char, object>(inst => inst.Action), Is.EqualTo(methodInfo));
		}
	}
}