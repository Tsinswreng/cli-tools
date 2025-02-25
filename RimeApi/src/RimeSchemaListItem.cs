using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeSchemaListItem{
	byte* schema_id;
	byte* name;
	void* reserved;
}