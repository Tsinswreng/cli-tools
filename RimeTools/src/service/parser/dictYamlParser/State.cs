/** =解析.dict.yaml 文件的状态枚舉 */

namespace service.parser.dictYamlParser;

public enum State{
	start
	,end
	,metadata
	,body
	/** ---  */
	,hyphen3
	/** ...  */
	,dot3
}

