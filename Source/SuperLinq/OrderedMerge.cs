﻿namespace SuperLinq;

public static partial class SuperEnumerable
{
	/// <summary>
	/// Merges two ordered sequences into one. Where the elements equal
	/// in both sequences, the element from the first sequence is
	/// returned in the resulting sequence.
	/// </summary>
	/// <typeparam name="T">Type of elements in input and output sequences.</typeparam>
	/// <param name="first">The first input sequence.</param>
	/// <param name="second">The second input sequence.</param>
	/// <returns>
	/// A sequence with elements from the two input sequences merged, as
	/// in a full outer join.
	/// </returns>
	/// <exception cref="ArgumentNullException"><paramref name="first"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="second"/> is <see langword="null"/>.</exception>
	/// <remarks>
	/// This method uses deferred execution. The behavior is undefined
	/// if the sequences are unordered as inputs.
	/// </remarks>
	[Obsolete("OrderedMerge has been replaced by FullOuterJoin")]
	public static IEnumerable<T> OrderedMerge<T>(
		this IEnumerable<T> first,
		IEnumerable<T> second)
	{
		return OrderedMerge(first, second, Identity, Identity, Identity, static (a, _) => a);
	}

	/// <summary>
	/// Merges two ordered sequences into one with an additional
	/// parameter specifying how to compare the elements of the
	/// sequences. Where the elements equal in both sequences, the
	/// element from the first sequence is returned in the resulting
	/// sequence.
	/// </summary>
	/// <typeparam name="T">Type of elements in input and output sequences.</typeparam>
	/// <param name="first">The first input sequence.</param>
	/// <param name="second">The second input sequence.</param>
	/// <param name="comparer">An <see cref="IComparer{T}"/> to compare elements.</param>
	/// <returns>
	/// A sequence with elements from the two input sequences merged, as
	/// in a full outer join.
	/// </returns>
	/// <exception cref="ArgumentNullException"><paramref name="first"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="second"/> is <see langword="null"/>.</exception>
	/// <remarks>
	/// This method uses deferred execution. The behavior is undefined
	/// if the sequences are unordered as inputs.
	/// </remarks>
	[Obsolete("OrderedMerge has been replaced by FullOuterJoin")]
	public static IEnumerable<T> OrderedMerge<T>(
		this IEnumerable<T> first,
		IEnumerable<T> second,
		IComparer<T>? comparer)
	{
		return OrderedMerge(first, second, Identity, Identity, Identity, static (a, _) => a, comparer);
	}

	/// <summary>
	/// Merges two ordered sequences into one with an additional
	/// parameter specifying the element key by which the sequences are
	/// ordered. Where the keys equal in both sequences, the
	/// element from the first sequence is returned in the resulting
	/// sequence.
	/// </summary>
	/// <typeparam name="T">Type of elements in input and output sequences.</typeparam>
	/// <typeparam name="TKey">Type of keys used for merging.</typeparam>
	/// <param name="first">The first input sequence.</param>
	/// <param name="second">The second input sequence.</param>
	/// <param name="keySelector">Function to extract a key given an element.</param>
	/// <returns>
	/// A sequence with elements from the two input sequences merged
	/// according to a key, as in a full outer join.
	/// </returns>
	/// <exception cref="ArgumentNullException"><paramref name="first"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="second"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
	/// <remarks>
	/// This method uses deferred execution. The behavior is undefined
	/// if the sequences are unordered (by key) as inputs.
	/// </remarks>
	[Obsolete("OrderedMerge has been replaced by FullOuterJoin")]
	public static IEnumerable<T> OrderedMerge<T, TKey>(
		this IEnumerable<T> first,
		IEnumerable<T> second,
		Func<T, TKey> keySelector)
	{
		Guard.IsNotNull(keySelector);

		return OrderedMerge(first, second, keySelector, Identity, Identity, static (a, _) => a);
	}

	/// <summary>
	/// Merges two ordered sequences into one with an additional
	/// parameter specifying the element key by which the sequences are
	/// ordered. Where the keys equal in both sequences, the
	/// element from the first sequence is returned in the resulting
	/// sequence.
	/// </summary>
	/// <typeparam name="T">Type of elements in input and output sequences.</typeparam>
	/// <typeparam name="TKey">Type of keys used for merging.</typeparam>
	/// <param name="first">The first input sequence.</param>
	/// <param name="second">The second input sequence.</param>
	/// <param name="keySelector">Function to extract a key given an element.</param>
	/// <param name="comparer">An <see cref="IComparer{T}"/> to compare elements.</param>
	/// <returns>
	/// A sequence with elements from the two input sequences merged
	/// according to a key, as in a full outer join.
	/// </returns>
	/// <exception cref="ArgumentNullException"><paramref name="first"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="second"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
	/// <remarks>
	/// This method uses deferred execution. The behavior is undefined
	/// if the sequences are unordered (by key) as inputs.
	/// </remarks>
	[Obsolete("OrderedMerge has been replaced by FullOuterJoin")]
	public static IEnumerable<T> OrderedMerge<T, TKey>(
		this IEnumerable<T> first,
		IEnumerable<T> second,
		Func<T, TKey> keySelector,
		IComparer<TKey>? comparer)
	{
		Guard.IsNotNull(keySelector);

		return OrderedMerge(first, second, keySelector, Identity, Identity, static (a, _) => a, comparer);
	}

