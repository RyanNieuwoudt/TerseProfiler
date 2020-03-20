using System.Diagnostics;

namespace TerseProfiler
{
	public class DebugConsoleProfiler : ProfilerBase
	{
		readonly long threshold;

		internal DebugConsoleProfiler(long threshold)
		{
			this.threshold = threshold;
		}

		protected override void PublishResults()
		{
			foreach (var result in results)
			{
				if (result.Milliseconds > threshold)
				{
					Debug.WriteLine(result);
				}
			}
		}
	}
}