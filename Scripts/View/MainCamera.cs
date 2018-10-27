using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainCamera : MonoBehaviour {

	private int cameraPosZ = -10;
	private static int sizeToScale;
	private Camera camera;
	private string mainCameraName = "Main Camera";

	public MainCamera(int size){
		sizeToScale = size;
		GameObject mainCamera = GameObject.Find (mainCameraName);
		camera = mainCamera.GetComponent<Camera> ();
	}

	public void Adjust(){
		int size = Map.gridSize;
		float halfTile = Spot.tileWidth / 2;
		Vector3 cameraPosition = new Vector3 (size * halfTile + halfTile, - size * halfTile - halfTile, cameraPosZ);
		if (size > sizeToScale) {
			int halfSize = size / 2;
			cameraPosition = new Vector3 (cameraPosition.x, cameraPosition.y, - halfSize);
		}
		camera.GetComponent<Camera> ().transform.position = cameraPosition;
	}

}