using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartMeta {

	private Spot[,] grid;
	private int gridSize;
	public static Vector2 startNode;
	public static Vector2 metaNode;

	public void Generate(int type){
		grid = Map.grid;
		gridSize = Map.gridSize;
		int empties = CountEmpties ();
		int random = UnityEngine.Random.Range (0, empties - 1);
		int tilesChecked = 0;
		for (int i = 1; i <= gridSize; i++) {
			for (int j = 1; j <= gridSize; j++) {
				if (isEmpty(i,j)){
					if (random == tilesChecked) {
						grid[i,j].InstantiateSpot(new Vector2(i,j), type);
						if (type == (int)Spot.Fill.Start) 
							startNode = new Vector2 (i, j);
						else if (type == (int)Spot.Fill.Meta) 
							metaNode = new Vector2 (i, j);
					}
					tilesChecked++;
				}
			}
		}
	}

	private int CountEmpties(){
		int empties = 0;
		for (int i = 1; i <= gridSize; i++) {
			for (int j = 1; j <= gridSize; j++) {
				if (isEmpty(i,j))
					empties++;
			}
		}
		return empties;
	}

	private bool isEmpty(int row, int column){
		if (grid [row, column].fill == (int)Spot.Fill.Empty || grid [row, column].fill == (int)Spot.Fill.Around)
			return true;
		else
			return false;
	}

}