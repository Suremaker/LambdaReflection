using System.Reflection;
using LambdaReflection.Generic;
using LambdaReflection.UnitTests.Helpers;
using NUnit.Framework;

namespace LambdaReflection.UnitTests
{
	[TestFixture]
	public class PropertyReflectorTests
	{
		[Test]
		public void Should_find_property_based_on_getter_method()
		{
			PropertyInfo propertyInfo = typeof(SomeClass).GetProperty("GetterOnly");

			Assert.That(PropertyReflector<SomeClass>.FromGetter(c => c.GetterOnly), Is.EqualTo(propertyInfo));
		}

		[Test]
		public void Should_find_property_based_on_setter_method()
		{
			PropertyInfo propertyInfo = typeof(SomeClass).GetProperty("SetterOnly");

			Assert.That(PropertyReflector<SomeClass>.FromSetter(c => c.SetterOnly = 0), Is.EqualTo(propertyInfo));
		}

		[Test]
		public void Should_find_property_based_on_setter_method_and_argument()
		{
			PropertyInfo propertyInfo = typeof(SomeClass).GetProperty("SetterOnly");

			Assert.That(PropertyReflector<SomeClass>.FromSetter<long>((c, arg) => c.SetterOnly = arg), Is.EqualTo(propertyInfo));
		}
	}
}