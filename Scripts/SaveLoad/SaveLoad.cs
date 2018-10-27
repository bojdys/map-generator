using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad {

	private MapSerializer mapSerializer;
	private Controller controller;
	private Save save;
	private Load load;
	private string controllerName = "Controller";
	private int borderGridSizeDifference = 2;

	public SaveLoad(){
		controller = GameObject.Find(controllerName).GetComponent<Controller>();	
		mapSerializer = new MapSerializer ();
		save = new Save ();
		load = new Load ();
	}

	public void SaveMap(){
		save.SaveMap (mapSerializer);
	}

	public void LoadMap(){
		List<MapJSon.ColumnListClass> mapList = mapSerializer.GetJSon ();
		if (mapList != null) {
			if (Controller.mapGenerated)
				controller.ClearMap ();
			load.LoadFills (mapList);
			load.InstantiateImages ();
			controller.MapGeneratedSettings ();
		}
	}

}