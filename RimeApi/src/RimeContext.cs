using System.Runtime.InteropServices;

namespace Rime.Api;

/// <summary>
/// Should be initialized by calling RIME_STRUCT_INIT(Type, var);
/// </summary>
[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeContext{
	int data_size;
	// v0.9
	RimeComposition composition;
	RimeMenu menu;
	// v0.9.2
	byte* commit_text_preview;
	byte** select_labels;
}