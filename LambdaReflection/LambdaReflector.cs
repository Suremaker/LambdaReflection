using System;
using System.Linq.Expressions;
using System.Reflection;

namespace LambdaReflection
{
	public static class LambdaReflector
	{
		/// <summary>
		/// Retrieves method info for method called in <c>methodCall</c> lambda expression.
		/// The lambda expression is valid if the most outer expression is a method call like:<example></example>
		/// <code>() => MyClass.Method("abc")</code>, <code>(instance, arg) => instance.Method(arg)</code>, etc.
		/// Please note that expression like <code>x => x.Method().ToString()</code> will return method info of ToString().
		/// </summary>
		/// <param name="methodCall">Method call lambda expression.</param>
		/// <returns>Property info.</returns>
		/// <exception cref="ArgumentException">It expects the most outer expression to be method call. If it is not, an ArgumentException is thrown.</exception>
		public static MethodInfo MethodFromMethodCall(this LambdaExpression methodCall)
		{
			try
			{
				return ((MethodCallExpression)methodCall.Body).Method;
			}
			catch (Exception e)
			{
				throw new ArgumentException(string.Format("Expected method call lambda expression, got: {0}", methodCall), e);
			}
		}

		/// <summary>
		/// Retrieves property info for property specified by <c>getterSelector</c> lambda expression in format <code>instance => instance.Property</code>.
		/// </summary>
		/// <param name="getterSelector">Getter selector lambda expression.</param>
		/// <returns>Property info.</returns>
		/// <exception cref="ArgumentException">It expects the most outer expression to be property access expression. If it is not, an ArgumentException is thrown.</exception>
		public static PropertyInfo PropertyFromGetter(this LambdaExpression getterSelector)
		{
			try
			{
				return (PropertyInfo)((MemberExpression)getterSelector.Body).Member;
			}
			catch (Exception e)
			{
				throw new ArgumentException(string.Format("Expected getter selector lambda, got: {0}", getterSelector), e);
			}
		}
	}
}
