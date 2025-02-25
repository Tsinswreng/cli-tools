using System.Runtime.InteropServices;

namespace Rime.Api;

/// <summary>
/// 所有byte* 于源c++中皆const char*
/// </summary>
[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeTraits{
	int data_size;
	// v0.9
	byte* shared_data_dir;
	byte* user_data_dir;
	byte* distribution_name;
	byte* distribution_code_name;
	byte* distribution_version;
	// v1.0
	/*!
	* Pass a C-string constant in the format "rime.x"
	* where 'x' is the name of your application.
	* Add prefix "rime." to ensure old log files are automatically cleaned.
	*/
	byte* app_name;

	//! A list of modules to load before initializing
	byte** modules;
	// v1.6
	/*! Minimal level of logged messages.
	*  Value is passed to Glog library using FLAGS_minloglevel variable.
	*  0 = INFO (default), 1 = WARNING, 2 = ERROR, 3 = FATAL
	*/
	int min_log_level;
	/*! Directory of log files.
	*  Value is passed to Glog library using FLAGS_log_dir variable.
	*  NULL means temporary directory, and "" means only writing to stderr.
	*/
	byte* log_dir;
	//! prebuilt data directory. defaults to ${shared_data_dir}/build
	byte* prebuilt_data_dir;
	//! staging directory. defaults to ${user_data_dir}/build
	byte* staging_dir;
}