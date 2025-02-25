using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeConfig{
	void* ptr;
}