﻿namespace SuperLinq.Async;

public static partial class AsyncSuperEnumerable
{
	/// <summary>
	/// Creates a sequence whose termination or disposal of an enumerator causes a finally action to be executed.
	/// </summary>
	/// <typeparam name="TSource">Source sequence element type.</typeparam>
	/// <param name="source">Source sequence.</param>
	/// <param name="finallyAction">Action to run upon termination of the sequence, or when an enumerator is
	/// disposed.</param>
	/// <returns>Source sequence with guarantees on the invocation of the finally action.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="finallyAction"/> is <see
	/// langword="null"/>.</exception>
	/// <remarks>
	/// <para>
	/// This method uses deferred execution and streams its results.
	/// </para>
	/// </remarks>
	public static IAsyncEnumerable<TSource> Finally<TSource>(this IAsyncEnumerable<TSource> source, Action finallyAction)
	{
		Guard.IsNotNull(source);
		Guard.IsNotNull(finallyAction);

		return Core(source, finallyAction);

		static async IAsyncEnumerable<TSource> Core(
			IAsyncEnumerable<TSource> source, Action finallyAction,
			[EnumeratorCancellation] CancellationToken cancellationToken = default)
		{
			try
			{
				await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
					yield return item;
			}
			finally
			{
				finallyAction();
			}
		}
	}
}
