using Shr.IF;

namespace Shr.Tokenizer.IF;

public interface I_Token_u8Buf:
	I_Segment<IList<u8>>
{
	//public IList<u8> Data{get;set;}
	public u64 Code{get;set;}
}

//<MyTag MyProp="MyVal" />