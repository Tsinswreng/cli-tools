using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeConfigIterator{
	public void* list;
	public void* map;
	public int index;
	public byte* key; //const char*
	public byte* path; //const char*
}