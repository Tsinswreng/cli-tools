// interface Env{
// 	str schema_id{get;set;}
// }

// interface ExtI_isTimeToInit{
// 	//bool isTimeToInit(Env env);//“I_isTimeToInit.isTimeToInit(Env)”必须声明主体，因为它未标记为 abstract、extern 或 partialCS0501
// }

// class ModIniter{
// 	public str? schema_id{get;set;}
// 	public bool isTimeToInit(Env env){
// 		if(schema_id != env.schema_id){
// 			schema_id = env.schema_id;
// 			return true;
// 		}
// 		return false;
// 	}
// }

// static class ImplExtI_isTimeToInit{
// 	//public static ModIniter modIniter{get;set;}
// 	public static Dictionary<Object, ModIniter> modIniterMap = new Dictionary<Object, ModIniter>();
// 	//getter
// 	public static ModIniter modIniter_<T>(this T z){
// 		var modIniter = modIniterMap.GetValueOrDefault(z!);
// 		if(modIniter == null){
// 			modIniter = new ModIniter();
// 			modIniterMap.Add(z!, modIniter);
// 		}
// 		return modIniter;
// 	}

// 	//setter
// 	public static zero modIniter_<T>(this T z, ModIniter v){
// 		modIniterMap.Add(z!, v);
// 		return 0;
// 	}

// 	public static bool isTimeToInit<T>(this T z, Env env){
// 		return z.modIniter_().isTimeToInit(env);
// 	}
// }


// class ModBase{
// 	//......
// }

// static class ModExt{
// 	public static bool isTimeToInit(this Mod mod){
// 		return true;
// 	}
// }

// class Mod: ModBase, ExtI_isTimeToInit{

// }

// class Test{
// 	static void Main(){
// 		Mod mod = new Mod();
// 		mod.isTimeToInit();
// 	}
// }