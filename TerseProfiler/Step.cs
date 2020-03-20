using System;
using System.Diagnostics;

namespace TerseProfiler
{
	public sealed class Step : IStep
	{
		readonly string name;
		readonly Action<string, long> record;
		readonly Stopwatch stopwatch;

		internal Step(string name, Action<string, long> record)
		{
			this.name = name;
			this.record = record;
			stopwatch = Stopwatch.StartNew();
		}

		public void Dispose()
		{
			stopwatch.Stop();
			record(name, stopwatch.ElapsedMilliseconds);
		}
	}
}