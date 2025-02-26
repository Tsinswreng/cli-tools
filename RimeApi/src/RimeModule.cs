namespace Rime.Api;

using System.Runtime.InteropServices;



[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeModule{
	public int data_size;
	public byte* module_name;
	//fn
	public IntPtr initialize;
	public IntPtr finalize;
	public IntPtr get_api;
}