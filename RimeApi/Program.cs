using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.NativeMemory;
using Rime.Api;
using Rime.Api.FnPtr;


unsafe zero test(){

	int size = Marshal.SizeOf<RimeTraits>();
	var rimeTraits = (RimeTraits*)AllocZeroed((nuint)size);

	rimeTraits->data_size = size - Marshal.SizeOf<int>();

	var cStr=(str csStr)=>{
		return (byte*)Marshal.StringToCoTaskMemUTF8(csStr);
	};

	rimeTraits->shared_data_dir = cStr("D:/Program Files/Rime/User_Data");
	rimeTraits->user_data_dir = cStr("D:/Program Files/Rime/User_Data");

	rimeTraits->distribution_name = cStr("TswG");
	rimeTraits->distribution_code_name = cStr("TswG");
	rimeTraits->distribution_version = cStr("0.0.0.1");
	rimeTraits->app_name = cStr("rime.TswG");

	Free((byte*)rimeTraits);
	return 0;
}

//sample_console.cc
unsafe i32 main(){

	return 0;
}

main();