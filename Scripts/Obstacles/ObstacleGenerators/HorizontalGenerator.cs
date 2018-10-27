using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HorizontalGenerator : ObstacleGenerator{

	public HorizontalGenerator (ObstacleSpace obstSpace) : base (obstSpace){}

	public override void CountEmpty(int row, int column){
		if (column < gridSize) {
			if (obstacleSpace.isHorizontalSpace (row, column))
				emptyPlaces++;
		}

	}

	public  override bool TryInsertAtSpot(int row, int column){
		if (column < gridSize) {
			if (obstacleSpace.isHorizontalSpace(row, column)) {
				if (checkedTiles == random) {
					HorizontalObstacle doubleHorObstacle = new HorizontalObstacle (row, column);
					return true;
				}
				checkedTiles++;
			}
		}
		return false;
	}

}