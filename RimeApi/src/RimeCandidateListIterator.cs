using System.Runtime.InteropServices;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeCandidateListIterator{
	public void* ptr;
	public int index;
	public RimeCandidate candidate;
}