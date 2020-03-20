using System;
using System.Threading;

namespace TerseProfiler
{
	public static class ProfilerFactory
	{
		static Func<IProfiler> getProfiler;
		static ProfilingOptions options;

		static readonly AsyncLocal<IProfiler> Profiler = new AsyncLocal<IProfiler>();

		static ProfilerFactory()
		{
			getProfiler = NewNoProfiler;
			options = new ProfilingOptions { Target = "None", Threshold = 10 };
		}

		public static IProfiler CurrentProfiler => Profiler.Value ?? (Profiler.Value = getProfiler());

		public static void UseSettings(ProfilingOptions profilingOptions)
		{
			options = profilingOptions;
			getProfiler = options.Target switch
			{
				"DebugConsole" => (Func<IProfiler>)NewDebugConsoleProfiler,
				"File" => NewFileProfiler,
				_ => NewNoProfiler
			};
		}

		public static IProfiler GetProfiler()
		{
			Profiler.Value = getProfiler();
			return CurrentProfiler;
		}

		static IProfiler NewFileProfiler()
		{
			return new FileProfiler(options.Filename, options.Threshold);
		}

		static IProfiler NewDebugConsoleProfiler()
		{
			return new DebugConsoleProfiler(options.Threshold);
		}

		static IProfiler NewNoProfiler()
		{
			return new NoProfiler();
		}
	}
}