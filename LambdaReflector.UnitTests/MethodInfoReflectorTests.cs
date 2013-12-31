using System;
using System.Reflection;
using LambdaReflector.UnitTests.Helpers;
using NUnit.Framework;

namespace LambdaReflector.UnitTests
{
	[TestFixture]
	public class MethodInfoReflectorTests
	{
		[Test]
		public void Should_find_property_based_on_getter_method()
		{
			PropertyInfo propertyInfo = typeof(IFoo).GetProperty("Text");
			Assert.That(propertyInfo.GetGetMethod().PropertyFromAccessor(), Is.EqualTo(propertyInfo));
		}

		[Test]
		public void Should_find_property_based_on_setter_method()
		{
			PropertyInfo propertyInfo = typeof(IFoo).GetProperty("Text");
			Assert.That(propertyInfo.GetSetMethod().PropertyFromAccessor(), Is.EqualTo(propertyInfo));
		}

		[Test]
		public void Should_throw_if_method_is_not_property_accessor()
		{
			var exception = Assert.Throws<ArgumentException>(() => typeof(IFoo).GetMethod("Foo").PropertyFromAccessor());
			Assert.That(exception.Message, Is.EqualTo("Unable to find property which get or set method is: Void Foo()"));
		}
	}
}