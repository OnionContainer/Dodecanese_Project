using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodReadOnlyDictionary<K,V>:IEnumerable{

	private Dictionary<K,V> _source;

	public DodReadOnlyDictionary(Dictionary<K,V> source){
		_source = source;
	}

	public IEnumerator GetEnumerator(){
		return _source.GetEnumerator();
		// return null;
	}

	public V this[K index]{
		get{
			return _source[index];
		}
	}

	public bool ContainsKey(K key){
		return _source.ContainsKey(key);
	}

	public int Count{
		get{
			return _source.Count;
		}
	}


}
