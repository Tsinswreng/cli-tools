using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeComposition{
	public int length;
	public int cursor_pos; // 光標 遊標
	public int sel_start; //select?
	public int sel_end;
	public byte* preedit;
}