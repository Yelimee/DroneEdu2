using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class SeventhStage : ControlCheckpoint
{
	public Checkpoint[] checkpointList;
	public LookAtTargetController arrow;

	public Checkpoint currentCheckpoint;
	private int checkpointId;

	void Start()
	{
		base.Start ();
		base.timeLeft = 150;
		if (checkpointList.Length == 0) return;

		for (int index = 0; index < checkpointList.Length; index++)
			checkpointList[index].gameObject.SetActive(false);

		checkpointId = 0;
		SetcurrentCheckpoint(checkpointList[checkpointId]);
		ManageScore.scoreIndex = 6; // soryung: for setting index of score array
	}



	private void SetcurrentCheckpoint(Checkpoint checkpoint)
	{
		if (currentCheckpoint != null)
		{
			currentCheckpoint.gameObject.SetActive(false);
			currentCheckpoint.checkpointAction -= ActivateCheckpoint;

			if (checkpointId == 2) {
				currentCheckpoint.gameObject.SetActive (false);

				if (ManageScore.score [ManageScore.scoreIndex] >= ManageScore.scoreLimit) {
					base.success ();
				} 
				else {
					base.fail ();
				}
				return;
			}
		}

		currentCheckpoint = checkpoint;
		currentCheckpoint.checkpointAction += ActivateCheckpoint;
		arrow.Target = currentCheckpoint.transform;
		currentCheckpoint.gameObject.SetActive(true);

	}

	private void ActivateCheckpoint()
	{
		switch (checkpointId)
		{
		case 0:
		case 1:
			ManageScore.score[ManageScore.scoreIndex] += 50; 
			break;
		}

		checkpointId++;
		SetcurrentCheckpoint(checkpointList[checkpointId]);
	}		
}
