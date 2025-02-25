using System.Runtime.InteropServices;
using Rime.Api;

// See https://aka.ms/new-console-template for more information


//int size = Marshal.SizeOf(typeof(RimeTraits));
unsafe{
	int size = Marshal.SizeOf<RimeTraits>();
	var rimeTraits = (RimeTraits*)Marshal.AllocHGlobal(size);

	rimeTraits->shared_data_dir
	//shared_data_dir = Marshal.StringToCoTaskMemUTF8("shared_data_dir");





	Marshal.FreeHGlobal((IntPtr)rimeTraits);



}


