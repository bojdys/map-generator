using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObstacle : Obstacle {

	public VerticalObstacle(int row, int column): base(row,column){
		InstantiateSpot (row + 1, column);
	}

}