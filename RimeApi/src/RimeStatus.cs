using System.Runtime.InteropServices;
using Bool = int;
namespace Rime.Api;
/// <summary>
/// Should be initialized by calling RIME_STRUCT_INIT(Type, var);
/// </summary>
[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeStatus{
	int data_size;
	// v0.9
	byte* schema_id;
	byte* schema_name;
	Bool is_disabled;
	Bool is_composing;
	Bool is_ascii_mode;
	Bool is_full_shape;
	Bool is_simplified;
	Bool is_traditional;
	Bool is_ascii_punct;
}