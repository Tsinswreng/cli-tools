#pragma warning disable CS8981
using System.Runtime.InteropServices;
using FnPtr=Rime.Api.FnPtr;
using Shr.Interop;

namespace Rime.Api;

unsafe public class DelegateRimeApiFn{

	public DelegateRimeApiFn(RimeApi* rime){
		setup = rime->setup.asFn<FnPtr.setup>();
		set_notification_handler = rime->set_notification_handler.asFn<FnPtr.set_notification_handler>();
		initialize = rime->initialize.asFn<FnPtr.initialize>();
		finalize = rime->finalize.asFn<FnPtr.finalize>();
		start_maintenance = rime->start_maintenance.asFn<FnPtr.start_maintenance>();
		is_maintenance_mode = rime->is_maintenance_mode.asFn<FnPtr.is_maintenance_mode>();
		join_maintenance_thread = rime->join_maintenance_thread.asFn<FnPtr.join_maintenance_thread>();
		deployer_initialize = rime->deployer_initialize.asFn<FnPtr.deployer_initialize>();
		prebuild = rime->prebuild.asFn<FnPtr.prebuild>();
		deploy = rime->deploy.asFn<FnPtr.deploy>();
		deploy_schema = rime->deploy_schema.asFn<FnPtr.deploy_schema>();
		deploy_config_file = rime->deploy_config_file.asFn<FnPtr.deploy_config_file>();
		sync_user_data = rime->sync_user_data.asFn<FnPtr.sync_user_data>();
		create_session = rime->create_session.asFn<FnPtr.create_session>();
		find_session = rime->find_session.asFn<FnPtr.find_session>();
		destroy_session = rime->destroy_session.asFn<FnPtr.destroy_session>();
		cleanup_stale_sessions = rime->cleanup_stale_sessions.asFn<FnPtr.cleanup_stale_sessions>();
		cleanup_all_sessions = rime->cleanup_all_sessions.asFn<FnPtr.cleanup_all_sessions>();
		process_key = rime->process_key.asFn<FnPtr.process_key>();
		commit_composition = rime->commit_composition.asFn<FnPtr.commit_composition>();
		clear_composition = rime->clear_composition.asFn<FnPtr.clear_composition>();
		get_commit = rime->get_commit.asFn<FnPtr.get_commit>();
		free_commit = rime->free_commit.asFn<FnPtr.free_commit>();
		get_context = rime->get_context.asFn<FnPtr.get_context>();
		free_context = rime->free_context.asFn<FnPtr.free_context>();
		get_status = rime->get_status.asFn<FnPtr.get_status>();
		free_status = rime->free_status.asFn<FnPtr.free_status>();
		set_option = rime->set_option.asFn<FnPtr.set_option>();
		get_option = rime->get_option.asFn<FnPtr.get_option>();
		set_property = rime->set_property.asFn<FnPtr.set_property>();
		get_property = rime->get_property.asFn<FnPtr.get_property>();
		get_schema_list = rime->get_schema_list.asFn<FnPtr.get_schema_list>();
		free_schema_list = rime->free_schema_list.asFn<FnPtr.free_schema_list>();
		get_current_schema = rime->get_current_schema.asFn<FnPtr.get_current_schema>();
		select_schema = rime->select_schema.asFn<FnPtr.select_schema>();
		schema_open = rime->schema_open.asFn<FnPtr.schema_open>();
		config_open = rime->config_open.asFn<FnPtr.config_open>();
		config_close = rime->config_close.asFn<FnPtr.config_close>();
		config_get_bool = rime->config_get_bool.asFn<FnPtr.config_get_bool>();
		config_get_int = rime->config_get_int.asFn<FnPtr.config_get_int>();
		config_get_double = rime->config_get_double.asFn<FnPtr.config_get_double>();
		config_get_string = rime->config_get_string.asFn<FnPtr.config_get_string>();
		config_get_cstring = rime->config_get_cstring.asFn<FnPtr.config_get_cstring>();
		config_update_signature = rime->config_update_signature.asFn<FnPtr.config_update_signature>();
		config_begin_map = rime->config_begin_map.asFn<FnPtr.config_begin_map>();
		config_next = rime->config_next.asFn<FnPtr.config_next>();
		config_end = rime->config_end.asFn<FnPtr.config_end>();
		simulate_key_sequence = rime->simulate_key_sequence.asFn<FnPtr.simulate_key_sequence>();
		register_module = rime->register_module.asFn<FnPtr.register_module>();
		find_module = rime->find_module.asFn<FnPtr.find_module>();
		run_task = rime->run_task.asFn<FnPtr.run_task>();
		get_shared_data_dir = rime->get_shared_data_dir.asFn<FnPtr.get_shared_data_dir>();
		get_user_data_dir = rime->get_user_data_dir.asFn<FnPtr.get_user_data_dir>();
		get_sync_dir = rime->get_sync_dir.asFn<FnPtr.get_sync_dir>();
		get_user_id = rime->get_user_id.asFn<FnPtr.get_user_id>();
		get_user_data_sync_dir = rime->get_user_data_sync_dir.asFn<FnPtr.get_user_data_sync_dir>();
		config_init = rime->config_init.asFn<FnPtr.config_init>();
		config_load_string = rime->config_load_string.asFn<FnPtr.config_load_string>();
		config_set_bool = rime->config_set_bool.asFn<FnPtr.config_set_bool>();
		config_set_int = rime->config_set_int.asFn<FnPtr.config_set_int>();
		config_set_double = rime->config_set_double.asFn<FnPtr.config_set_double>();
		config_set_string = rime->config_set_string.asFn<FnPtr.config_set_string>();
		config_get_item = rime->config_get_item.asFn<FnPtr.config_get_item>();
		config_set_item = rime->config_set_item.asFn<FnPtr.config_set_item>();
		config_clear = rime->config_clear.asFn<FnPtr.config_clear>();
		config_create_list = rime->config_create_list.asFn<FnPtr.config_create_list>();
		config_create_map = rime->config_create_map.asFn<FnPtr.config_create_map>();
		config_list_size = rime->config_list_size.asFn<FnPtr.config_list_size>();
		config_begin_list = rime->config_begin_list.asFn<FnPtr.config_begin_list>();
		get_input = rime->get_input.asFn<FnPtr.get_input>();
		get_caret_pos = rime->get_caret_pos.asFn<FnPtr.get_caret_pos>();
		select_candidate = rime->select_candidate.asFn<FnPtr.select_candidate>();
		get_version = rime->get_version.asFn<FnPtr.get_version>();
		set_caret_pos = rime->set_caret_pos.asFn<FnPtr.set_caret_pos>();
		select_candidate_on_current_page = rime->select_candidate_on_current_page.asFn<FnPtr.select_candidate_on_current_page>();
		candidate_list_begin = rime->candidate_list_begin.asFn<FnPtr.candidate_list_begin>();
		candidate_list_next = rime->candidate_list_next.asFn<FnPtr.candidate_list_next>();
		candidate_list_end = rime->candidate_list_end.asFn<FnPtr.candidate_list_end>();
		user_config_open = rime->user_config_open.asFn<FnPtr.user_config_open>();
		candidate_list_from_index = rime->candidate_list_from_index.asFn<FnPtr.candidate_list_from_index>();
		get_prebuilt_data_dir = rime->get_prebuilt_data_dir.asFn<FnPtr.get_prebuilt_data_dir>();
		get_staging_dir = rime->get_staging_dir.asFn<FnPtr.get_staging_dir>();

		if(rime->commit_proto != 0){
			commit_proto = rime->commit_proto.asFn<FnPtr.commit_proto>();
		}
		if(rime->context_proto != 0){
			context_proto = rime->context_proto.asFn<FnPtr.context_proto>();
		}
		if(rime->status_proto != 0){
			status_proto = rime->status_proto.asFn<FnPtr.status_proto>();
		}
		delete_candidate = rime->delete_candidate.asFn<FnPtr.delete_candidate>();
		delete_candidate_on_current_page = rime->delete_candidate_on_current_page.asFn<FnPtr.delete_candidate_on_current_page>();
		get_state_label_abbreviated = rime->get_state_label_abbreviated.asFn<FnPtr.get_state_label_abbreviated>();
		set_input = rime->set_input.asFn<FnPtr.set_input>();
	}



