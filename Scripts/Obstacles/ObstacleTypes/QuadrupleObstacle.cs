using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadrupleObstacle : Obstacle {

	public QuadrupleObstacle(int row, int column): base(row,column){
		InstantiateSpot (row, column + 1);
		InstantiateSpot (row + 1, column);
		InstantiateSpot (row + 1, column + 1);
	}

}