using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeComposition{
	int length;
	int cursor_pos; // 光標 遊標
	int sel_start; //select?
	int sel_end;
	byte* preedit;
}