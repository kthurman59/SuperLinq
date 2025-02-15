﻿namespace SuperLinq;

public static partial class SuperEnumerable
{

	/// <summary>
	/// Splits the source sequence by a separator.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separator">Separator element.</param>
	/// <returns>A sequence of splits of elements.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	public static IEnumerable<IEnumerable<TSource>> Split<TSource>(
		this IEnumerable<TSource> source,
		TSource separator)
	{
		return Split(source, separator, count: int.MaxValue);
	}

	/// <summary>
	/// Splits the source sequence by a separator given a maximum count of splits.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separator">Separator element.</param>
	/// <param name="count">Maximum number of splits.</param>
	/// <returns>A sequence of splits of elements.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is less than 1.</exception>
	public static IEnumerable<IEnumerable<TSource>> Split<TSource>(
		this IEnumerable<TSource> source,
		TSource separator, int count)
	{
		return Split(source, separator, count, Identity);
	}

	/// <summary>
	/// Splits the source sequence by a separator and then transforms
	/// the splits into results.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <typeparam name="TResult">Type of the result sequence elements.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separator">Separator element.</param>
	/// <param name="resultSelector">Function used to project splits
	/// of source elements into elements of the resulting sequence.</param>
	/// <returns>
	/// A sequence of values typed as <typeparamref name="TResult"/>.
	/// </returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="resultSelector"/> is <see langword="null"/>.</exception>
	public static IEnumerable<TResult> Split<TSource, TResult>(
		this IEnumerable<TSource> source,
		TSource separator,
		Func<IEnumerable<TSource>, TResult> resultSelector)
	{
		return Split(source, separator, count: int.MaxValue, resultSelector);
	}

	/// <summary>
	/// Splits the source sequence by a separator, given a maximum count
	/// of splits, and then transforms the splits into results.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <typeparam name="TResult">Type of the result sequence elements.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separator">Separator element.</param>
	/// <param name="count">Maximum number of splits.</param>
	/// <param name="resultSelector">Function used to project splits
	/// of source elements into elements of the resulting sequence.</param>
	/// <returns>
	/// A sequence of values typed as <typeparamref name="TResult"/>.
	/// </returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="resultSelector"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is less than 1.</exception>
	public static IEnumerable<TResult> Split<TSource, TResult>(
		this IEnumerable<TSource> source,
		TSource separator, int count,
		Func<IEnumerable<TSource>, TResult> resultSelector)
	{
		return Split(source, separator, comparer: null, count, resultSelector);
	}

	/// <summary>
	/// Splits the source sequence by a separator and then transforms the
	/// splits into results.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separator">Separator element.</param>
	/// <param name="comparer">Comparer used to determine separator
	/// element equality.</param>
	/// <returns>A sequence of splits of elements.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	public static IEnumerable<IEnumerable<TSource>> Split<TSource>(
		this IEnumerable<TSource> source,
		TSource separator, IEqualityComparer<TSource>? comparer)
	{
		return Split(source, separator, comparer, count: int.MaxValue);
	}

	/// <summary>
	/// Splits the source sequence by a separator, given a maximum count
	/// of splits. A parameter specifies how the separator is compared
	/// for equality.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separator">Separator element.</param>
	/// <param name="comparer">Comparer used to determine separator
	/// element equality.</param>
	/// <param name="count">Maximum number of splits.</param>
	/// <returns>A sequence of splits of elements.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is less than 1.</exception>
	public static IEnumerable<IEnumerable<TSource>> Split<TSource>(
		this IEnumerable<TSource> source,
		TSource separator, IEqualityComparer<TSource>? comparer, int count)
	{
		return Split(source, separator, comparer, count, Identity);
	}

	/// <summary>
	/// Splits the source sequence by a separator and then transforms the
	/// splits into results. A parameter specifies how the separator is
	/// compared for equality.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <typeparam name="TResult">Type of the result sequence elements.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separator">Separator element.</param>
	/// <param name="comparer">Comparer used to determine separator
	/// element equality.</param>
	/// <param name="resultSelector">Function used to project splits
	/// of source elements into elements of the resulting sequence.</param>
	/// <returns>
	/// A sequence of values typed as <typeparamref name="TResult"/>.
	/// </returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="resultSelector"/> is <see langword="null"/>.</exception>
	public static IEnumerable<TResult> Split<TSource, TResult>(
		this IEnumerable<TSource> source,
		TSource separator, IEqualityComparer<TSource> comparer,
		Func<IEnumerable<TSource>, TResult> resultSelector)
	{
		return Split(source, separator, comparer, count: int.MaxValue, resultSelector);
	}

	/// <summary>
	/// Splits the source sequence by a separator, given a maximum count
	/// of splits, and then transforms the splits into results. A
	/// parameter specifies how the separator is compared for equality.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <typeparam name="TResult">Type of the result sequence elements.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separator">Separator element.</param>
	/// <param name="comparer">Comparer used to determine separator
	/// element equality.</param>
	/// <param name="count">Maximum number of splits.</param>
	/// <param name="resultSelector">Function used to project splits
	/// of source elements into elements of the resulting sequence.</param>
	/// <returns>
	/// A sequence of values typed as <typeparamref name="TResult"/>.
	/// </returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="resultSelector"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is less than 1.</exception>
	public static IEnumerable<TResult> Split<TSource, TResult>(
		this IEnumerable<TSource> source,
		TSource separator, IEqualityComparer<TSource>? comparer, int count,
		Func<IEnumerable<TSource>, TResult> resultSelector)
	{
		Guard.IsNotNull(source);
		Guard.IsGreaterThanOrEqualTo(count, 1);
		Guard.IsNotNull(resultSelector);

		comparer ??= EqualityComparer<TSource>.Default;
		return Split(source, item => comparer.Equals(item, separator), count, resultSelector);
	}

	/// <summary>
	/// Splits the source sequence by separator elements identified by a
	/// function.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separatorFunc">Predicate function used to determine
	/// the splitter elements in the source sequence.</param>
	/// <returns>A sequence of splits of elements.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="separatorFunc"/> is <see langword="null"/>.</exception>
	public static IEnumerable<IEnumerable<TSource>> Split<TSource>(
		this IEnumerable<TSource> source,
		Func<TSource, bool> separatorFunc)
	{
		return Split(source, separatorFunc, count: int.MaxValue);
	}

	/// <summary>
	/// Splits the source sequence by separator elements identified by a
	/// function, given a maximum count of splits.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separatorFunc">Predicate function used to determine
	/// the splitter elements in the source sequence.</param>
	/// <param name="count">Maximum number of splits.</param>
	/// <returns>A sequence of splits of elements.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="separatorFunc"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is less than 1.</exception>
	public static IEnumerable<IEnumerable<TSource>> Split<TSource>(
		this IEnumerable<TSource> source,
		Func<TSource, bool> separatorFunc, int count)
	{
		return Split(source, separatorFunc, count, Identity);
	}

	/// <summary>
	/// Splits the source sequence by separator elements identified by
	/// a function and then transforms the splits into results.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <typeparam name="TResult">Type of the result sequence elements.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separatorFunc">Predicate function used to determine
	/// the splitter elements in the source sequence.</param>
	/// <param name="resultSelector">Function used to project splits
	/// of source elements into elements of the resulting sequence.</param>
	/// <returns>
	/// A sequence of values typed as <typeparamref name="TResult"/>.
	/// </returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="separatorFunc"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="resultSelector"/> is <see langword="null"/>.</exception>
	public static IEnumerable<TResult> Split<TSource, TResult>(
		this IEnumerable<TSource> source,
		Func<TSource, bool> separatorFunc,
		Func<IEnumerable<TSource>, TResult> resultSelector)
	{
		return Split(source, separatorFunc, count: int.MaxValue, resultSelector);
	}

	/// <summary>
	/// Splits the source sequence by separator elements identified by
	/// a function, given a maximum count of splits, and then transforms
	/// the splits into results.
	/// </summary>
	/// <typeparam name="TSource">Type of element in the source sequence.</typeparam>
	/// <typeparam name="TResult">Type of the result sequence elements.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="separatorFunc">Predicate function used to determine
	/// the splitter elements in the source sequence.</param>
	/// <param name="count">Maximum number of splits.</param>
	/// <param name="resultSelector">Function used to project a split
	/// group of source elements into an element of the resulting sequence.</param>
	/// <returns>
	/// A sequence of values typed as <typeparamref name="TResult"/>.
	/// </returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="separatorFunc"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="resultSelector"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is less than 1.</exception>
	public static IEnumerable<TResult> Split<TSource, TResult>(
		this IEnumerable<TSource> source,
		Func<TSource, bool> separatorFunc, int count,
		Func<IEnumerable<TSource>, TResult> resultSelector)
	{
		Guard.IsNotNull(source);
		Guard.IsNotNull(separatorFunc);
		Guard.IsGreaterThanOrEqualTo(count, 1);
		Guard.IsNotNull(resultSelector);

		return Core(source, separatorFunc, count, resultSelector);

		static IEnumerable<TResult> Core(IEnumerable<TSource> source, Func<TSource, bool> separatorFunc, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			var items = new List<TSource>();

			foreach (var item in source)
			{
				if (count > 0 && separatorFunc(item))
				{
					yield return resultSelector(items);
					count--;
					items = new();
				}
				else
				{
					items.Add(item);
				}
			}

			if (items.Count > 0)
				yield return resultSelector(items);
		}
	}
}
