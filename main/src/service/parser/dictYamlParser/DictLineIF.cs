using model;
namespace service.parser.dictYamlParser;

public interface I_parseLineObj{
	KV?[] parseLineObj(DictLine line);
}

public interface I_parseLineStr{
	DictLine parseLineStr(str line);
}

