using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI : MonoBehaviour {

	public InputField SizeInputField;
	public InputField ObstaclesInputField;
	public Button GenerateButton;
	public Button DijkstraButton;
	public Button ShowDijButton;
	public Button AStarButton;
	public Button ShowAStarButton;
	public Button SaveButton;
	public Button LoadButton;
	public Button ContactButton;
	public Text ContactText;
	public Controller controller;
	public GameObject wrongValueMessage;
	private int mininumSize = 10;
	private string allowContact = "Allow contact";
	private string disallowContact = "Disallow contact";
	private string empty = "";

	void Start () {

		Button btnGenerate = GenerateButton.GetComponent<Button>();
		btnGenerate.onClick.AddListener(GenerateTask);

		Button btnDij = DijkstraButton.GetComponent<Button>();
		btnDij.onClick.AddListener(DijkstraTask);

		Button btnShowDij = ShowDijButton.GetComponent<Button>();
		btnShowDij.onClick.AddListener(ShowDijTask);

		Button btnAStar = AStarButton.GetComponent<Button>();
		btnAStar.onClick.AddListener(AStarTask);

		Button btnShowAStar = ShowAStarButton.GetComponent<Button>();
		btnShowAStar.onClick.AddListener(ShowAStarTask);

		Button btnSave = SaveButton.GetComponent<Button>();
		btnSave.onClick.AddListener(SaveTask);

		Button btnLoad = LoadButton.GetComponent<Button>();
		btnLoad.onClick.AddListener(LoadTask);

		Button btnContact = ContactButton.GetComponent<Button>();
		btnContact.onClick.AddListener(ContactTask);

	}

	private void GenerateTask()
	{
		if (SizeInputField.text != empty  &&  ObstaclesInputField.text != empty) {
			int gridSize = Int32.Parse (SizeInputField.text);
			int obstacles = Int32.Parse (ObstaclesInputField.text);
			if (gridSize < mininumSize)
				wrongValueMessage.SetActive (true);
			else {
				wrongValueMessage.SetActive (false);
				controller.GenerateMap (gridSize, obstacles);
			}
		}
	}

	private void DijkstraTask()
	{
		controller.EvaluateDijkstra ();
	}

	private void ShowDijTask()
	{
		controller.DrawDijkstra ();
	}

	private void AStarTask()
	{
		controller.EvaluateAStar ();
	}

	private void ShowAStarTask()
	{
		controller.DrawAStar ();
	}

	private void SaveTask(){
		controller.SaveMap ();
	}

	private void LoadTask()
	{
		controller.LoadMap ();
	}

	private void ContactTask()
	{
		if (Obstacle.contactAllowed) {
			Obstacle.contactAllowed = false;
			ContactText.text = allowContact;
		} else {
			Obstacle.contactAllowed = true;
			ContactText.text = disallowContact;
		}
	}

}