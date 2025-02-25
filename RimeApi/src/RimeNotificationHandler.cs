using System.Runtime.InteropServices;

namespace Rime.Api;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)] // 假设C++使用cdecl调用约定
unsafe public delegate void RimeNotificationHandler(
	IntPtr context_object      // C++的void* -> C#的IntPtr [[1,3]]
	,uint session_id            // RimeSessionId假设为uint类型 [[1]]
	// [MarshalAs(UnmanagedType.LPStr)] string message_type,    // const char* -> string（自动转换为LPStr）[[3]]
	// [MarshalAs(UnmanagedType.LPStr)] string message_value    // 同上
	,byte* message_type // const char*
	,byte* message_value // const char*
);