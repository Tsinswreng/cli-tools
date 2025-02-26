/*
var setup = Marshal.GetDelegateForFunctionPointer<setup>(rime_api.setup);
setup(traits);
 */




using System.Runtime.InteropServices;
namespace Rime.Api.FnPtr;

#pragma warning disable CS8981

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void setup(IntPtr traits);


