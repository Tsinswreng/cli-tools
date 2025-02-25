using System.Runtime.InteropServices;

namespace Rime.Api;

/// <summary>
/// Should be initialized by calling RIME_STRUCT_INIT(Type, var);
/// </summary>
[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeContext{
	public int data_size;
	// v0.9
	public RimeComposition composition;
	public RimeMenu menu;
	// v0.9.2
	public byte* commit_text_preview;
	public byte** select_labels;
}