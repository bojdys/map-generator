using UnityEngine;
using System.Collections.Generic;
using System;

public class Path {

	private Pathfinding pathfind;
	private Controller controller;
	private string controllerName = "Controller";

	public Path(){
		controller = GameObject.Find(controllerName).GetComponent<Controller>();	
		pathfind = new Pathfinding();
	}

	public void Find(bool aStar){ // Dijkstra / AStar
		pathfind.PrepareData (aStar);
		while (pathfind.unexploredNodes.Count > 0) {
			Vector2 curr;
			if(aStar)
				curr = pathfind.GetBestHeuristicNode();	
			else
				curr = pathfind.GetShortestDistanceNode();
			if (!pathfind.CheckIfPassable (curr))
				return;
			if (!pathfind.CheckIfBetterNodesArePossible (curr))
				return;
			pathfind.unexploredNodes.Remove (curr);
			if (!pathfind.CheckIfLast (curr))
				return;
			IList<Vector2> nodes = pathfind.GetNodesAround (curr);
			pathfind.CheckDistances (curr, nodes);
		}
		controller.cantGeneratePathMessage.SetActive (true);
	}

	public void Draw(IDictionary <Vector2, Vector2> nodeParents, Vector2 parent, bool aStar){
		while(parent != StartMeta.startNode){
			int x = (int)parent.x;
			int y = (int)parent.y;
			Map.grid [x, y].DestroyImage ();
			if (aStar)
				Map.grid[x,y].InstantiateSpot(new Vector2(x,y), (int)Spot.Fill.PathA);
			else 
				Map.grid[x,y].InstantiateSpot(new Vector2(x,y), (int)Spot.Fill.Path);
			parent = nodeParents [parent];
		}
	}

}