	/// <summary>
	/// Merges two ordered sequences into one. Additional parameters
	/// specify the element key by which the sequences are ordered,
	/// the result when element is found in first sequence but not in
	/// the second, the result when element is found in second sequence
	/// but not in the first and the result when elements are found in
	/// both sequences.
	/// </summary>
	/// <typeparam name="T">Type of elements in source sequences.</typeparam>
	/// <typeparam name="TKey">Type of keys used for merging.</typeparam>
	/// <typeparam name="TResult">Type of elements in the returned sequence.</typeparam>
	/// <param name="first">The first input sequence.</param>
	/// <param name="second">The second input sequence.</param>
	/// <param name="keySelector">Function to extract a key given an element.</param>
	/// <param name="firstSelector">Function to project the result element
	/// when only the first sequence yields a source element.</param>
	/// <param name="secondSelector">Function to project the result element
	/// when only the second sequence yields a source element.</param>
	/// <param name="bothSelector">Function to project the result element
	/// when only both sequences yield a source element whose keys are
	/// equal.</param>
	/// <returns>
	/// A sequence with projections from the two input sequences merged
	/// according to a key, as in a full outer join.</returns>
	/// <remarks>
	/// This method uses deferred execution. The behavior is undefined
	/// if the sequences are unordered (by key) as inputs.
	/// </remarks>
	[Obsolete("OrderedMerge has been replaced by FullOuterJoin")]
	public static IEnumerable<TResult> OrderedMerge<T, TKey, TResult>(
		this IEnumerable<T> first,
		IEnumerable<T> second,
		Func<T, TKey> keySelector,
		Func<T, TResult> firstSelector,
		Func<T, TResult> secondSelector,
		Func<T, T, TResult> bothSelector)
	{
		Guard.IsNotNull(first);
		Guard.IsNotNull(second);
		Guard.IsNotNull(keySelector);
		Guard.IsNotNull(firstSelector);
		Guard.IsNotNull(bothSelector);
		Guard.IsNotNull(secondSelector);

		return MergeJoin(
			first, second,
			JoinOperation.FullOuter,
			keySelector, keySelector,
			firstSelector, secondSelector,
			bothSelector,
			Comparer<TKey>.Default);
	}

	/// <summary>
	/// Merges two ordered sequences into one. Additional parameters
	/// specify the element key by which the sequences are ordered,
	/// the result when element is found in first sequence but not in
	/// the second, the result when element is found in second sequence
	/// but not in the first, the result when elements are found in
	/// both sequences and a method for comparing keys.
	/// </summary>
	/// <typeparam name="T">Type of elements in source sequences.</typeparam>
	/// <typeparam name="TKey">Type of keys used for merging.</typeparam>
	/// <typeparam name="TResult">Type of elements in the returned sequence.</typeparam>
	/// <param name="first">The first input sequence.</param>
	/// <param name="second">The second input sequence.</param>
	/// <param name="keySelector">Function to extract a key given an element.</param>
	/// <param name="firstSelector">Function to project the result element
	/// when only the first sequence yields a source element.</param>
	/// <param name="secondSelector">Function to project the result element
	/// when only the second sequence yields a source element.</param>
	/// <param name="bothSelector">Function to project the result element
	/// when only both sequences yield a source element whose keys are
	/// equal.</param>
	/// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
	/// <returns>
	/// A sequence with projections from the two input sequences merged
	/// according to a key, as in a full outer join.</returns>
	/// <remarks>
	/// This method uses deferred execution. The behavior is undefined
	/// if the sequences are unordered (by key) as inputs.
	/// </remarks>
	[Obsolete("OrderedMerge has been replaced by FullOuterJoin")]
	public static IEnumerable<TResult> OrderedMerge<T, TKey, TResult>(
		this IEnumerable<T> first,
		IEnumerable<T> second,
		Func<T, TKey> keySelector,
		Func<T, TResult> firstSelector,
		Func<T, TResult> secondSelector,
		Func<T, T, TResult> bothSelector,
		IComparer<TKey>? comparer)
	{
		Guard.IsNotNull(first);
		Guard.IsNotNull(second);
		Guard.IsNotNull(keySelector);
		Guard.IsNotNull(firstSelector);
		Guard.IsNotNull(bothSelector);
		Guard.IsNotNull(secondSelector);

		return MergeJoin(
				first, second,
				JoinOperation.FullOuter,
				keySelector, keySelector,
				firstSelector, secondSelector,
				bothSelector,
				comparer ?? Comparer<TKey>.Default);
	}

