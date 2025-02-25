using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeMenu{
	int page_size;
	int page_no;
	int is_last_page;//typedef int Bool in c++
	int highlighted_candidate_index;
	int num_candidates;
	RimeCandidate* candidates;
	byte* select_keys; //char* in c++
}