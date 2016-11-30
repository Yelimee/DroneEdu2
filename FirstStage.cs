using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;
using System;

public class FirstStage : ControlCheckpoint
{

    public Checkpoint[] checkpointList;
    public LookAtTargetController arrow;

    public Checkpoint currentCheckpoint;
    private int checkpointId;


    void Start ()
	{
		base.Start ();
		base.timeLeft = 20;
		if (checkpointList.Length==0) return;

		for (int index = 0; index < checkpointList.Length; index++)
			checkpointList[index].gameObject.SetActive(false);

		checkpointId = 0;
		SetcurrentCheckpoint(checkpointList[checkpointId]);
		ManageScore.scoreIndex = 0;
    }



    private void SetcurrentCheckpoint(Checkpoint checkpoint)
    {
        if (currentCheckpoint != null)
        {
            currentCheckpoint.gameObject.SetActive(false);
			currentCheckpoint.checkpointAction -= ActivateCheckpoint;
            if (checkpointId == 2)
            {
                currentCheckpoint.gameObject.SetActive(true);
            }
            else if (checkpointId == 3)
            {          
                checkpointList[1].gameObject.SetActive(false);
                currentCheckpoint.gameObject.SetActive(false);

				if (ManageScore.score [ManageScore.scoreIndex] >= ManageScore.scoreLimit) {
					base.success ();
                    SingleTon.getInstance.reached1 = 1;
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
			ManageScore.score[ManageScore.scoreIndex] += 30; 
			break;
		default:
			ManageScore.score[ManageScore.scoreIndex] += 35; 
			break;
		}

        checkpointId++;
        SetcurrentCheckpoint(checkpointList[checkpointId]);
    }		
}
