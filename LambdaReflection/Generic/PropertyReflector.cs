using System;
using System.Linq.Expressions;
using System.Reflection;
using DelegateDecompiler;

namespace LambdaReflection.Generic
{
	/// <summary>
	/// Provides methods for reflecting PropertyInfo of <c>TType</c> member properties by using lambda expressions.
	/// </summary>
	public static class PropertyReflector<TType>
	{
		/// <summary>
		/// Returns property info for property specified by <c>getterSelector</c> lambda expression in format <code>instance => instance.Property</code>.
		/// </summary>
		/// <typeparam name="TArg">Property value type.</typeparam>
		/// <param name="getterSelector">Property selector.</param>
		/// <returns>Property info.</returns>
		public static PropertyInfo FromGetter<TArg>(Expression<Func<TType, TArg>> getterSelector)
		{
			return getterSelector.PropertyFromGetter();
		}

		/// <summary>
		/// Returns property info for property specified by <c>setterSelector</c> lambda expression in format <code>(instance, value) => instance.Property = value</code>.
		/// </summary>
		/// <typeparam name="TArg">Property value type.</typeparam>
		/// <param name="setterSelector">Property selector.</param>
		/// <returns>Property info.</returns>
		public static PropertyInfo FromSetter<TArg>(Action<TType, TArg> setterSelector)
		{
			return setterSelector.Decompile().MethodFromMethodCall().PropertyFromAccessor();
		}

		/// <summary>
		/// Returns property info for property specified by <c>setterSelector</c> lambda expression in format <code>instance => instance.Property = constant</code>.
		/// </summary>
		/// <param name="setterSelector">Property selector.</param>
		/// <returns>Property info.</returns>
		public static PropertyInfo FromSetter(Action<TType> setterSelector)
		{
			return setterSelector.Decompile().MethodFromMethodCall().PropertyFromAccessor();
		}
	}
}
