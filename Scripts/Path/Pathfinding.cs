using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class Pathfinding {

	private Vector2 startNode;
	private Vector2 metaNode;
	private int[,] gridFills;
	private Spot[,] grid;
	private int gridSize;
	private bool metaFound;
	private bool aStar;
	private Controller controller;
	private string controllerName = "Controller";
	private int borderGridSizeDifference = 2;
	private IDictionary <Vector2, Vector2> nodeParents;
	public IDictionary <Vector2, int> distances;
	public HashSet<Vector2> unexploredNodes;
	public IDictionary <Vector2, int> heuristicScore; // for AStar

	public Pathfinding(){
		controller = GameObject.Find(controllerName).GetComponent<Controller>();	
	}

	public void PrepareData(bool aStarAl){
		aStar = aStarAl;
		grid = Map.grid;
		gridSize = Map.gridSize;
		startNode = StartMeta.startNode;
		metaNode = StartMeta.metaNode;
		gridFills = RewriteArray (grid);
		nodeParents = new Dictionary<Vector2, Vector2>();
		distances = new Dictionary <Vector2, int> ();
		unexploredNodes = new HashSet<Vector2> ();
		heuristicScore = new Dictionary <Vector2, int> (); // for AStar
		PreparePathData ();
		distances[startNode] = 0;
		if(aStar)
			heuristicScore [startNode] = Euclidean (startNode, metaNode);
		bool metaFound = false;
	}

	private void PreparePathData(){
		for (int i = 1; i < gridSize + 1; i++) {
			for (int j = 1; j < gridSize + 1; j++) {
				if (isSpotEmpty(i, j)) {
					Vector2 point = new Vector2 (i, j);
					nodeParents.Add(new KeyValuePair<Vector2,Vector2>(point,new Vector2(-1, -1)));
					unexploredNodes.Add(point);
					distances.Add(new KeyValuePair<Vector2, int>(point,int.MaxValue));
					if(aStar)
						heuristicScore.Add(new KeyValuePair<Vector2, int>(point,int.MaxValue));	
				}
			}
		} 
	}

	public Vector2 GetShortestDistanceNode(){
		return distances.Where (x => unexploredNodes.Contains (x.Key)).OrderBy (x => x.Value).First ().Key;
	}

	public Vector2 GetBestHeuristicNode(){
		return heuristicScore.Where (x => unexploredNodes.Contains (x.Key)).OrderBy (x => x.Value).First ().Key;
	}

	private bool isSpotEmpty(int row, int column){
		if (gridFills [row, column] != (int)Spot.Fill.Obstacle && gridFills [row, column] != (int)Spot.Fill.Border)
			return true;
		else
			return false;
	}

	private int[,] RewriteArray(Spot[,] array){
		int length = gridSize + borderGridSizeDifference;
		int[,] newArray = new int[length, length];
		for (int i = 0; i < length; i++) {
			for (int j = 0; j < length; j++) {
				newArray [i, j] = array [i, j].fill;
			}
		}
		return newArray;
	}

	public bool CheckIfPassable(Vector2 curr){
		if (distances [curr] == int.MaxValue) { 
			controller.cantGeneratePathMessage.SetActive (true);
			return false;
		} else
			return true;
	}

	public bool CheckIfBetterNodesArePossible(Vector2 curr){
		if (metaFound && distances [curr] >= distances [metaNode]) {     
			Vector2 parent = nodeParents [metaNode];
			FoundPath (parent, nodeParents);
			return false;
		} else
			return true;
	}

	public bool CheckIfLast(Vector2 curr){
		if (curr == metaNode) {
			metaFound = true;
			if (aStar || unexploredNodes.Count == 0) { 
				Vector2 parent = nodeParents [metaNode];
				FoundPath (parent, nodeParents);
				return false;
			}
		}
		return true;
	}

	public void CheckDistances(Vector2 curr, IList<Vector2> nodes){
		foreach (Vector2 node in nodes) {
			int dist = distances [curr] + 1;
			if (dist < distances [node]) {
				distances [node] = dist;
				nodeParents [node] = curr;
				if(aStar)
					heuristicScore[node] = distances[node] + Euclidean(node, metaNode);	
			}
		} 
	}

	void FoundPath(Vector2 parent, IDictionary <Vector2, Vector2> nodeParents){
		if (aStar) {
			controller.aStarEvaluated = true;
			controller.aStarParentsNodes = nodeParents;
			controller.aStarParent = parent;
		} else {
			controller.dijEvaluated = true;
			controller.dijkstraParentsNodes = nodeParents;
			controller.dijkstraParent = parent;
		}
	}

	public IList<Vector2> GetNodesAround (Vector2 curr){
		int obstacle = (int)Spot.Fill.Obstacle;
		int border = (int)Spot.Fill.Border;
		IList<Vector2> nodesAround = new List<Vector2>();
		int x = (int)curr.x;
		int y = (int)curr.y;
		int fill = gridFills[x - 1, y];
		if(fill != obstacle && fill != border)
			nodesAround.Add(new Vector2(x-1, y));
		fill = gridFills [x, y - 1];
		if(fill != obstacle && fill != border)
			nodesAround.Add(new Vector2(x, y - 1));
		fill = gridFills [x, y + 1];
		if(fill != obstacle && fill != border)
			nodesAround.Add(new Vector2(x, y + 1));
		fill = gridFills [x + 1, y];
		if (fill != obstacle && fill != border)
			nodesAround.Add (new Vector2 (x + 1, y));
		return nodesAround; 
	}

	private int Euclidean (Vector2 nodeS, Vector2 nodeG){
		return (int) Mathf.Sqrt(Mathf.Pow(nodeS.x - nodeG.x, 2) + Mathf.Pow(nodeS.y - nodeG.y, 2));
	}

}
