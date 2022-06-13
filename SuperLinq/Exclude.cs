﻿namespace SuperLinq;

public static partial class SuperEnumerable
{
	/// <summary>
	/// Excludes a contiguous number of elements from a sequence starting
	/// at a given index.
	/// </summary>
	/// <typeparam name="T">The type of the elements of the sequence</typeparam>
	/// <param name="sequence">The sequence to exclude elements from</param>
	/// <param name="startIndex">The zero-based index at which to begin excluding elements</param>
	/// <param name="count">The number of elements to exclude</param>
	/// <returns>A sequence that excludes the specified portion of elements</returns>

	public static IEnumerable<T> Exclude<T>(this IEnumerable<T> sequence, int startIndex, int count)
	{
		if (sequence == null) throw new ArgumentNullException(nameof(sequence));
		if (startIndex < 0) throw new ArgumentOutOfRangeException(nameof(startIndex));
		if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));

		if (count == 0)
			return sequence;

		return _(); IEnumerable<T> _()
		{
			var index = -1;
			var endIndex = startIndex + count;
			using var iter = sequence.GetEnumerator();
			// yield the first part of the sequence
			while (iter.MoveNext() && ++index < startIndex)
				yield return iter.Current;
			// skip the next part (up to count items)
			while (++index < endIndex && iter.MoveNext())
				continue;
			// yield the remainder of the sequence
			while (iter.MoveNext())
				yield return iter.Current;
		}
	}
}