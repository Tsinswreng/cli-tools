using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeConfigIterator{
	void* list;
	void* map;
	int index;
	byte* key; //const char*
	byte* path; //const char*
}