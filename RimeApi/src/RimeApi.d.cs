using System.Runtime.InteropServices;
using RimeSessionId = System.IntPtr;
using Bool = System.Int32;
namespace Rime.Api;

unsafe public partial class Fn{
	public const string DllPath = "rime.dll";


	#region Setup

	/// <summary>
	/// Call this function before accessing any other API.
	/// </summary>
	/// <param name="traits"></param>

	[DllImport(DllPath,EntryPoint = nameof(RimeSetup),CallingConvention = CallingConvention.Cdecl)]
	public static extern void RimeSetup(RimeTraits* traits);



	/// <summary>
	// Pass a C-string constant in the format "rime.x"
	// where 'x' is the name of your application.
	// Add prefix "rime." to ensure old log files are automatically cleaned.
	// \deprecated Use RimeSetup() instead.
	/// </summary>
	/// <param name="traits"></param>
	[Obsolete]
	[DllImport(DllPath,EntryPoint = nameof(RimeSetupLogging),CallingConvention = CallingConvention.Cdecl)]
	public static extern void RimeSetupLogging(byte* app_name);
	#endregion Setup

	#region Receive notifications
	/// <summary>
	/// TODO doc
	/// </summary>
	/// <param name="traits"></param>
	[DllImport(DllPath,EntryPoint = nameof(RimeSetNotificationHandler),CallingConvention = CallingConvention.Cdecl)]
	public static extern void RimeSetNotificationHandler(
		RimeNotificationHandler handler
		,void* context_object
	);

	#endregion Receive notifications

	#region Entry and exit

	[DllImport(DllPath,EntryPoint = nameof(RimeInitialize),CallingConvention = CallingConvention.Cdecl)]
	public static extern void RimeInitialize(
		RimeTraits* traits
	);


	[DllImport(DllPath,EntryPoint = nameof(RimeFinalize),CallingConvention = CallingConvention.Cdecl)]
	public static extern void RimeFinalize();


	/// <summary>
	///
	/// </summary>
	/// <param name="full_check"></param>
	/// <returns>Bool</returns>
	[DllImport(DllPath,EntryPoint = nameof(RimeStartMaintenance),CallingConvention = CallingConvention.Cdecl)]
	public static extern int RimeStartMaintenance(int full_check);


	/// <summary>
	/// Use RimeStartMaintenance(full_check = False) instead.
	/// </summary>
	/// <param name="traits"></param>
	/// <returns>Bool</returns>
	[Obsolete]
	[DllImport(DllPath,EntryPoint = nameof(RimeStartMaintenanceOnWorkspaceChange),CallingConvention = CallingConvention.Cdecl)]
	public static extern int RimeStartMaintenanceOnWorkspaceChange();

	#endregion Entry and exit


	#region Deployment
	#endregion Deployment


	#region Session management


	[DllImport(DllPath,EntryPoint = nameof(RimeCreateSession),CallingConvention = CallingConvention.Cdecl)]
	public static extern RimeSessionId RimeCreateSession();

	/// <summary>
	///
	/// </summary>
	/// <param name="session_id"></param>
	/// <returns>Bool</returns>
	[DllImport(DllPath,EntryPoint = nameof(RimeFindSession),CallingConvention = CallingConvention.Cdecl)]
	public static extern Bool RimeFindSession(RimeSessionId session_id);

	/// <summary>
	///
	/// </summary>
	/// <param name="session_id"></param>
	[DllImport(DllPath,EntryPoint = nameof(RimeDestroySession),CallingConvention = CallingConvention.Cdecl)]
	public static extern Bool RimeDestroySession(RimeSessionId session_id);


	[DllImport(DllPath,EntryPoint = nameof(RimeCleanupStaleSessions),CallingConvention = CallingConvention.Cdecl)]
	public static extern void RimeCleanupStaleSessions();


	[DllImport(DllPath,EntryPoint = nameof(RimeCleanupAllSessions),CallingConvention = CallingConvention.Cdecl)]
	public static extern void RimeCleanupAllSessions();

	// [DllImport(DllPath,EntryPoint = nameof(TODO),CallingConvention = CallingConvention.Cdecl)]
	// public static extern void TODO(RimeTraits* traits);

	#endregion Session management


	#region Input

	[DllImport(DllPath,EntryPoint = nameof(RimeProcessKey),CallingConvention = CallingConvention.Cdecl)]
	public static extern void RimeProcessKey(
		RimeSessionId session_id
		,int keycode
		,int mask //?
	);

	//TODO
	#endregion Input


	#region Output
	#endregion Output


	#region Accessing candidate list
	#endregion Accessing candidate list


	// #region TODO
	// #endregion TODO

	// [DllImport(DllPath,EntryPoint = nameof(TODO),CallingConvention = CallingConvention.Cdecl)]
	// public static extern void TODO(RimeTraits* traits);


	// [DllImport(DllPath,EntryPoint = nameof(TODO),CallingConvention = CallingConvention.Cdecl)]
	// public static extern void TODO(RimeTraits* traits);


	// [DllImport(DllPath,EntryPoint = nameof(TODO),CallingConvention = CallingConvention.Cdecl)]
	// public static extern void TODO(RimeTraits* traits);


	// [DllImport(DllPath,EntryPoint = nameof(TODO),CallingConvention = CallingConvention.Cdecl)]
	// public static extern void TODO(RimeTraits* traits);


	// [DllImport(DllPath,EntryPoint = nameof(TODO),CallingConvention = CallingConvention.Cdecl)]
	// public static extern void TODO(RimeTraits* traits);


	// [DllImport(DllPath,EntryPoint = nameof(TODO),CallingConvention = CallingConvention.Cdecl)]
	// public static extern void TODO(RimeTraits* traits);


	// [DllImport(DllPath,EntryPoint = nameof(TODO),CallingConvention = CallingConvention.Cdecl)]
	// public static extern void TODO(RimeTraits* traits);


	// [DllImport(DllPath,EntryPoint = nameof(TODO),CallingConvention = CallingConvention.Cdecl)]
	// public static extern void TODO(RimeTraits* traits);


	// [DllImport(DllPath,EntryPoint = nameof(TODO),CallingConvention = CallingConvention.Cdecl)]
	// public static extern void TODO(RimeTraits* traits);

}