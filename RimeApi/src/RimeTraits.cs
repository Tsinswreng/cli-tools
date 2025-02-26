using System.Runtime.InteropServices;

namespace Rime.Api;





/// <summary>
/// Should be initialized by calling RIME_STRUCT_INIT(Type, var)
/// 所有byte* 于源c++中皆const char*
/// </summary>
[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeTraits{
	/// <summary>
/// #define RIME_STRUCT_INIT(Type, var) \
///((var).data_size = sizeof(Type) - sizeof((var).data_size))
	/// </summary>
	public int data_size;
	// v0.9
	public byte* shared_data_dir;
	public byte* user_data_dir;
	public byte* distribution_name;
	public byte* distribution_code_name;
	public byte* distribution_version;
	// v1.0
	/*!
	* Pass a C-string constant in the format "rime.x"
	* where 'x' is the name of your application.
	* Add prefix "rime." to ensure old log files are automatically cleaned.
	*/
	public byte* app_name;

	//! A list of modules to load before initializing
	public byte** modules;
	// v1.6
	/*! Minimal level of logged messages.
	*  Value is passed to Glog library using FLAGS_minloglevel variable.
	*  0 = INFO (default), 1 = WARNING, 2 = ERROR, 3 = FATAL
	*/
	public int min_log_level;
	/*! Directory of log files.
	*  Value is passed to Glog library using FLAGS_log_dir variable.
	*  NULL means temporary directory, and "" means only writing to stderr.
	*/
	public byte* log_dir;
	//! prebuilt data directory. defaults to ${shared_data_dir}/build
	public byte* prebuilt_data_dir;
	//! staging directory. defaults to ${user_data_dir}/build
	public byte* staging_dir;
}