	/// <summary>
	/// Merges two heterogeneous sequences ordered by a common key type
	/// into a homogeneous one. Additional parameters specify the
	/// element key by which the sequences are ordered, the result when
	/// element is found in first sequence but not in the second and
	/// the result when element is found in second sequence but not in
	/// the first, the result when elements are found in both sequences.
	/// </summary>
	/// <typeparam name="TFirst">Type of elements in the first sequence.</typeparam>
	/// <typeparam name="TSecond">Type of elements in the second sequence.</typeparam>
	/// <typeparam name="TKey">Type of keys used for merging.</typeparam>
	/// <typeparam name="TResult">Type of elements in the returned sequence.</typeparam>
	/// <param name="first">The first input sequence.</param>
	/// <param name="second">The second input sequence.</param>
	/// <param name="firstKeySelector">Function to extract a key given an
	/// element from the first sequence.</param>
	/// <param name="secondKeySelector">Function to extract a key given an
	/// element from the second sequence.</param>
	/// <param name="firstSelector">Function to project the result element
	/// when only the first sequence yields a source element.</param>
	/// <param name="secondSelector">Function to project the result element
	/// when only the second sequence yields a source element.</param>
	/// <param name="bothSelector">Function to project the result element
	/// when only both sequences yield a source element whose keys are
	/// equal.</param>
	/// <returns>
	/// A sequence with projections from the two input sequences merged
	/// according to a key, as in a full outer join.</returns>
	/// <remarks>
	/// This method uses deferred execution. The behavior is undefined
	/// if the sequences are unordered (by key) as inputs.
	/// </remarks>
	[Obsolete("OrderedMerge has been replaced by FullOuterJoin")]
	public static IEnumerable<TResult> OrderedMerge<TFirst, TSecond, TKey, TResult>(
		this IEnumerable<TFirst> first,
		IEnumerable<TSecond> second,
		Func<TFirst, TKey> firstKeySelector,
		Func<TSecond, TKey> secondKeySelector,
		Func<TFirst, TResult> firstSelector,
		Func<TSecond, TResult> secondSelector,
		Func<TFirst, TSecond, TResult> bothSelector)
	{
		Guard.IsNotNull(first);
		Guard.IsNotNull(second);
		Guard.IsNotNull(firstKeySelector);
		Guard.IsNotNull(secondKeySelector);
		Guard.IsNotNull(firstSelector);
		Guard.IsNotNull(bothSelector);
		Guard.IsNotNull(secondSelector);

		return MergeJoin(
			first, second,
			JoinOperation.FullOuter,
			firstKeySelector, secondKeySelector,
			firstSelector, secondSelector,
			bothSelector,
			Comparer<TKey>.Default);
	}

	/// <summary>
	/// Merges two heterogeneous sequences ordered by a common key type
	/// into a homogeneous one. Additional parameters specify the
	/// element key by which the sequences are ordered, the result when
	/// element is found in first sequence but not in the second,
	/// the result when element is found in second sequence but not in
	/// the first, the result when elements are found in both sequences
	/// and a method for comparing keys.
	/// </summary>
	/// <typeparam name="TFirst">Type of elements in the first sequence.</typeparam>
	/// <typeparam name="TSecond">Type of elements in the second sequence.</typeparam>
	/// <typeparam name="TKey">Type of keys used for merging.</typeparam>
	/// <typeparam name="TResult">Type of elements in the returned sequence.</typeparam>
	/// <param name="first">The first input sequence.</param>
	/// <param name="second">The second input sequence.</param>
	/// <param name="firstKeySelector">Function to extract a key given an
	/// element from the first sequence.</param>
	/// <param name="secondKeySelector">Function to extract a key given an
	/// element from the second sequence.</param>
	/// <param name="firstSelector">Function to project the result element
	/// when only the first sequence yields a source element.</param>
	/// <param name="secondSelector">Function to project the result element
	/// when only the second sequence yields a source element.</param>
	/// <param name="bothSelector">Function to project the result element
	/// when only both sequences yield a source element whose keys are
	/// equal.</param>
	/// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
	/// <returns>
	/// A sequence with projections from the two input sequences merged
	/// according to a key, as in a full outer join.</returns>
	/// <remarks>
	/// This method uses deferred execution. The behavior is undefined
	/// if the sequences are unordered (by key) as inputs.
	/// </remarks>
	[Obsolete("OrderedMerge has been replaced by FullOuterJoin")]
	public static IEnumerable<TResult> OrderedMerge<TFirst, TSecond, TKey, TResult>(
		this IEnumerable<TFirst> first,
		IEnumerable<TSecond> second,
		Func<TFirst, TKey> firstKeySelector,
		Func<TSecond, TKey> secondKeySelector,
		Func<TFirst, TResult> firstSelector,
		Func<TSecond, TResult> secondSelector,
		Func<TFirst, TSecond, TResult> bothSelector,
		IComparer<TKey>? comparer)
	{
		Guard.IsNotNull(first);
		Guard.IsNotNull(second);
		Guard.IsNotNull(firstKeySelector);
		Guard.IsNotNull(secondKeySelector);
		Guard.IsNotNull(firstSelector);
		Guard.IsNotNull(bothSelector);
		Guard.IsNotNull(secondSelector);

		return MergeJoin(
				first, second,
				JoinOperation.FullOuter,
				firstKeySelector, secondKeySelector,
				firstSelector, secondSelector,
				bothSelector,
				comparer ?? Comparer<TKey>.Default);
	}
}
