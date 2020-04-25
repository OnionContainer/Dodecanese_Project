using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DodMath{
	private DodMath(){
		// new Rectangle()._width;
	}
}

/**
Augmented Rectangle
由于Unity本体的Rect类不让我继承我就这么套了一层娃
这个类方便以后给矩形对象加功能
*/
public class AugRect{
	private Rect _data = new UnityEngine.Rect();

	public AugRect(float x = 0, float y = 0, float width = 0, float height = 0){
		_data.x = x;
		_data.y = y;
		_data.width = width;
		_data.height = height;

		// new Rect().Set()
	}

	public void Set(float x, float y, float width, float height){
		_data.Set(x,y,width,height);
	}
	
}


