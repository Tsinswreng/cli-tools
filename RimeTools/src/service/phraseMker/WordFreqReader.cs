using db;
using model;
using Shr.Stream.IF;

namespace service;

/// <summary>
/// 從數據庫讀八股文
/// temp 當改成流式
/// </summary>
public class WordFreqReader : I_Iter<WordFreq>, IDisposable{

	protected RimeDbContext _dbCtx = new RimeDbContext();

	protected IList<WordFreq> _buffer = new List<WordFreq>();

	protected i32 _pos = 0;

	public WordFreqReader(){
		this._readAll();
	}

	~WordFreqReader(){
		Dispose();
	}

	public void Dispose(){
		_dbCtx.Dispose();
	}

	protected void _readAll(){
		_buffer = _dbCtx.WordFreq.OrderByDescending(e=>e.vI64)
			//.Take(200000)
			.ToList()
		;
	}

	protected bool _isEnd = false;

	public bool hasNext(){
		return !_isEnd;
	}


	public WordFreq getNext(){
		if(_pos >= _buffer.Count){
			_isEnd = true;
			return default!;
		}
		var ans = _buffer[_pos];
		_pos++;
		return ans;
	}
}

