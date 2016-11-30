using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;

public class FourthStage : ControlCheckpoint
{
    public Checkpoint[] checkpointList;
    public LookAtTargetController arrow;

    public Checkpoint currentCheckpoint;
    private int checkpointId;

	void Start ()
	{
		base.Start ();
		base.timeLeft = 200;
        if (checkpointList.Length==0) return;

	    for (int index = 0; index < checkpointList.Length; index++)
            checkpointList[index].gameObject.SetActive(false);

	    checkpointId = 0;
        SetcurrentCheckpoint(checkpointList[checkpointId]);
		ManageScore.scoreIndex = 3; // soryung: for setting index of score array
	}
		
    private void SetcurrentCheckpoint(Checkpoint checkpoint)
    {
        if (currentCheckpoint != null)
        {
            currentCheckpoint.gameObject.SetActive(false);
			currentCheckpoint.checkpointAction -= ActivateCheckpoint;
            if (checkpointId == 7) {
				currentCheckpoint.gameObject.SetActive (true);
			}
            else if (checkpointId == 8) {				
				checkpointList [6].gameObject.SetActive (false);
				currentCheckpoint.gameObject.SetActive (false);
            }
            else if (checkpointId == 12)
            {
				if (ManageScore.score [ManageScore.scoreIndex] >= ManageScore.scoreLimit) {
					base.success ();
					SingleTon.getInstance.reached4 = 4;
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
		switch (checkpointId) {
		case 0:
		case 12: 
			ManageScore.score [ManageScore.scoreIndex] += 5; // soryung: straight up and down score
			break;
		case 6:
			ManageScore.score [ManageScore.scoreIndex] += 20; // soryung: roll(flip) score
			break;
		default:
			ManageScore.score [ManageScore.scoreIndex] += 7; // soryung: others' score
			break;	
		}

        checkpointId++;
        SetcurrentCheckpoint(checkpointList[checkpointId]);
    }
}
