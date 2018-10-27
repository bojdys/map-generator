using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public Map map;
	public static bool mapGenerated = false;
	public bool dijEvaluated = false;
	public bool aStarEvaluated = false;
	public GameObject cantGeneratePathMessage;
	public GameObject camera;
	public Scene scene;
	public Menu menu;
	public IDictionary <Vector2, Vector2> dijkstraParentsNodes;
	public IDictionary <Vector2, Vector2> aStarParentsNodes;
	public Vector2 dijkstraParent;
	public Vector2 aStarParent;

	public void Start(){
		map = new Map ();
		scene = new Scene ();
		menu = new Menu ();
	}

	public void GenerateMap(int gridSizeInput, int obstaclesInput){
		ClearMap ();
		map.GenerateGrid (gridSizeInput);
		map.FillEmptySpace();
		map.GenerateObstacles (obstaclesInput);
		map.GenereteBorder ();
		map.GenerateStartAndMeta ();
		map.GenerateEmptySpace ();
		MapGeneratedSettings ();
	}

	public void MapGeneratedSettings(){
		scene.AdjustBackground ();
		scene.AdjustCamera ();
		cantGeneratePathMessage.SetActive (false);
		mapGenerated = true;
		dijEvaluated = false;
		aStarEvaluated = false;	
	}

	public void ClearMap(){
		if(mapGenerated)
			map.ClearGrid ();
	}

	public void EvaluateDijkstra()
	{
		if (mapGenerated)
			map.PathFind (false);
	}

	public void EvaluateAStar()
	{
		if (mapGenerated)
			map.PathFind (true);
	}

	public void DrawDijkstra(){
		if (mapGenerated) {
			if(dijEvaluated)
				map.DrawPath (dijkstraParentsNodes, dijkstraParent, false);
		}

	}

	public void DrawAStar(){
		if (mapGenerated) {
			if (aStarEvaluated) {
				map.DrawPath (aStarParentsNodes, aStarParent, true);
			}
		}
	}

	public void SaveMap(){
		if (mapGenerated) {
			map.Save ();
		}
	}

	public void LoadMap(){
		map.Load ();
	}
		
}