using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle {

	public enum Type { Single, Horizontal, Vertical, Quadruple };	// DoubleHorizontal, DoubleVertical
	public static bool contactAllowed;
	private AroundObstacle aroundObstacle;
	private Spot[,] grid;

	public Obstacle(int row, int column){
		grid = Map.grid;		
		if (!contactAllowed) 
			aroundObstacle = new AroundObstacle();
		InstantiateSpot (row, column);
	}

	public void InstantiateSpot(int row, int col){
		grid[row, col].InstantiateSpot(new Vector2(row, col),(int)Spot.Fill.Obstacle);
		if (!contactAllowed) {
			aroundObstacle.UpdateGrid();
			aroundObstacle.FillAroundSpot (row, col);
		}
	}
}