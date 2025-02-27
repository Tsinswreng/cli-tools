using System.Runtime.InteropServices;

namespace Rime.Api;
/// <summary>
/// Should be initialized by calling RIME_STRUCT_INIT(Type, var);
/// </summary>
[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeStatus{
	public int data_size;
	// v0.9
	public byte* schema_id;
	public byte* schema_name;
	public Bool is_disabled;
	public Bool is_composing;
	public Bool is_ascii_mode;
	public Bool is_full_shape;
	public Bool is_simplified;
	public Bool is_traditional;
	public Bool is_ascii_punct;
}