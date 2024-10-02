using model;
namespace service.parser.dictYamlParser;

public interface I_parseLineObj{
	KV?[] parseLineObj(in DictLine line);
}

public interface I_parseLineStr{
	DictLine parseLineStr(str line);
}

public interface I_lineStrToKVs{
	KV[] lineStrToKVs(str line);
}