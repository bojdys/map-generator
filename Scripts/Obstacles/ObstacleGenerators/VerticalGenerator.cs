using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class VerticalGenerator : ObstacleGenerator{

	public VerticalGenerator (ObstacleSpace obstSpace) : base (obstSpace){}	

	public override void CountEmpty(int row, int column){
		if (row < gridSize) {
			if (obstacleSpace.isVerticalSpaceFor (row, column)) 
				emptyPlaces++;
		}
	}

	public  override bool TryInsertAtSpot(int row, int column){
		if (row < gridSize) {
			if (obstacleSpace.isVerticalSpaceFor (row, column)) {
				if (checkedTiles == random) {
					VerticalObstacle verticalObstacle = new VerticalObstacle (row, column);
					return true;
				}
				checkedTiles++;
			}
		}
		return false;
	}

}