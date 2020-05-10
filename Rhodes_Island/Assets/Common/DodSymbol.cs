using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodSymbol : MonoBehaviour{

	public static int _curNum = 0;

	private int _data;
	public int data{get{return this._data;}}

	public DodSymbol(){
		this._data = DodSymbol._curNum;
	}

}

public interface Symbolized{
	int getSymbol();
}
