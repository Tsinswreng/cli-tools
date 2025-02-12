using System;
using System.Runtime.InteropServices;
using System.Text;

public class WinClipBoard
{
	[DllImport("user32.dll")]
	public static extern bool OpenClipboard(IntPtr hWndNewOwner);

	[DllImport("user32.dll")]
	public static extern bool CloseClipboard();

	[DllImport("user32.dll")]
	public static extern IntPtr GetClipboardData(uint uFormat);

	[DllImport("user32.dll")]
	public static extern bool IsClipboardFormatAvailable(uint format);

	[DllImport("user32.dll")]
	public static extern IntPtr GlobalLock(IntPtr hGlobal);

	[DllImport("user32.dll")]
	public static extern bool GlobalUnlock(IntPtr hGlobal);

	[DllImport("kernel32.dll")]
	public static extern int GlobalSize(IntPtr hGlobal);

	[DllImport("user32.dll")]
	public static extern bool EmptyClipboard();

	[DllImport("kernel32.dll")]
	public static extern IntPtr GlobalAlloc(uint uFlags, UIntPtr dwBytes);

	[DllImport("kernel32.dll")]
	public static extern IntPtr GlobalFree(IntPtr hGlobal);

	const uint CF_TEXT = 1; // 文本格式
	const uint CF_UNICODETEXT = 13; // Unicode 文本格式
	const uint GMEM_MOVEABLE = 0x0002;

	public static void Main()
	{
		// 讀取剪貼板內容
		ReadFromClipboard();

		// 寫入剪貼板內容
		string textToWrite = "這是一個測試的剪貼板內容。";
		WriteToClipboard(textToWrite);
		Console.WriteLine("已將內容寫入剪貼板。");

		// 再次讀取剪貼板內容
		ReadFromClipboard();
	}

	public static void ReadFromClipboard()
	{
		if (OpenClipboard(IntPtr.Zero))
		{
			// 檢查是否有文本格式的內容
			if (IsClipboardFormatAvailable(CF_UNICODETEXT))
			{
				IntPtr hGlobal = GetClipboardData(CF_UNICODETEXT);
				IntPtr lockedData = GlobalLock(hGlobal);
				int size = GlobalSize(hGlobal);
				string clipboardText = Marshal.PtrToStringUni(lockedData, size / 2); // 由於是 Unicode

				GlobalUnlock(hGlobal);
				Console.WriteLine("剪貼板內容: " + clipboardText);
			}
			else
			{
				Console.WriteLine("剪貼板中沒有可用的文本內容。");
			}
			CloseClipboard();
		}
		else
		{
			Console.WriteLine("無法打開剪貼板。");
		}
	}

	public static void WriteToClipboard(string text)
	{
		IntPtr hGlobal = IntPtr.Zero;

		try
		{
			// 將文本轉換為 Unicode 字符數組
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			IntPtr hGlobalAlloc = GlobalAlloc(GMEM_MOVEABLE, (UIntPtr)(bytes.Length + 2));
			hGlobal = GlobalLock(hGlobalAlloc);

			Marshal.Copy(bytes, 0, hGlobal, bytes.Length);
			Marshal.WriteByte(hGlobal, bytes.Length, 0); // 最後加上空字節

			GlobalUnlock(hGlobalAlloc);

			if (OpenClipboard(IntPtr.Zero))
			{
				EmptyClipboard();
				SetClipboardData(CF_UNICODETEXT, hGlobalAlloc);
			}
		}
		finally
		{
			if (hGlobal != IntPtr.Zero)
			{
				GlobalFree(hGlobal);
			}
		}
	}

	[DllImport("user32.dll")]
	public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
}