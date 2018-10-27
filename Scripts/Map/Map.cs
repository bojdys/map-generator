using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map {

	public static Spot[,] grid;
	public static int gridSize;
	public static int gridWithBorderSize;
	private SaveLoad saveLoad;
	private StartMeta startMeta;
	private Path path;
	private ObstacleManager obstacleManager;
	private int borderGridSizeDifference = 2;

	public Map(){
		startMeta = new StartMeta ();
		saveLoad = new SaveLoad();
		path = new Path ();
		obstacleManager = new ObstacleManager();
	}

	public void GenerateGrid(int size){
		gridSize = size;
		gridWithBorderSize = size + borderGridSizeDifference;
		grid = new Spot[gridWithBorderSize, gridWithBorderSize];
		for (int i = 0; i < gridWithBorderSize; i++) {
			for (int j = 0; j < gridWithBorderSize; j++) {
				grid [i, j] = new Spot();
			}
		}
	}
		
	public void ClearGrid(){
		for (int i = 1; i <= gridSize; i++) {
			for (int j = 1; j <= gridSize; j++) {
				grid [i, j].DestroyImage();
			}
		}
		Array.Clear (grid, 0, grid.Length);
	}

	public void FillEmptySpace(){
		for (int i = 1; i <= gridSize; i++) {
			for (int j = 1; j <= gridSize; j++) {
				grid [i, j].fill = (int)Spot.Fill.Empty;
			}
		}
	}

	public void GenerateObstacles(int obstaclesAmount){
		obstacleManager.DivideObstacles (obstaclesAmount);
		obstacleManager.GenerateObstacles();
	}

	public void GenereteBorder(){
		for (int i = 0; i < gridWithBorderSize; i++) {
			int border = (int)Spot.Fill.Border;
			grid [0, i].fill = border;
			grid [gridSize + 1, i].fill = border;
			grid [i, 0].fill = border;
			grid [i, gridSize + 1].fill = border;
		}
	}

	public void GenerateStartAndMeta(){
		startMeta.Generate ((int)Spot.Fill.Start);
		startMeta.Generate ((int)Spot.Fill.Meta);

	}

	public void GenerateEmptySpace(){
		for (int i = 1; i <= gridSize; i++) { 
			for (int j = 1; j <= gridSize; j++) { 
				if (grid [i, j].fill == (int)Spot.Fill.Empty || grid [i, j].fill == (int)Spot.Fill.Around)
					grid[i,j].InstantiateImage(new Vector2(i,j));
			}
		}
	}

	public void PathFind(bool aStar){
		path.Find (aStar);
	}

	public void DrawPath(IDictionary <Vector2, Vector2> nodeParents, Vector2 parent, bool aStar){
		path.Draw (nodeParents, parent, aStar);
	}

	public void Save(){
		saveLoad.SaveMap ();
	}

	public void Load(){
		saveLoad.LoadMap ();
	}

}