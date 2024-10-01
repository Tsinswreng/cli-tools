namespace test;
using model;
using YamlDotNet.Serialization;
public class TestParseDictMetadata{

	public static str yamlStr = 
@"name: prd
version: ""0.1""
columns:
  - text
  - code
  - weight
use_preset_vocabulary: false";
	public static void Main_(){
		var deserializer = new DeserializerBuilder().Build();
		var metadata = deserializer.Deserialize<DictMetadata>(yamlStr);
		Console.WriteLine(metadata.name);
		Console.WriteLine(metadata.version);
		Console.WriteLine(string.Join(", ", metadata.columns));
	}
}
