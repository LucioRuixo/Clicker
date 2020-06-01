using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	int currentGoal;
	List<int> goldGoals;

	public List<GameObject> inactiveButtons;

	UIManager uIManager;

    void Start()
    {
		currentGoal = 0;
		goldGoals = new List<int>{ 10, 50, 100, 200 };

		uIManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
		foreach (GameObject button in inactiveButtons)
			button.SetActive(false);

		Debug.Log(inactiveButtons.Count);
	}

	public void IncreaseScore(int scoreIncrement)
	{
		GameManager.gold += scoreIncrement;

		if (GameManager.gold >= goldGoals[currentGoal] && currentGoal < goldGoals.Count)
        {
			inactiveButtons[currentGoal].SetActive(true);

			currentGoal++;
        }

		uIManager.IncreaseScore(scoreIncrement);
	}
}