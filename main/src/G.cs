/** =Global functions */
public static class G {

	public static bool refEq(object o1, object o2){
		return object.ReferenceEquals(o1, o2);
	}

	/** 
	 *  Compare two LITERAL strings for O(1) by ref,
	 *  only for literal, DO NOT use for `new String()`
	 */
	public static bool lstrEq(str s1, str s2){
		return refEq(s1, s2);
	}

	/// <summary>
	/// notNull
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="v"></param>
	/// <param name="errMsg"></param>
	/// <returns></returns>
	/// <exception cref="NullReferenceException"></exception>
	public static T nn<T>(T? v, str errMsg=""){
		if(v == null){
			throw new NullReferenceException(errMsg);
		}
		return v;
	}

}