namespace TerseProfiler
{
	public sealed class Result
	{
		internal Result(string name, long milliseconds)
		{
			Name = name;
			Milliseconds = milliseconds;
		}

		public string Name { get; }
		public long Milliseconds { get; }

		public override string ToString()
		{
			return $"{Name} - {Milliseconds.ToString()}";
		}
	}
}