using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeSchemaListItem{
	public byte* schema_id;
	public byte* name;
	public void* reserved;
}