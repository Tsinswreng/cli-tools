using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeStringSlice{
	public byte* str;// const char
	public u64 length;
}