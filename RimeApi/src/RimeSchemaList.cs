using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeSchemaList{
	public u64 size; //size_t
	public RimeSchemaListItem* list;
}
