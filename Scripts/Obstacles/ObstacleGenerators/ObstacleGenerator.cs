using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ObstacleGenerator {

	public int gridSize;
	public int random;
	public int checkedTiles;
	public int emptyPlaces;
	public int obstacles = 0;
	public ObstacleSpace obstacleSpace;

	public ObstacleGenerator(ObstacleSpace obstSpace){
		obstacleSpace = obstSpace;
	}

	public void CountEmptyPlaces(){
		gridSize = Map.gridSize;
		emptyPlaces = 0;
		for (int i = 1; i <= gridSize; i++) {
			for (int j = 1; j <= gridSize; j++) {
				CountEmpty (i, j);
			}
		}
	}

	public void ChooseRandomSpot(){
		random = UnityEngine.Random.Range (0, emptyPlaces - 1);
	}
		
	public bool TryInsert(){
		checkedTiles = 0;
		for (int i = 1; i <= gridSize; i++) {
			for (int j = 1; j <= gridSize; j++) {
				if (TryInsertAtSpot (i, j))
					return true;
			}
		}
		return false;
	}

	public abstract void CountEmpty(int row, int column);

	public abstract bool TryInsertAtSpot(int row, int column);

}