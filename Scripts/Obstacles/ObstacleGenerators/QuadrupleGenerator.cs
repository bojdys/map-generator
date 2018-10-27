using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class QuadrupleGenerator : ObstacleGenerator{

	public QuadrupleGenerator (ObstacleSpace obstSpace) : base (obstSpace){}

	public override void CountEmpty(int row, int column){
		if (row < gridSize && column < gridSize) {
			if (obstacleSpace.isQuadrupleSpace (row, column))
				emptyPlaces++;
		}
	}

	public override bool TryInsertAtSpot(int row, int column){
		if (row < gridSize  && column < gridSize) {
			if (obstacleSpace.isQuadrupleSpace(row, column) ){
				if (checkedTiles == random) {
					QuadrupleObstacle guadrupleObstacle = new QuadrupleObstacle (row, column);
					return true;
				}
				checkedTiles++;
			}
		}
		return false;
	}

}
