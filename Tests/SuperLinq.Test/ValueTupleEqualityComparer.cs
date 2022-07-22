﻿namespace Test;

internal partial class ValueTupleEqualityComparer
{
	public static IEqualityComparer<(T1, T2)> Create<T1, T2>(
			IEqualityComparer<T1>? comparer1,
			IEqualityComparer<T2>? comparer2) =>
		new EqualityComparer<T1, T2>(
			comparer1,
			comparer2);

	private sealed class EqualityComparer<T1, T2> : IEqualityComparer<(T1, T2)>
	{
		private readonly IEqualityComparer<T1> _comparer1;
		private readonly IEqualityComparer<T2> _comparer2;

		public EqualityComparer(
			IEqualityComparer<T1>? comparer1,
			IEqualityComparer<T2>? comparer2)
		{
			_comparer1 = comparer1 ?? EqualityComparer<T1>.Default;
			_comparer2 = comparer2 ?? EqualityComparer<T2>.Default;
		}

		public bool Equals((T1, T2) x,
						   (T1, T2) y)
			=> _comparer1.Equals(x.Item1, y.Item1)
			&& _comparer2.Equals(x.Item2, y.Item2);

		public int GetHashCode((T1, T2) obj) =>
			HashCode.Combine(
				_comparer1.GetHashCode(obj.Item1!),
				_comparer2.GetHashCode(obj.Item2!));
	}
}