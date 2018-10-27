using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : Obstacle {

	public HorizontalObstacle(int row, int column) : base(row,column){
		InstantiateSpot (row, column + 1);
	}

}
