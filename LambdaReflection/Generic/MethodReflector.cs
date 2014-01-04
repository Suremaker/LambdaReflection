using System;
using System.Linq.Expressions;
using System.Reflection;

namespace LambdaReflection.Generic
{
	/// <summary>
	/// Provides methods for reflecting MethodInfo of <c>TType</c> member methods by using lambda expressions.
	/// </summary>
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

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Func&lt;TResult&gt;.
		/// Example usage for <c>string Method()</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TResult>(Expression<Func<TType, Func<TResult>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Func&lt;TArg1, TResult&gt;.
		/// Example usage for <c>string Method(string arg1)</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string, string&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TArg1, TResult>(Expression<Func<TType, Func<TArg1, TResult>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Func&lt;TArg1, TArg2, TResult&gt;.
		/// Example usage for <c>string Method(string arg1, int arg2)</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string, int, string&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TArg1, TArg2, TResult>(Expression<Func<TType, Func<TArg1, TArg2, TResult>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Func&lt;TArg1, TArg2, TArg3, TResult&gt;.
		/// Example usage for <c>string Method(string arg1, int arg2, long arg3)</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string, int,long string&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TArg1, TArg2, TArg3, TResult>(Expression<Func<TType, Func<TArg1, TArg2, TArg3, TResult>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Func&lt;TArg1, TArg2, TArg3, TArg4, TResult&gt;.
		/// Example usage for <c>string Method(string arg1, int arg2, long arg3, char arg4)</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string, int, long, char, string&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TArg1, TArg2, TArg3, TArg4, TResult>(Expression<Func<TType, Func<TArg1, TArg2, TArg3, TArg4, TResult>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Func&lt;TArg1, TArg2, TArg3, TArg4, TArg5, TResult&gt;.
		/// Example usage for <c>string Method(string arg1, int arg2, long arg3, char arg4, object arg5)</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string, int, long, char, object, string&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Expression<Func<TType, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Action.
		/// Example usage for <c>void Method()</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate(Expression<Func<TType, Action>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Action&lt;TArg1&gt;.
		/// Example usage for <c>void Method(string arg1)</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TArg1>(Expression<Func<TType, Action<TArg1>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Action&lt;TArg1, TArg2&gt;.
		/// Example usage for <c>void Method(string arg1, int arg2)</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string, int&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TArg1, TArg2>(Expression<Func<TType, Action<TArg1, TArg2>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Action&lt;TArg1, TArg2, TArg3&gt;.
		/// Example usage for <c>void Method(string arg1, int arg2, long arg3)</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string, int,long string&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TArg1, TArg2, TArg3>(Expression<Func<TType, Action<TArg1, TArg2, TArg3>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Action&lt;TArg1, TArg2, TArg3, TArg4&gt;.
		/// Example usage for <c>void Method(string arg1, int arg2, long arg3, char arg4)</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string, int, long, char&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TArg1, TArg2, TArg3, TArg4>(Expression<Func<TType, Action<TArg1, TArg2, TArg3, TArg4>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}

		/// <summary>
		/// Retrieves method info for delegate returned by <c>methodDelegate</c> lambda expression.
		/// The lambda expression is valid if it returns method delegate Action&lt;TArg1, TArg2, TArg3, TArg4, TArg5&gt;.
		/// Example usage for <c>void Method(string arg1, int arg2, long arg3, char arg4, object arg5)</c> would be: <code>MethodReflector&lt;MyClass&gt;.FromMethodDelegate&lt;string, int, long, char, object&gt;(instance => instance.Method)</code>.
		/// </summary>
		/// <param name="methodDelegate">Lambda expression returning method delegate</param>
		/// <returns>Method delegate.</returns>
		public static MethodInfo FromMethodDelegate<TArg1, TArg2, TArg3, TArg4, TArg5>(Expression<Func<TType, Action<TArg1, TArg2, TArg3, TArg4, TArg5>>> methodDelegate)
		{
			return methodDelegate.MethodFromDelegateResult();
		}
	}
}