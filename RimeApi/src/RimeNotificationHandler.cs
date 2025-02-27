using System.Runtime.InteropServices;
namespace Rime.Api;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void RimeNotificationHandler(
	void* context_object
	,RimeSessionId session_id
	// [MarshalAs(UnmanagedType.LPStr)] string message_type,    // const char* -> string（自动转换为LPStr）[[3]]
	// [MarshalAs(UnmanagedType.LPStr)] string message_value    // 同上
	,byte* message_type // const char*
	,byte* message_value // const char*
);

