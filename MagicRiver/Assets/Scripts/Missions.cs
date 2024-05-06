using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Mission
{
	public string header;
	public string description;
}

public class Missions : MonoBehaviour 
{
	[Header("MessengerSetup")]
	public Transform MessengerRoot;
	public Text value;
    [Space(10)]
	public Text completedMissions;
	public Text header;
	public Text description;
	public Slider progress;

	public List<Mission> missions;
	public int currentMission;

	//STATS
    int scoreInOneGame; // 0
	int totalScore; // 1
	int jemsInOneGame; // 2
	int jems; // 3
	int playerGames; // 4
	int unlockedCharacters; // 5


	void Start()
	{
		totalScore = SPlayerPrefs.GetInt("TotalScore");

//		UpdateStats();
		UpdateValue();
	}

	public void UpdateStats(int siog/*, int ts, int jiog, int j, int pg*/)
	{
		currentMission = SPlayerPrefs.GetInt("CurrentMission");
		scoreInOneGame = siog;
		if(currentMission == 5 || currentMission == 6)
		{
	    	totalScore += siog;
			SPlayerPrefs.SetInt("TotalScore",totalScore);
		}
		//jemsInOneGame = jiog;
		//jems = j;
		//playerGames = pg;
		//unlockedCharacters = PlayerPrefs.GetInt("unlockedCharacters");
		UpdateValue();
	}

	void UpdateValue()
	{
		if(currentMission == 0)
		{
			if(scoreInOneGame >= 10)
			{
				CompletedMissionFeedback(1);
				SPlayerPrefs.SetInt("CurrentMission",currentMission + 1);
			}
		}
		if(currentMission == 1)
		{
			if(scoreInOneGame >= 30)
			{
				CompletedMissionFeedback(2);
				SPlayerPrefs.SetInt("CurrentMission",currentMission + 1);
			}
		}
		if(currentMission == 2)
		{
			progress.minValue = 0;
			progress.maxValue = 5;
			progress.value = SPlayerPrefs.GetInt("PlayedGames");
			if(SPlayerPrefs.GetInt("PlayedGames") >= 5)
			{
				progress.value = 0;
				CompletedMissionFeedback(3);
				SPlayerPrefs.SetInt("CurrentMission",currentMission + 1);

				Social.ReportProgress("CgkIzI3W4a0TEAIQBA", 100.0f, (bool success) => {
					// handle success or failure
				});
			}
		}
		if(currentMission == 3)
		{
			if(scoreInOneGame >= 100)
			{
				CompletedMissionFeedback(4);
				SPlayerPrefs.SetInt("CurrentMission",currentMission + 1);
			}
		}
		if(currentMission == 4)
		{
			if(jems >= 50)
			{
				CompletedMissionFeedback(5);
				SPlayerPrefs.SetInt("CurrentMission",currentMission + 1);
			}
		}
		if(currentMission == 5)
		{
			if(totalScore >= 500)
			{
				CompletedMissionFeedback(6);
				SPlayerPrefs.SetInt("TotalScore",0);
				SPlayerPrefs.SetInt("CurrentMission",currentMission + 1);
			}
		}
		if(currentMission == 6)
		{
			if(totalScore >= 2500)
			{
				CompletedMissionFeedback(7);
				SPlayerPrefs.SetInt("TotalScore",0);
				SPlayerPrefs.SetInt("CurrentMission",currentMission + 1);

				Social.ReportProgress("CgkIzI3W4a0TEAIQBQ", 100.0f, (bool success) => {
					// handle success or failure
				});
			}
		}
		if(currentMission == 7)
		{
			if(SPlayerPrefs.GetInt("gdfhkqiitizn@5i8gdf8sjHHBBMASklkfsh") - UIManager.startJems >= 5)
			{
				CompletedMissionFeedback(8);
				SPlayerPrefs.SetInt("CurrentMission",currentMission + 1);
			}
		}
		if(currentMission == 8)
		{
			if(SPlayerPrefs.GetInt("gdfhkqiitizn@5i8gdf8sjHHBBMASklkfsh") - UIManager.startJems >= 25)
			{
				CompletedMissionFeedback(9);
				SPlayerPrefs.SetInt("CurrentMission",currentMission + 1);
			}
		}
		if(currentMission == 9)
		{
			if(SPlayerPrefs.GetInt("AllCharUnlock") == 1)
			{
				CompletedMissionFeedback(10);
				SPlayerPrefs.SetInt("AllMissionsUnlocked",1);

				Social.ReportProgress("CgkIzI3W4a0TEAIQBg", 100.0f, (bool success) => {
					// handle success or failure
				});

			}
		}



		completedMissions.text = SPlayerPrefs.GetInt("CurrentMission").ToString() + "/10";
		header.text = missions[SPlayerPrefs.GetInt("CurrentMission")].header;
		description.text = missions[SPlayerPrefs.GetInt("CurrentMission")].description;
	}

	void CompletedMissionFeedback(int id)
	{
		value.text = "MISSION " + id.ToString() + " COMPLETED";
		MessengerRoot.SendMessage("Activate");
	}
}
