using System;
using System.Linq.Expressions;
using System.Reflection;

namespace LambdaReflection.Generic
{
	public static class MethodReflector<TType>
	{
		/// <summary>
		/// Retrieves method info for method called in <c>methodCall</c> lambda expression.
		/// The lambda expression is valid if the most outer expression is a method call like: <code>instance => instance.Method()</code>.
		/// Please note that expression like <code>x => x.Method().ToString()</code> will return method info of ToString().
		/// </summary>
		/// <param name="methodCall">Method call lambda expression.</param>
		/// <returns>Property info.</returns>
		/// <exception cref="ArgumentException">It expects the most outer expression to be method call. If it is not, an ArgumentException is thrown.</exception>
		public static MethodInfo FromMethodCall(Expression<Action<TType>> methodCall)
		{
			return methodCall.MethodFromMethodCall();
		}

		/// <summary>
		/// Retrieves method info for method called in <c>methodCall</c> lambda expression.
		/// The lambda expression is valid if the most outer expression is a method call like: <code>instance => instance.Method()</code>.
		/// Please note that expression like <code>x => x.Method().ToString()</code> will return method info of ToString().
		/// </summary>
		/// <param name="methodCall">Method call lambda expression.</param>
		/// <returns>Property info.</returns>
		/// <exception cref="ArgumentException">It expects the most outer expression to be method call. If it is not, an ArgumentException is thrown.</exception>
		public static MethodInfo FromMethodCall<TResult>(Expression<Func<TType, TResult>> methodCall)
		{
			return methodCall.MethodFromMethodCall();
		}
	}
}