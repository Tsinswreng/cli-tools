using model;
namespace service.parser.dictYamlParser;

public interface I_dictLineToDictLineKVs{
	DictLineKVs dictLineToDictLineKVs(in DictLine line);
}

public interface I_lineStrToDictLine{
	DictLine lineStrToDictLine(str line);
}

public interface I_lineStrToDictLineKVs{
	DictLineKVs lineStrToDictLineKVs(str line);
}