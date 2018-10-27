using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SingleGenerator : ObstacleGenerator{

	public SingleGenerator (ObstacleSpace obstSpace) : base (obstSpace){}

	public override void CountEmpty(int row, int column){
		if (obstacleSpace.isSingleSpace(row, column))
			emptyPlaces++;
	}

	public override bool TryInsertAtSpot (int row, int column)
	{
		if (obstacleSpace.isSingleSpace (row, column)) {
			if (checkedTiles == random) {
				Obstacle obstacle = new Obstacle (row, column);
				return true;
			}
			checkedTiles++;
		}
		return false;
	}

}