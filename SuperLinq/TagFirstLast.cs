﻿namespace SuperLinq;

partial class SuperEnumerable
{
	/// <summary>
	/// Returns a sequence resulting from applying a function to each
	/// element in the source sequence with additional parameters
	/// indicating whether the element is the first and/or last of the
	/// sequence.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
	/// <typeparam name="TResult">The type of the element of the returned sequence.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="resultSelector">A function that determines how to
	/// project the each element along with its first or last tag.</param>
	/// <returns>
	/// Returns the resulting sequence.
	/// </returns>
	/// <remarks>
	/// This operator uses deferred execution and streams its results.
	/// </remarks>
	/// <example>
	/// <code><![CDATA[
	/// var numbers = new[] { 123, 456, 789 };
	/// var result = numbers.TagFirstLast((num, fst, lst) => new
	///              {
	///                  Number = num,
	///                  IsFirst = fst, IsLast = lst
	///              });
	/// ]]></code>
	/// The <c>result</c> variable, when iterated over, will yield
	/// <c>{ Number = 123, IsFirst = True, IsLast = False }</c>,
	/// <c>{ Number = 456, IsFirst = False, IsLast = False }</c> and
	/// <c>{ Number = 789, IsFirst = False, IsLast = True }</c> in turn.
	/// </example>

	public static IEnumerable<TResult> TagFirstLast<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool, bool, TResult> resultSelector)
	{
		if (source == null) throw new ArgumentNullException(nameof(source));
		if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

		return source.Index() // count-up
					 .CountDown(1, (e, cd) => resultSelector(e.item, e.index == 0, cd == 0));
	}
}