using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateTime : MonoBehaviour {
	Text TimeLabel;

	// Use this for initialization
	void Start () {
		TimeLabel = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		TimeLabel.text = "TimeLeft : "+ ControlCheckpoint.timeLeftWholeNumber.ToString () ;
//		Debug.Log ("Time Update");
	}
}
