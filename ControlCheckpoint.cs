using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;
using System;

public class ControlCheckpoint : MonoBehaviour {

	public GameObject SuccessPanel; // soryung: for success panel presentation
	public GameObject FailPanel; // soryung: for fail panel presentation
	public GameObject joystick;
	public GameObject joystick2;
	public GameObject ExitButton;
	public ControlHelicopter heli;

	public float timeLeft = 0;
	public static int timeLeftWholeNumber;
	private string[] sceneName = { "stage1", "stage2", "stage3", "stage4", "stage5", "stage6", "stage7", "certification" }; 
	private int numOfStage;

	public void Start () {

		numOfStage = 0;
	
		for (int i = 0; i < 8; i++) { 
			if (sceneName [i] == SceneManager.GetActiveScene ().name)
				numOfStage = i;
		}
	}

	public void StartCoroutine(Func<IEnumerator> delayTime)
	{
		throw new NotImplementedException();
	}

	public IEnumerator sDelayTime(float waitTime)
	{
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene(sceneName[numOfStage+1]);
	}

	public IEnumerator fDelayTime(float waitTime)
	{
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene(sceneName[numOfStage]);
	}

	public void success()
	{
		SuccessPanel.SetActive (true);

		joystick.SetActive (false);
		joystick2.SetActive (false);
		ExitButton.SetActive (false);

		StartCoroutine(sDelayTime(3.0f));
	}

	public void fail()
	{
		FailPanel.SetActive (true);

		joystick.SetActive (false);
		joystick2.SetActive (false);
		ExitButton.SetActive (false);

		StartCoroutine(fDelayTime(3.0f));
	}

	public void decreaseTimeLeft() {
		timeLeft--;
	}

	public void Update () {
		timeLeft -= Time.deltaTime;
		timeLeftWholeNumber = (int)timeLeft;
		if (timeLeft <= 0) fail ();
	}
}
