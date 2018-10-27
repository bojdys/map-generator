using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Load : MonoBehaviour {

	private int borderGridSizeDifference = 2;

	public void LoadFills(List<MapJSon.ColumnListClass> mapList){
		int listSize = mapList.Count;
		int gridSize = listSize - borderGridSizeDifference;
		Spot[,] grid = new Spot[listSize, listSize];
		for (int i = 0; i < listSize; i++) {
			for (int j = 0; j < mapList[i].columnList.Count; j++) {
				grid [i, j] = new Spot();
				grid [i, j].fill = mapList [i].columnList [j];
			}
		}
		Map.grid=grid;
		Map.gridSize = gridSize;
		Map.gridWithBorderSize = gridSize + borderGridSizeDifference;
	}

	public void InstantiateImages(){
		Spot[,] grid = Map.grid;
		int gridSize = grid.GetLength(0) - borderGridSizeDifference;
		for (int i = 1; i < gridSize + 1; i++) {				
			for (int j = 1; j < gridSize + 1; j++) {
				grid [i, j].InstantiateImage (new Vector2 (i, j));
				Vector2 node = new Vector2 (i, j);
				if (grid [i, j].fill == (int)Spot.Fill.Start)
					StartMeta.startNode = node;
				else if (grid [i, j].fill == (int)Spot.Fill.Meta)
					StartMeta.metaNode = node;
			}
		}
	}
		
}
