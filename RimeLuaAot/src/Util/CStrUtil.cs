using System.Runtime.InteropServices;
using System.Text;

namespace RimeLuaAot.Util;

/// <summary>
/// TODO test
/// </summary>
public static unsafe class CStrUtil{

	public static string? cStrToCsStr(byte* cStr){

		if (cStr == null){ return null;}

		// 計算字元串的長度
		int length = 0;
		while (*(cStr + length) != 0){ // 直到遇到null字符
			length++;
		}

		// 將字元串轉換為byte[]
		byte[] byteArray = new byte[length];
		Marshal.Copy((IntPtr)cStr, byteArray, 0, length);

		// 將byte[]轉換為string，這裡預設為UTF-8編碼
		return Encoding.UTF8.GetString(byteArray);
	}


	public static byte* csStrToCStr(string csStr){
		if (csStr == null) {return null;}
		// 將字符串轉換為byte[]
		byte[] byteArray = Encoding.UTF8.GetBytes(csStr);
		// 分配內存來存儲byteArray + null結束符
		byte* cStr = (byte*)Marshal.AllocHGlobal(byteArray.Length + 1);
		// 複製byteArray到cStr
		for (int i = 0; i < byteArray.Length; i++){
			*(cStr + i) = byteArray[i];
		}
		// 添加null結束符
		*(cStr + byteArray.Length) = 0;
		return cStr;
	}

}