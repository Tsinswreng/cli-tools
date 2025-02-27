/*
var setup = Marshal.GetDelegateForFunctionPointer<setup>(rime_api.setup);
setup(traits);
 */
//#define RIME_PROTO_BUILDER void
//using RIME_PROTO_BUILDER=System.Void;

using System.Runtime.InteropServices;
namespace Rime.Api.FnPtr;

#pragma warning disable CS8981


// [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
// unsafe public delegate Bool start_maintenance(
// 	Bool full_check
// );




// [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
// unsafe public delegate void join_maintenance_thread();


// [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
// unsafe public delegate RimeSessionId create_session();


// [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
// unsafe public delegate Bool destroy_session(RimeSessionId session_id);





// [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
// unsafe public delegate Bool simulate_key_sequence(
// 	RimeSessionId session_id
// 	,byte* key_sequence
// );


// [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
// unsafe public delegate Bool candidate_list_begin(
// 	RimeSessionId session_id
// 	,RimeCandidateListIterator* iterator
// );

// [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
// unsafe public delegate Bool candidate_list_next(
// 	RimeCandidateListIterator* iterator
// );



[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void setup(RimeTraits* traits);


[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void set_notification_handler(
	RimeNotificationHandler handler
	, void* context_object
);


[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void initialize(
	RimeTraits* traits
);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void finalize();




[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool start_maintenance(Bool full_check);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool is_maintenance_mode();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void join_maintenance_thread();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void deployer_initialize(RimeTraits* traits);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool prebuild();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool deploy();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool deploy_schema(byte* schema_file);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool deploy_config_file(byte* file_name, byte* version_key);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool sync_user_data();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate RimeSessionId create_session();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool find_session(RimeSessionId session_id);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool destroy_session(RimeSessionId session_id);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void cleanup_stale_sessions();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void cleanup_all_sessions();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool process_key(RimeSessionId session_id, int keycode, int mask);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool commit_composition(RimeSessionId session_id);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void clear_composition(RimeSessionId session_id);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool get_commit(RimeSessionId session_id, RimeCommit* commit);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool free_commit(RimeCommit* commit);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool get_context(RimeSessionId session_id, RimeContext* context);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool free_context(RimeContext* ctx);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool get_status(RimeSessionId session_id, RimeStatus* status);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate Bool free_status(RimeStatus* status);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void set_option(RimeSessionId session_id, byte* option, Bool value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool get_option(RimeSessionId session_id, byte* option);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void set_property(RimeSessionId session_id,
											byte* prop,
											byte* value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool get_property(RimeSessionId session_id,
											byte* prop,
											byte* value,
											size_t buffer_size);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool get_schema_list(RimeSchemaList* schema_list);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void free_schema_list(RimeSchemaList* schema_list);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool get_current_schema(RimeSessionId session_id,
												 byte* schema_id,
												 size_t buffer_size);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool select_schema(RimeSessionId session_id, byte* schema_id);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool schema_open(byte* schema_id, RimeConfig* config);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_open(byte* config_id, RimeConfig* config);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_close(RimeConfig* config);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_get_bool(RimeConfig* config, byte* key, Bool* value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_get_int(RimeConfig* config, byte* key, int* value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_get_double(RimeConfig* config, byte* key, double* value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_get_string(RimeConfig* config,
												 byte* key,
												 byte* value,
												 size_t buffer_size);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* config_get_cstring(RimeConfig* config, byte* key);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_update_signature(RimeConfig* config, byte* signer);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_begin_map(RimeConfigIterator* iterator,
											  RimeConfig* config,
											  byte* key);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_next(RimeConfigIterator* iterator);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void config_end(RimeConfigIterator* iterator);


[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool simulate_key_sequence(RimeSessionId session_id,
													 byte* key_sequence);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool register_module(RimeModule* module);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate RimeModule* find_module(byte* module_name);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool run_task(byte* task_name);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* get_shared_data_dir();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* get_user_data_dir();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* get_sync_dir();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* get_user_id();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void get_user_data_sync_dir(byte* dir, size_t buffer_size);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_init(RimeConfig* config);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_load_string(RimeConfig* config, byte* yaml);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_set_bool(RimeConfig* config, byte* key, Bool value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_set_int(RimeConfig* config, byte* key, int value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_set_double(RimeConfig* config, byte* key, double value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_set_string(RimeConfig* config,
												 byte* key,
												 byte* value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_get_item(RimeConfig* config,
											   byte* key,
											   RimeConfig* value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_set_item(RimeConfig* config,
											   byte* key,
											   RimeConfig* value);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_clear(RimeConfig* config, byte* key);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_create_list(RimeConfig* config, byte* key);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_create_map(RimeConfig* config, byte* key);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate size_t config_list_size(RimeConfig* config, byte* key);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool config_begin_list(RimeConfigIterator* iterator,
												RimeConfig* config,
												byte* key);



[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* get_input(RimeSessionId session_id);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate size_t get_caret_pos(RimeSessionId session_id);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool select_candidate(RimeSessionId session_id, size_t index);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* get_version();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void set_caret_pos(RimeSessionId session_id, size_t caret_pos);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool select_candidate_on_current_page(RimeSessionId session_id,
                                                               size_t index);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool candidate_list_begin(RimeSessionId session_id,
                                                    RimeCandidateListIterator* iterator);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool candidate_list_next(RimeCandidateListIterator* iterator);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void candidate_list_end(RimeCandidateListIterator* iterator);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool user_config_open(byte* config_id, RimeConfig* config);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool candidate_list_from_index(RimeSessionId session_id,
                                                         RimeCandidateListIterator* iterator,
                                                         int index);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* get_prebuilt_data_dir();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* get_staging_dir();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void commit_proto(
	RimeSessionId session_id
	,void* commit_builder//RIME_PROTO_BUILDER*
);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void context_proto(
	RimeSessionId session_id
	,void* context_builder//RIME_PROTO_BUILDER*
);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void status_proto(
	RimeSessionId session_id
	,void* status_builder//RIME_PROTO_BUILDER*
);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* get_state_label(RimeSessionId session_id,
                                                byte* option_name,
                                                Bool state);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool delete_candidate(RimeSessionId session_id, size_t index);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool delete_candidate_on_current_page(RimeSessionId session_id,
                                                                 size_t index);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate RimeStringSlice get_state_label_abbreviated(RimeSessionId session_id,
                                                                      byte* option_name,
                                                                      Bool state,
                                                                      Bool abbreviated);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate Bool set_input(RimeSessionId session_id, byte* input);
