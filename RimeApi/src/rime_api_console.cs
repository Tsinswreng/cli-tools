using System.Runtime.InteropServices;
using Rime.Api;
using Shr.Interop;

unsafe class RimeApiConsole {

	public RimeApiConsole(){
		rimeApiPtr = RimeApiFn.rime_get_api();
		rime = new DelegateRimeApiFn(rimeApiPtr);
	}

	public RimeApi* rimeApiPtr{get;set;}
	public DelegateRimeApiFn rime{get;set;}


	public static str? S(u8* str){
		return Shr.Interop.CStrUtil.cStrToCsStr(str);
	}
	protected zero printf(u8* str){

		return 0;
	}

	public zero put(params object?[] obj){
		foreach(var o in obj){
			System.Console.Write(o);
			System.Console.Write(" ");
		}
		return 0;
	}

	public zero print_status(RimeStatus* status){
		put(
			"schema: "+S(status->schema_id)
			+"/"+S(status->schema_name)
			+"\n"
		);
		//print status 略
		return 0;
	}

	public zero print_composition(RimeComposition* composition){
		var preedit = S(composition->preedit);
		if(preedit == null){
			return 0;
		}
		var len = preedit.Length;
		var start = composition->sel_start;
		var end = composition->sel_end;
		var cursor = composition->cursor_pos;
		for(var i = 0; i <= len; i++){
			if(start < end){
				if(i == start){
					put("[");
				}else if( i== end){
					put("]");
				}
			}
			if(i == cursor){
				put("|");
			}
			if(i < len){
				put(preedit[i]);
			}
		}
		put("\n");
		return 0;
	}

	public zero print_menu(RimeMenu* menu){
		if(menu->num_candidates == 0){
			return 0;
		}
		put(
			"page: "+menu->page_no
			+", page_size: "+menu->page_size
			+", is_last_page: "+menu->is_last_page
			+"\n"
		);
		for(var i = 0; i < menu->num_candidates; i++){
			var highlighted = (i== menu->highlighted_candidate_index);
			put(
				i+1+". "
				+S(menu->candidates[i].text)
				+S(menu->candidates[i].comment)
			);
			put("\n");
		}
		return 0;
	}

	public zero print_context(RimeContext* context){
		//略
		return 0;
	}

	public zero print(RimeSessionId session_id){
		var commit = new RimeCommit();
		commit.data_size = RimeUtil.dataSize<RimeCommit>();

		var status = new RimeStatus();
		status.data_size = RimeUtil.dataSize<RimeStatus>();

		var context = new RimeContext();
		context.data_size = RimeUtil.dataSize<RimeContext>();

		if(rime.get_commit(session_id, &commit)
			!=RimeUtil.False
		){
			put(
				"commit: "
				+S(commit.text)
				+"\n"
			);
			rime.free_commit(&commit);
		}

		if(rime.get_status(session_id, &status)
			!=RimeUtil.False
		){
			print_status(&status);
			rime.free_status(&status);
		}
		if(rime.get_context(session_id, &context)
			!=RimeUtil.False
		){
			print_context(&context);
			rime.free_context(&context);
		}
		return 0;
	}

	public bool execute_special_command(str line, RimeSessionId session_id){
		if(line == "print schema list"){
			var list = new RimeSchemaList();
			var ans_get_schema_list = rime.get_schema_list(&list);
			if(ans_get_schema_list != RimeUtil.False){
				put("schema list size:"+list.size+"\n");
				put("schema list:\n");
				for(var i = 0uL; i < list.size; i++){
					var cur = list.list[i];
					put(
						i+1
						+". "
						+S(list.list[i].name)
						+" "+S(list.list[i].schema_id)
					);
				}
				rime.free_schema_list(&list);
			}
			var len_current = 100;
			var current = stackalloc byte[len_current];
			if(rime.get_current_schema(session_id, current, (size_t)len_current) != RimeUtil.False){
				put("current schema: "+S(current)+"\n");
			}
			return true;
		}//~if(line == "print schema list")
		if(line == "print candidate list"){
			var iterator = new RimeCandidateListIterator();
			if(rime.candidate_list_begin(session_id, &iterator) != RimeUtil.True){
				return true;
			}
			for(;rime.candidate_list_next(&iterator) != RimeUtil.False;){
				put(
					iterator.index+1+". "
					+S(iterator.candidate.text)
				);
				if(iterator.candidate.comment != null){
					put($"({S(iterator.candidate.comment)})");
				}
				put("\n");
			}
			rime.candidate_list_end(&iterator);
			return true;
		}
		//TODO
		return false;
	}

	public void on_message(
		void* context_object
		,UIntPtr session_id
		,byte* message_type
		,byte* message_value
	){
		put(
			session_id
			+" "+S(message_type)
			+" "+S(message_value)
		);
		//略
	}

	public int run(){
		var traits = new RimeTraits();
		traits.data_size = RimeUtil.dataSize<RimeTraits>();
		traits.app_name = "rime.cosole".cStr();
		traits.user_data_dir = "E:/_code/rime/my_rime/build/librime_native/bin".cStr();
		rime.setup(&traits);

		rime.set_notification_handler(
			on_message
			,null
		);
		put("init...\n");

		rime.initialize(null);
		var full_check = RimeUtil.True;
		if(rime.start_maintenance(full_check)!= RimeUtil.False){
			rime.join_maintenance_thread();
		}
		put("ready.\n");
		var session_id = rime.create_session();
		if(session_id == 0){
			put("failed to create session.\n");
			return 1;
		}

		int mKaxLength = 99;
		for(;;){
			var line = Console.ReadLine()??"";
			if(line == "exit"){
				break;
			}
			if(line == "reload"){
				put("reload is not supported.\n");
				continue;
			}
			if(execute_special_command(line, session_id)){
				continue;
			}
			if(rime.simulate_key_sequence(session_id, line.cStr())!=RimeUtil.False){
				put(session_id);
			}else{
				put("Error processing key sequence: "+line+"\n");
			}
		}

		rime.destroy_session(session_id);
		rime.finalize();

		return 0;
	}

}