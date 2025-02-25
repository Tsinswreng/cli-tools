using Shr.IF;

namespace Shr.Tokenizer.IF;

public interface I_Token:
	I_Segment<IList<u8>>
{
	//public IList<u8> Data{get;set;}
	public u64 code{get;set;}
}

//<MyTag MyProp="MyVal" />