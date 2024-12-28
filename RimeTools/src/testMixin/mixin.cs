// using System.Runtime.CompilerServices;

// interface I_Env{
// 	str schema_id{get;set;}
// }

// //test
// class Env : I_Env{
// 	public static Env inst = new Env();
// 	public str schema_id{get;set;} = "";
// }

// interface I_isTimeToInit{
// 	public bool isTimeToInit(I_Env env);//“I_isTimeToInit.isTimeToInit(Env)”必须声明主体，因为它未标记为 abstract、extern 或 partialCS0501
// }

// interface I_schemaId{
// 	public str schema_id{get;set;}
// }

// class ModIniter : I_isTimeToInit{
// 	public str? schema_id{get;set;}
// 	public bool isTimeToInit(I_Env env){
// 		if(schema_id != env.schema_id){
// 			schema_id = env.schema_id;
// 			return true;
// 		}
// 		return false;
// 	}
// }

// class ModIniterProp{
// 	public static ModIniterProp inst = new ModIniterProp();
// 	public ConditionalWeakTable<Object, ModIniter> inst__modIniter = new();

// }

// interface MixinI_isTimeToInit: I_isTimeToInit{
// 	//public ModIniter modIniter{get;set;} = new ModIniter();//接口中的实例属性不能具有初始值设定项。
// 	public ModIniter modIniter{
// 		get{
// 			//var inst = ModIniterProp.inst.inst__modIniter.GetValueOrDefault(this);
// 			var wMap = ModIniterProp.inst.inst__modIniter;
// 			if(  !wMap.TryGetValue(this, out var inst)  ){
// 				inst = new ModIniter();
// 				ModIniterProp.inst.inst__modIniter.Add(this, inst);
// 			}
// 			return inst;
// 		}set{
// 			//ModIniterProp.inst.inst__modIniter[this] = value;
// 			var wMap = ModIniterProp.inst.inst__modIniter;
// 			wMap.AddOrUpdate(this, value);
// 		}
// 	}
// 	public ModIniter modIniter_(){
// 		if(modIniter == null){
// 			modIniter = new ModIniter();
// 		}
// 		return modIniter;
// 	}
// 	public zero modIniter_(ModIniter v){
// 		modIniter = v;
// 		return 0;
// 	}
// 	bool I_isTimeToInit.isTimeToInit(I_Env env){
// 		return modIniter_().isTimeToInit(env);
// 	}

// }

// class ModBase{
// 	public zero test(){
// 		System.Console.WriteLine("114514");
// 		return 0;
// 	}
// }

// class Mod : ModBase, MixinI_isTimeToInit, IDisposable{
// 	public void Dispose(){

// 	}
// 	~Mod(){
// 		Dispose();
// 	}
// }

// class Test{
// 	static zero Main(){
// 		I_isTimeToInit mod = new Mod();
// 		mod.isTimeToInit(Env.inst); // ok
// 		var mod2 = new Mod();
// 		//mod2.isTimeToInit(Env.inst);//“Mod”未包含“isTimeToInit”的定义，并且找不到可接受第一个“Mod”类型参数的可访问扩展方法“isTimeToInit”(是否缺少 using 指令或程序集引用?)CS1061
// 		return 0;
// 	}
// }
