using System.Runtime.InteropServices;

namespace Rime.Api;

/// <summary>
/// Should be initialized by calling RIME_STRUCT_INIT(Type, var);
/// </summary>
[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeCommit{
	public int data_size;
	// v0.9
	public byte* text;
}