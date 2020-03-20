using System;

namespace TerseProfiler
{
	public interface IProfiler : IDisposable
	{
		IStep Step(string name);
	}
}