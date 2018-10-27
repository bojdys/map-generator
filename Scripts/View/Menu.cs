using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu {

	private string menuName = "Menu";
	private string menuBackgroundName = "MenuBackground";
	private float usedScreenWidth = 1024;
	private int offsetProportion = 100;

	public Menu(){
		GameObject menu = GameObject.Find (menuName); 
		GameObject menuBackground = GameObject.Find (menuBackgroundName);
		float screenWidth = Screen.width;
		float menuWidth = menuBackground.GetComponent<RectTransform>().sizeDelta.x;
		float scale =  screenWidth / usedScreenWidth;
		float newMenuWidth = menuWidth * scale;
		menu.transform.localScale = new Vector3(scale, scale, 1);
		menu.transform.localPosition = new Vector3 (- screenWidth / 2 + newMenuWidth + screenWidth / offsetProportion, 0, 0);
	}
}
