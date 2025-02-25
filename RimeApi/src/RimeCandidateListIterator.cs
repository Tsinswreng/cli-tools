using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeCandidateListIterator{
	void* ptr;
	int index;
	RimeCandidate candidate;
}