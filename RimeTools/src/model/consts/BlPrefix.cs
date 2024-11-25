namespace model.consts;

public class BlPrefix{
	public const str delimiter = ":";
	public const str dictYaml = "dict.yaml";
	public const str userdb = "userdb";
	public static str parse(str prefix, str name){
		return prefix + delimiter + name;
	}
}