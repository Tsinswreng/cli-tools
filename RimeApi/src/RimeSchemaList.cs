using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeSchemaList{
	u64 size; //size_t
	RimeSchemaListItem* list;
}
