using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpace {

	private Spot[,] grid;
	private int empty = (int)Spot.Fill.Empty;

	public void UpdateGrid(){
		grid = Map.grid;
	}

	public bool isSingleSpace(int row, int col){
		if (isSpotEmpty(row, col))
			return true;
		else
			return false;
	}

	public bool isHorizontalSpace(int row, int col){
		if (isSpotEmpty(row, col) && isRightSpotEmpty(row, col))
			return true;
		else
			return false;
	}

	public bool isVerticalSpaceFor(int row, int col){
		if(isSpotEmpty(row, col) && isLowerSpotEmpty(row, col))
			return true;
		else
			return false;
	}

	public bool isQuadrupleSpace(int row, int col){
		if (isSpotEmpty(row, col) && isRightSpotEmpty(row, col) && isLowerSpotEmpty(row, col) && isLowerRightSpotEmpty(row, col))
			return true;
		else
			return false;
	}

	private bool isSpotEmpty(int row, int col){
		if (grid [row, col].fill == empty)
			return true;
		else
			return false;
	}

	private bool isRightSpotEmpty(int row, int col){
		if (grid [row, col + 1].fill == empty)
			return true;
		else
			return false;
	}

	private bool isLowerSpotEmpty(int row, int col){
		if (grid [row + 1, col].fill == empty)
			return true;
		else
			return false;
	}

	private bool isLowerRightSpotEmpty(int row, int col){
		if (grid [row + 1, col + 1].fill == empty)
			return true;
		else
			return false;
	}

}
