using System;
using System.Globalization;
using System.Linq.Expressions;
using LambdaReflection.UnitTests.Helpers;
using NUnit.Framework;

namespace LambdaReflection.UnitTests
{
	[TestFixture]
	public class LambdaReflectorTests
	{
		[Test]
		public void Should_get_method_info_from_method_call()
		{
			Expression<Action<SomeClass>> methodCall = c => c.Foo();
			Assert.That(methodCall.MethodFromMethodCall(), Is.EqualTo(typeof(SomeClass).GetMethod("Foo", new Type[0])));
		}

		[Test]
		public void Should_get_method_info_from_method_call_with_arguments()
		{
			Expression<Action<SomeClass, string, int>> methodCall = (c, txt, val) => c.Foo(txt, val);
			Assert.That(methodCall.MethodFromMethodCall(), Is.EqualTo(typeof(SomeClass).GetMethod("Foo", new[] { typeof(string), typeof(int) })));
		}

		[Test]
		public void Should_get_method_info_from_static_method_call()
		{
			Expression<Action> methodCall = () => SomeClass.Bar();
			Assert.That(methodCall.MethodFromMethodCall(), Is.EqualTo(typeof(SomeClass).GetMethod("Bar")));
		}

		[Test]
		public void Should_get_most_outer_method_info()
		{
			Expression<Func<string>> methodCall = () => SomeClass.Bar().ToString(CultureInfo.InvariantCulture);
			Assert.That(methodCall.MethodFromMethodCall(), Is.EqualTo(typeof(int).GetMethod("ToString", new[] { typeof(IFormatProvider) })));
		}

		[Test]
		public void Should_MethodInfoFromMethodCall_throw_if_expression_is_not_method_call()
		{
			Expression<Func<object>> methodCall = () => (object)SomeClass.Bar();
			var exception = Assert.Throws<ArgumentException>(() => methodCall.MethodFromMethodCall());
			Assert.That(exception.Message, Is.EqualTo("Expected method call lambda expression, got: () => Convert(Bar())"));
		}

		[Test]
		public void Should_get_property_info_from_getter_lambda()
		{
			Expression<Func<SomeClass, string>> getterSelector = c => c.Prop;
			Assert.That(LambdaReflector.PropertyFromGetter(getterSelector), Is.EqualTo(typeof(SomeClass).GetProperty("Prop")));
		}

		[Test]
		public void Should_MethodInfoFromMethodCall_throw_if_expression_is_not_accessing_property_getter()
		{
			Expression<Action> methodCall = () => SomeClass.Bar();
			var exception = Assert.Throws<ArgumentException>(() => LambdaReflector.PropertyFromGetter(methodCall));
			Assert.That(exception.Message, Is.EqualTo("Expected getter selector lambda, got: () => Bar()"));
		}
	}
}