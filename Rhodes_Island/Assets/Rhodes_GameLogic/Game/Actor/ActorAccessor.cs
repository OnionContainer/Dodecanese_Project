using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAccessor : MonoBehaviour,Symbolized {

	public int getSymbol(){return this._symb.data;}
	private DodSymbol _symb = new DodSymbol();
	
}
