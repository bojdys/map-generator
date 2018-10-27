using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundObstacle {

	private Spot[,] grid;

	public void UpdateGrid(){	
		grid = Map.grid;
	}

	public void FillAroundSpot(int i, int j){
		Fill (i - 1, j - 1);
		Fill (i - 1, j);
		Fill (i - 1, j + 1);
		Fill (i, j - 1);
		Fill (i, j + 1);
		Fill (i + 1, j - 1);
		Fill (i + 1, j);
		Fill (i + 1, j + 1);
	}

	private void Fill(int i, int j){
		if(grid[i, j].fill != (int)Spot.Fill.Obstacle)
			grid[i, j].fill = (int)Spot.Fill.Around;
	}

}
	
// No need to write cases for corners and sides because there is border for it which won't be shown on the map (Fill.Border)