using System;
using System.Linq;
using System.Reflection;

namespace LambdaReflection
{
	/// <summary>
	/// Extends MethodInfo with method allowing to determine property info basing on accessor method.
	/// </summary>
	public static class MethodInfoReflector
	{
		/// <summary>
		/// Returns property info of property which get or set method is <c>propertyAccessorMethod</c>.
		/// </summary>
		/// <param name="propertyAccessorMethod">Property accessor method.</param>
		/// <returns>Property info.</returns>
		/// <exception cref="ArgumentException">If given method is not property accessor, an ArgumentException is thrown.</exception>
		public static PropertyInfo PropertyFromAccessor(this MethodInfo propertyAccessorMethod)
		{
			PropertyInfo property = null;
			if (propertyAccessorMethod != null && propertyAccessorMethod.DeclaringType != null && propertyAccessorMethod.IsSpecialName && (propertyAccessorMethod.Name.StartsWith("get_") || propertyAccessorMethod.Name.StartsWith("set_")))
			{
				property = propertyAccessorMethod.DeclaringType
					.GetProperties(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
					.FirstOrDefault(p => p.GetGetMethod() == propertyAccessorMethod || p.GetSetMethod() == propertyAccessorMethod);
			}
			if (property != null)
				return property;

			throw new ArgumentException(string.Format("Unable to find property which get or set method is: {0}", propertyAccessorMethod));
		}
	}
}