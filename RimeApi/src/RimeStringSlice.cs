using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeStringSlice{
	byte* str;// const char
	u64 length;
}