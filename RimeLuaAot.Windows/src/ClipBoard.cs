using System;
using System.Text;
using System.Runtime.InteropServices;

class ClipBoard
{
	[DllImport("user32.dll")]
	public static extern bool OpenClipboard(IntPtr hWndNewOwner);

	[DllImport("user32.dll")]
	public static extern bool CloseClipboard();

	[DllImport("user32.dll")]
	public static extern IntPtr GetClipboardData(uint uFormat);

	[DllImport("user32.dll")]
	public static extern bool IsClipboardFormatAvailable(uint format);

	[DllImport("kernel32.dll")]
	public static extern IntPtr GlobalLock(IntPtr hGlobal);

	[DllImport("kernel32.dll")]
	public static extern bool GlobalUnlock(IntPtr hGlobal);

	[DllImport("kernel32.dll")]
	public static extern int GlobalSize(IntPtr hGlobal);

	const uint CF_TEXT = 1; // 文本格式
	const uint CF_UNICODETEXT = 13; // Unicode 文本格式

	public static void Main()
	{
		if (OpenClipboard(IntPtr.Zero))
		{
			// 檢查是否有文本格式的內容
			if (IsClipboardFormatAvailable(CF_UNICODETEXT))
			{
				IntPtr hGlobal = GetClipboardData(CF_UNICODETEXT);
				IntPtr lockedData = GlobalLock(hGlobal);
				int size = GlobalSize(hGlobal);
				String clipboardText = Marshal.PtrToStringUni(lockedData, size / 2); // 因為是 Unicode

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
}

// System.Console.WriteLine("Hello World!");
// ClipBoard.Main();