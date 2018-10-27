using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour{
		
	public int fill;
	public enum Fill { Empty, Obstacle, Around, Border, Start, Meta, Path, PathA };		// Around - space around Obstacle so obstacles don't touch eachother // Border - Around the map
	public static float tileWidth = 0;
	private GameObject gameObject;

	public Spot(){
		if (tileWidth == 0)
			tileWidth = Resources.Load<GameObject> (Spot.Fill.Empty.ToString()).GetComponent<SpriteRenderer> ().bounds.size.x; // Loading only on the first time
	}

	public void InstantiateSpot(Vector2 pos, int spotFill){
		fill = spotFill;
		InstantiateImage (pos);
	}

	public void InstantiateImage(Vector2 pos){
		string name;
		if(fill==(int)Spot.Fill.Around)
			name=(Spot.Fill.Empty).ToString ();
		else
			name = ((Spot.Fill)fill).ToString ();
		gameObject= Instantiate (Resources.Load<GameObject>(name));
		gameObject.transform.position=new Vector3 (pos.y * tileWidth, -pos.x * tileWidth, 0);
	}

	public void DestroyImage(){
		Destroy(gameObject);
	}

}
