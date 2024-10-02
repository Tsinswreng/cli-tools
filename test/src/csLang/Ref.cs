namespace test.csLang;


public struct Point{
	public Point(i64 x, i64 y) {
		this.x = x;
		this.y = y;
	}
	public i64 x;
	public i64 y;
}

public class Ref {



	public static i32 _testCompileErr(){
		var p = new Point(1, 2);
		noRef(p);

		withRef(ref p);
		//withRef(in p);

		withIn(p);
		withIn(p);

		refReadonly(ref p);
		refReadonly(p); // warning
		refReadonly(in p);
		refReadonly(ref p);
		return 0;
	}

	public static i32 noRef(Point p){
		return 0;
	}

	public static i32 withRef(ref Point p){
		return 0;
	}

 	public static i32 withIn(in Point p){
		return 0;
	}

	public static i32 refReadonly(ref readonly Point p){
		//p.x = 114; error
		return 0;
	}

	public static i32 testRefReadonlyWithNoRefIn(){
		return 0;
	}
}