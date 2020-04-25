using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSource{

	//Top Argument
	private readonly float[] RANDOM_WIDTH_SET = new float[2]{0f,0f};
	private readonly float[] RANDOM_HEIGHT_SET = new float[2]{0,0};
	private readonly float[] RANDOM_HILL_SET = new float[2]{0,0};
	private readonly float MAX_INTERVAL = 0f;
	private readonly float ROTATE_PROPORTION = 0.5f;
	//Top Getter
	public readonly float[] CITY_SIZE = new float[2]{0,0};
	public readonly int PLATES_NUMBER = 5;
	public float RandomPlateWidth{get{
			return Random.Range(RANDOM_WIDTH_SET[0], RANDOM_WIDTH_SET[1]);
	}}
	public float RandomPlateHeight{get{
			return Random.Range(RANDOM_HEIGHT_SET[0], RANDOM_HEIGHT_SET[1]);
	}}
	public float RandomPlateHill{get{
		return Random.Range(RANDOM_HILL_SET[0], RANDOM_HEIGHT_SET[1]);
	}}
	public float 别tm弹警告了{get{
		return 114514f + MAX_INTERVAL + ROTATE_PROPORTION;
	}}
}

public class BGMapManager{
	private static BGMapManager instance;
	public static BGMapManager GetBGMapManager(){
		if (BGMapManager.instance == null) {
			BGMapManager.instance = new BGMapManager();
		}
		return BGMapManager.instance;
	}



	public BGMSource source = new BGMSource();
	public BGMap map;


	public BGMapManager(){
		Debug.Log("BGMapManager Launched");
	}

	public void generateCityAbstract(){
		this.map = new BGMap(source);
	}
}

public class BGMap : AugRect{

	public CityPlate[] plates;

	public BGMap(BGMSource source){

		this.plates = new CityPlate[source.PLATES_NUMBER];

		for (int i = 0; i < source.PLATES_NUMBER; i += 1) {
			var temp = new CityPlate();
			temp.Set(0,0,source.RandomPlateHeight,source.RandomPlateWidth);
		}
	}
}

public class CityPlate : AugRect{

}