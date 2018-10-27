using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;

public class MapSerializer {

	private string json; 
	private string path; 
	private const string jsonMap = "/mapJSon.json";

	public MapSerializer(){
		#if UNITY_EDITOR
		path = Application.dataPath + jsonMap; 
		#else
		path = Application.streamingAssetsPath + jsonMap;
		#endif
	}

	public void ToJSon(List<MapJSon.ColumnListClass> mapList){ 
		MapJSon mapJSonObject = new MapJSon(); 
		mapJSonObject.columnClass = mapList;
		json = JsonUtility.ToJson(mapJSonObject);
		File.WriteAllText (path, json);
	}

	public List<MapJSon.ColumnListClass> GetJSon(){ 
		if (File.Exists (path)) {
			json = File.ReadAllText (path);
			MapJSon mapJSonObject = JsonUtility.FromJson<MapJSon> (json);
			if (mapJSonObject != null)
				return mapJSonObject.columnClass;
		}
		return null;
	}

}