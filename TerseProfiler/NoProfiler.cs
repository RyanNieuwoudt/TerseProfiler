namespace TerseProfiler
{
	public sealed class NoProfiler : IProfiler
	{
		internal NoProfiler()
		{
		}

		public IStep Step(string name)
		{
			return new NoStep();
		}

		public void Dispose()
		{
		}
	}
}