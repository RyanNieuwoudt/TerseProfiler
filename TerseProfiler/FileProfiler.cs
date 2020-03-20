using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TerseProfiler
{
	public sealed class FileProfiler : ProfilerBase
	{
		const string Marker = "----------";
		readonly string filename;
		readonly long threshold;

		internal FileProfiler(string filename, long threshold)
		{
			this.filename = filename;
			this.threshold = threshold;
		}

		protected override void PublishResults()
		{
			var lines = new List<string> { Marker };
			lines.AddRange(from result in results where result.Milliseconds > threshold select result.ToString());
			File.AppendAllLines(filename, lines);
		}
	}
}