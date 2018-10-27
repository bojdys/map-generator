using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene {

	private MainCamera mainCamera;
	private Background background;
	public static int gridSizeToScale = 15;

	public Scene(){
		mainCamera = new MainCamera (gridSizeToScale);
		background = new Background ();
	}

	public void AdjustCamera(){
		mainCamera.Adjust ();
	}

	public void AdjustBackground(){
		background.gridSize = Map.gridSize;
		if (background.gridSize > gridSizeToScale)
			background.AdjustToBigGrid ();
		else 
			background.AdjustToSmallGrid ();
		background.ApplyAdjustments();
	}


}
