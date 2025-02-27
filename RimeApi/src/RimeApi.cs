using System.Runtime.InteropServices;


namespace Rime.Api;

/// <summary>
/// RimeApi is for rime v1.0+
/// </summary>
[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeApi{
	public int data_size;

	#region  setup
	/// <summary>
	/// Call this function before accessing any other API functions.
	/// </summary>

	public IntPtr setup;
	// public delegate* unmanaged[Cdecl]<
	// 	RimeTraits* // traits
	// 	,void
	// > setup;


  /*! Set up the notification callbacks
   *  Receive notifications
   *  - on loading schema:
   *    + message_type="schema", message_value="luna_pinyin/Luna Pinyin"
   *  - on changing mode:
   *    + message_type="option", message_value="ascii_mode"
   *    + message_type="option", message_value="!ascii_mode"
   *  - on deployment:
   *    + session_id = 0, message_type="deploy", message_value="start"
   *    + session_id = 0, message_type="deploy", message_value="success"
   *    + session_id = 0, message_type="deploy", message_value="failure"
   *
   *  handler will be called with context_object as the first parameter
   *  every time an event occurs in librime, until RimeFinalize() is called.
   *  when handler is NULL, notification is disabled.
   */
	// public delegate* unmanaged[Cdecl]<
	// 		RimeNotificationHandler // handler
	// 		, void* // context_object
	// 		,void
	// 	> set_notification_handler;
	public IntPtr set_notification_handler;
	#endregion  setup

	#region entry ans exit
	public IntPtr initialize;
	public IntPtr finalize;
	public IntPtr start_maintenance;
	public IntPtr is_maintenance_mode;
	public IntPtr join_maintenance_thread;
	#endregion entry ans exit


	#region deployment
	public IntPtr deployer_initialize;
	public IntPtr prebuild;
	public IntPtr deploy;
	public IntPtr deploy_schema;
	public IntPtr deploy_config_file;
	public IntPtr sync_user_data;
	#endregion deployment

	#region session management
	public IntPtr create_session;
	public IntPtr find_session;
	public IntPtr destroy_session;
	public IntPtr cleanup_stale_sessions;
	public IntPtr cleanup_all_sessions;
	#endregion session management

	#region input
	public IntPtr process_key;
	public IntPtr commit_composition;
	public IntPtr clear_composition;
	#endregion input

	#region output
	public IntPtr get_commit;
	public IntPtr free_commit;
	public IntPtr get_context;
	public IntPtr free_context;
	public IntPtr get_status;
	public IntPtr free_status;
	#endregion output


	#region runtime options
	public IntPtr set_option;
	public IntPtr get_option;
	public IntPtr set_property;
	public IntPtr get_property;
	public IntPtr get_schema_list;
	public IntPtr free_schema_list;
	public IntPtr get_current_schema;
	public IntPtr select_schema;
	#endregion runtime options



	#region configuration
	public IntPtr schema_open;
	public IntPtr config_open;
	public IntPtr config_close;
	public IntPtr config_get_bool;
	public IntPtr config_get_int;
	public IntPtr config_get_double;
	public IntPtr config_get_string;
	public IntPtr config_get_cstring;
	public IntPtr config_update_signature;
	public IntPtr config_begin_map;
	public IntPtr config_next;
	public IntPtr config_end;
	#endregion configuration


	#region testing
	public IntPtr simulate_key_sequence;
	#endregion testing


	#region module
	public IntPtr register_module;
	public IntPtr find_module;
	public IntPtr run_task;
	public IntPtr get_shared_data_dir;
	public IntPtr get_user_data_dir;
	public IntPtr get_sync_dir;
	public IntPtr get_user_id;
	public IntPtr get_user_data_sync_dir;

	/// <summary>
	/// initialize an empty config object
	/// should call config_close() to free the object
	/// </summary>
	public IntPtr config_init;

	/// <summary>
	/// deserialize config from a yaml string
	/// </summary>
	public IntPtr config_load_string;
	#endregion module


	#region configuration: setters
	public IntPtr config_set_bool;
	public IntPtr config_set_int;
	public IntPtr config_set_double;
	public IntPtr config_set_string;

	#endregion configuration: setters


	#region configuration: manipulating complex structures
	public IntPtr config_get_item;
	public IntPtr config_set_item;
	public IntPtr config_clear;
	public IntPtr config_create_list;
	public IntPtr config_create_map;
	public IntPtr config_list_size;
	public IntPtr config_begin_list;
	#endregion configuration: manipulating complex structures

  //! get raw input
  /*!
   *  NULL is returned if session does not exist.
   *  the returned pointer to input string will become invalid upon editing.
   */
	public IntPtr get_input;

	/// <summary>
	/// caret position in terms of raw input
	/// </summary>
	public IntPtr get_caret_pos;

	/// <summary>
	/// select a candidate at the given index in candidate list.
	/// </summary>
	public IntPtr select_candidate;
	/// <summary>
	/// get the version of librime
	/// </summary>
	public IntPtr get_version;

	/// <summary>
	/// set caret position in terms of raw input
	/// </summary>
	public IntPtr set_caret_pos;
	/// <summary>
	/// select a candidate from current page.
	/// </summary>
	public IntPtr select_candidate_on_current_page;
	/// <summary>
	/// access candidate list.
	/// </summary>
	public IntPtr candidate_list_begin;
	public IntPtr candidate_list_next;
	public IntPtr candidate_list_end;

	/// <summary>
	//! access config files in user data directory, eg. user.yaml and
	//! installation.yaml
	/// </summary>
	public IntPtr user_config_open;
	public IntPtr candidate_list_from_index;

	/// <summary>
	/// prebuilt data directory.
	/// </summary>
	public IntPtr get_prebuilt_data_dir;
	/// <summary>
	/// staging directory, stores data files deployed to a Rime client.
	/// </summary>
	public IntPtr get_staging_dir;

	/// <summary>
	/// 小狼毫0.15.0ʃ用ʹrime.dll中 此潙空指針
	/// </summary>
	[Obsolete("Deprecated: for capnproto API, use \"proto\" module from librime-proto")]
	/// <summary>
	/// 小狼毫0.15.0ʃ用ʹrime.dll中 此潙空指針
	/// </summary>
	public IntPtr commit_proto;
	[Obsolete("Deprecated: for capnproto API, use \"proto\" module from librime-proto")]
	/// <summary>
	/// 小狼毫0.15.0ʃ用ʹrime.dll中 此潙空指針
	/// </summary>
	public IntPtr context_proto;
	[Obsolete("Deprecated: for capnproto API, use \"proto\" module from librime-proto")]
	public IntPtr status_proto;

	/// <summary>
	/// delete a candidate at the given index in candidate list.
	/// </summary>
	public IntPtr delete_candidate;
	/// <summary>
	/// delete a candidate from current page.
	/// </summary>
	public IntPtr delete_candidate_on_current_page;

	public IntPtr get_state_label_abbreviated;
	public IntPtr set_input;

}


