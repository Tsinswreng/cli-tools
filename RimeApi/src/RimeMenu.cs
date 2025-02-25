using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeMenu{
	public int page_size;
	public int page_no;
	public int is_last_page;//typedef int Bool in c++
	public int highlighted_candidate_index;
	public int num_candidates;
	public RimeCandidate* candidates;
	public byte* select_keys; //char* in c++
}