	#region  setup
	/// <summary>
	/// Call this function before accessing any other API functions.
	/// </summary>

	public FnPtr.setup setup;
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
	public FnPtr.set_notification_handler set_notification_handler;
	#endregion  setup

	#region entry ans exit
	public FnPtr.initialize initialize;
	public FnPtr.finalize finalize;
	public FnPtr.start_maintenance start_maintenance;
	public FnPtr.is_maintenance_mode is_maintenance_mode;
	public FnPtr.join_maintenance_thread join_maintenance_thread;
	#endregion entry ans exit


	#region deployment
	public FnPtr.deployer_initialize deployer_initialize;
	public FnPtr.prebuild prebuild;
	public FnPtr.deploy deploy;
	public FnPtr.deploy_schema deploy_schema;
	public FnPtr.deploy_config_file deploy_config_file;
	public FnPtr.sync_user_data sync_user_data;
	#endregion deployment

	#region session management
	public FnPtr.create_session create_session;
	public FnPtr.find_session find_session;
	public FnPtr.destroy_session destroy_session;
	public FnPtr.cleanup_stale_sessions cleanup_stale_sessions;
	public FnPtr.cleanup_all_sessions cleanup_all_sessions;
	#endregion session management

	#region input
	public FnPtr.process_key process_key;
	public FnPtr.commit_composition commit_composition;
	public FnPtr.clear_composition clear_composition;
	#endregion input

	#region output
	public FnPtr.get_commit get_commit;
	public FnPtr.free_commit free_commit;
	public FnPtr.get_context get_context;
	public FnPtr.free_context free_context;
	public FnPtr.get_status get_status;
	public FnPtr.free_status free_status;
	#endregion output


