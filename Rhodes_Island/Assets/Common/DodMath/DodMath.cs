using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DodMath{
	private DodMath(){}

	public static List<T> findIntersection<T>(List<T> a, List<T> b){
		//todo.. test algorithm

		List<T> result = new List<T>();

		foreach(T obj in a) {
			if (b.Contains(obj)) {
				result.Add(obj);
			}
		}

		return result;
	}

	public static List<T> findComplement<T>(List<T> a, List<T> b){
		//todo.. test algorithm

		List<T> result = new List<T>();

		foreach(T obj in a) {
			if (!b.Contains(obj)) {
				result.Add(obj);
			}
		}

		return result;
	}

}

public class IntVec:IEquatable<IntVec>{
	public int x = 0;
	public int y = 0;

	public IntVec(int x, int y){
		this.x = x;
		this.y = y;
	}

	public string toKey(){
		return this.x + "/" + this.y;
	}

	public IntVec clone(){
		return new IntVec(this.x, this.y);
	}

	public bool Equals(IntVec point){
		return this.x == point.x && this.y == point.y;
	}

	public void rotateClockwise(int times){
		for(int i = 0; i < times; i += 1) {
			rotateClockwise();
		}
	}

	public void rotateClockwise(){
		var tempX = x;
		this.x = y;
		this.y = -tempX;
	}

	public void plus(IntVec point){
		this.x += point.x;
		this.y += point.y;
	}

	public static IEnumerable generateAllInRange(int width, int height){
		IntVec[] result = new IntVec[width*height];
		int index = 0;
		for (int x = 0; x < width; x += 1) {
			for (int y = 0; y < height; y += 1) {
				result[index] = new IntVec(x,y);
				index += 1;
			}
		}
		return result;
	}
}

