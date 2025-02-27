using System.Runtime.InteropServices;

namespace Rime.Api;

public static class RimeUtil{

	public const int False = 0;
	public const int True = 1;


//rime_api.h:
// Version control
// #define RIME_STRUCT_INIT(Type, var) \
//   ((var).data_size = sizeof(Type) - sizeof((var).data_size))
	public static int dataSize<T>(){
		return Marshal.SizeOf<T>()-Marshal.SizeOf<int>();
	}
}