using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeCandidate{
	byte* text; //char*
	byte* comment; //char*
	void* reserved;
}