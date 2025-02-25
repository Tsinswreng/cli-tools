using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeCandidate{
	public byte* text; //char*
	public byte* comment; //char*
	public void* reserved;
}