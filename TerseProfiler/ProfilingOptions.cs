namespace TerseProfiler
{
	public sealed class ProfilingOptions
	{
		public string Filename { get; set; } = string.Empty;
		public string Target { get; set; } = string.Empty;
		public long Threshold { get; set; }
	}
}