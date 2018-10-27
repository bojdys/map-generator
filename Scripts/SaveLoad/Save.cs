using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Save : MonoBehaviour {
	
	public void SaveMap(MapSerializer mapSerializer){
		Spot[,] grid = Map.grid;
		int gridWithBorderSize = Map.gridWithBorderSize;
		List<MapJSon.ColumnListClass> mapList = new List<MapJSon.ColumnListClass> ();
		for (int i = 0; i < gridWithBorderSize; i++) {
			List<int> columns = new List<int> ();
			for (int j = 0; j < gridWithBorderSize; j++) {
				columns.Add( grid[i,j].fill);
			}
			MapJSon.ColumnListClass columnList = new MapJSon.ColumnListClass (columns);
			mapList.Add (columnList);
		}
		mapSerializer.ToJSon (mapList);
	}

}


