using model;
namespace service.parser.dictYamlParser;

public interface I_parseLineObj{
	DictLineKVs parseLineObj(in DictLine line);
}

public interface I_parseLineStr{
	DictLine parseLineStr(str line);
}

public interface I_lineStrToKVs{
	DictLineKVs lineStrToKVs(str line);
}