using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Background {

	public GameObject background;
	public int gridSize;
	private float defaultBckgroundPosZ; 
	private float tileWidth;
	private float halfTileWidth;
	private int gridSizeToScale;
	private Vector3 defaultBackgroundScale;
	private Vector3 backgroundPosition;
	private Vector3 backgroundScale;
	private string backgroundName = "Background";

	public Background(){
		background = GameObject.Find (backgroundName);
		defaultBackgroundScale = background.transform.localScale;
		defaultBckgroundPosZ = background.transform.position.z;
		gridSizeToScale = Scene.gridSizeToScale;
		tileWidth = Spot.tileWidth;
		halfTileWidth = tileWidth / 2;
	}

	public void AdjustToSmallGrid(){
		float shift = getShift();
		backgroundPosition = new Vector3 (gridSize * halfTileWidth + shift, - gridSize * halfTileWidth - shift, defaultBckgroundPosZ);
		backgroundScale = new Vector3 (defaultBackgroundScale.x, defaultBackgroundScale.y, defaultBackgroundScale.z); 
	}

	public void AdjustToBigGrid(){
		float shift = getHalfGridDimension();
		int scaleRatio = gridSize / gridSizeToScale;
		backgroundPosition = new Vector3 (gridSize * halfTileWidth + shift, - gridSize * halfTileWidth - shift, defaultBckgroundPosZ * scaleRatio);
		backgroundScale = new Vector3 (defaultBackgroundScale.x * scaleRatio, defaultBackgroundScale.y * scaleRatio, backgroundScale.z);
	}

	public void ApplyAdjustments(){
		background.transform.position = backgroundPosition;
		background.transform.localScale = backgroundScale;
	}

	private float getShift(){
		return getHalfGridDimension() + halfTileWidth;
	}

	private float getHalfGridDimension(){
		return Spot.tileWidth * gridSize / 2;
	}

}