using System.Collections.Concurrent;

namespace TerseProfiler
{
	public abstract class ProfilerBase : IProfiler
	{
		protected readonly ConcurrentBag<Result> results;

		protected ProfilerBase()
		{
			results = new ConcurrentBag<Result>();
		}

		public IStep Step(string name)
		{
			return new Step(name, Record);
		}

		public void Dispose()
		{
			PublishResults();
		}

		protected abstract void PublishResults();

		void Record(string name, long milliseconds)
		{
			results.Add(new Result(name, milliseconds));
		}
	}
}