	#region runtime options
	public FnPtr.set_option set_option;
	public FnPtr.get_option get_option;
	public FnPtr.set_property set_property;
	public FnPtr.get_property get_property;
	public FnPtr.get_schema_list get_schema_list;
	public FnPtr.free_schema_list free_schema_list;
	public FnPtr.get_current_schema get_current_schema;
	public FnPtr.select_schema select_schema;
	#endregion runtime options



	#region configuration
	public FnPtr.schema_open schema_open;
	public FnPtr.config_open config_open;
	public FnPtr.config_close config_close;
	public FnPtr.config_get_bool config_get_bool;
	public FnPtr.config_get_int config_get_int;
	public FnPtr.config_get_double config_get_double;
	public FnPtr.config_get_string config_get_string;
	public FnPtr.config_get_cstring config_get_cstring;
	public FnPtr.config_update_signature config_update_signature;
	public FnPtr.config_begin_map config_begin_map;
	public FnPtr.config_next config_next;
	public FnPtr.config_end config_end;
	#endregion configuration


	#region testing
	public FnPtr.simulate_key_sequence simulate_key_sequence;
	#endregion testing


	#region module
	public FnPtr.register_module register_module;
	public FnPtr.find_module find_module;
	public FnPtr.run_task run_task;
	public FnPtr.get_shared_data_dir get_shared_data_dir;
	public FnPtr.get_user_data_dir get_user_data_dir;
	public FnPtr.get_sync_dir get_sync_dir;
	public FnPtr.get_user_id get_user_id;
	public FnPtr.get_user_data_sync_dir get_user_data_sync_dir;

	/// <summary>
	/// initialize an empty config object
	/// should call config_close() to free the object
	/// </summary>
	public FnPtr.config_init config_init;

	/// <summary>
	/// deserialize config from a yaml string
	/// </summary>
	public FnPtr.config_load_string config_load_string;
	#endregion module


	#region configuration: setters
	public FnPtr.config_set_bool config_set_bool;
	public FnPtr.config_set_int config_set_int;
	public FnPtr.config_set_double config_set_double;
	public FnPtr.config_set_string config_set_string;

	#endregion configuration: setters


	#region configuration: manipulating complex structures
	public FnPtr.config_get_item config_get_item;
	public FnPtr.config_set_item config_set_item;
	public FnPtr.config_clear config_clear;
	public FnPtr.config_create_list config_create_list;
	public FnPtr.config_create_map config_create_map;
	public FnPtr.config_list_size config_list_size;
	public FnPtr.config_begin_list config_begin_list;
	#endregion configuration: manipulating complex structures

  //! get raw input
  /*!
   *  NULL is returned if session does not exist.
   *  the returned pointer to input string will become invalid upon editing.
   */
	public FnPtr.get_input get_input;

	/// <summary>
	/// caret position in terms of raw input
	/// </summary>
	public FnPtr.get_caret_pos get_caret_pos;

	/// <summary>
	/// select a candidate at the given index in candidate list.
	/// </summary>
	public FnPtr.select_candidate select_candidate;
	/// <summary>
	/// get the version of librime
	/// </summary>
	public FnPtr.get_version get_version;

	/// <summary>
	/// set caret position in terms of raw input
	/// </summary>
	public FnPtr.set_caret_pos set_caret_pos;
	/// <summary>
	/// select a candidate from current page.
	/// </summary>
	public FnPtr.select_candidate_on_current_page select_candidate_on_current_page;
	/// <summary>
	/// access candidate list.
	/// </summary>
	public FnPtr.candidate_list_begin candidate_list_begin;
	public FnPtr.candidate_list_next candidate_list_next;
	public FnPtr.candidate_list_end candidate_list_end;

	/// <summary>
	//! access config files in user data directory, eg. user.yaml and
	//! installation.yaml
	/// </summary>
	public FnPtr.user_config_open user_config_open;
	public FnPtr.candidate_list_from_index candidate_list_from_index;

	/// <summary>
	/// prebuilt data directory.
	/// </summary>
	public FnPtr.get_prebuilt_data_dir get_prebuilt_data_dir;
	/// <summary>
	/// staging directory, stores data files deployed to a Rime client.
	/// </summary>
	public FnPtr.get_staging_dir get_staging_dir;


	[Obsolete("Deprecated: for capnproto API, use \"proto\" module from librime-proto")]
	public FnPtr.commit_proto commit_proto;
	[Obsolete("Deprecated: for capnproto API, use \"proto\" module from librime-proto")]
	public FnPtr.context_proto context_proto;
	[Obsolete("Deprecated: for capnproto API, use \"proto\" module from librime-proto")]
	public FnPtr.status_proto status_proto;

	/// <summary>
	/// delete a candidate at the given index in candidate list.
	/// </summary>
	public FnPtr.delete_candidate delete_candidate;
	/// <summary>
	/// delete a candidate from current page.
	/// </summary>
	public FnPtr.delete_candidate_on_current_page delete_candidate_on_current_page;

	public FnPtr.get_state_label_abbreviated get_state_label_abbreviated;
	public FnPtr.set_input set_input;


}