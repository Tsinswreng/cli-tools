using Shr.Stream.IF;
namespace Shr.IO;
using Chunk = System.ArraySegment<byte>; // 其Count是數組片段之長、非內部數組之長。
public class ByteStreamReader
	:I_Iter<u8>
	,IDisposable
{

	#region impl
	public bool hasNext(){
		return Pos < ByteSize;
	}
	public u8 getNext() {
		if(ChunkPos >= CurChunk.Count){
			CurChunk = ReadNextChunkAsy().Result;
			ChunkPos = 0;
			if(ChunkPos >= CurChunk.Count){
				//return -1; // EOF
				IsEnd = true;
				return 0;
			}
		}
		var ans = CurChunk[ChunkPos];
		ChunkPos++;
		Pos++;
		return ans;
	}
	#endregion impl
	public ByteStreamReader(str path){
		Path = path;
		Fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		ByteSize = Fs.Length;
	}

	public void Dispose(){
		Fs.Dispose();
	}
	~ByteStreamReader(){
		Dispose();
	}


	public str Path { get; set; }
	public FileStream Fs{get; set;}
	public i64 ByteSize {get;set;}
	public i32 BufferSize{get; set;} = 0x100000;

	public bool IsEnd{get; set;} = false;
	public i32 Pos{get; set;} = 0;
	public Chunk CurChunk{get; set;} = default;
	public i32 ChunkPos{get; set;} = 0;//下次將讀取的位置

	public bool IsReadingChunk{get; set;} = false;

	public async Task< Chunk > ReadNextChunkAsy(){
		byte[] buffer = new byte[BufferSize];
		i32 bytesRead = await Fs.ReadAsync(buffer, 0, BufferSize);

		//i32 bytesRead = fs.Read(buffer, 0, bufferSize);
		if(bytesRead <= 0){
			return default; //Array=null, Count=0, Offset=0
		}
		//  return buffer.Take(bytesRead).ToArray(); // 只返回已读取的数据
		return new Chunk(buffer, 0, bytesRead);
	}

	public async Task<zero> AssignNextChunkAsy(){
		IsReadingChunk = true;
		CurChunk = await ReadNextChunkAsy();
		IsReadingChunk = false;
		return 0;
	}

}