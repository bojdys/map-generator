using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ObstacleManager {

	private int types = 0;
	private ObstacleSpace obstacleSpace;
	private List<ObstacleGenerator> obstacleGenerators;

	public ObstacleManager(){
		obstacleSpace = new ObstacleSpace ();
		obstacleGenerators = new List<ObstacleGenerator> ();
		obstacleGenerators.Add (new SingleGenerator (obstacleSpace));
		obstacleGenerators.Add (new HorizontalGenerator (obstacleSpace));
		obstacleGenerators.Add (new VerticalGenerator (obstacleSpace));
		obstacleGenerators.Add (new QuadrupleGenerator (obstacleSpace));
		types = obstacleGenerators.Count;
	}

	public void DivideObstacles(int obstacles){ 
		if (obstacles < types) {
			for (int i = 0; i < types; i++) {
				if (i < obstacles)
					obstacleGenerators [i].obstacles = 1;
				else
					obstacleGenerators [i].obstacles = 0;
			}
		} else {
			int obstaclesInType = obstacles / types;
			int rest = obstacles % types;
			obstacleGenerators [0].obstacles = obstaclesInType + rest;
			for (int i = 1; i < types; i++) {
				obstacleGenerators [i].obstacles = obstaclesInType;
			}
		}
	}

	public void GenerateObstacles(){
		obstacleSpace.UpdateGrid ();
		for (int i = 0; i < types; i++) {
			for (int j = 0; j < obstacleGenerators [i].obstacles; j++) {
				obstacleGenerators [i].CountEmptyPlaces ();	
				obstacleGenerators [i].ChooseRandomSpot ();
				obstacleGenerators [i].TryInsert (); 
			}
		}
	}
		
}