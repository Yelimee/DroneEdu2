using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {
	Text ScoreLabel;
	// Use this for initialization
	void Start () {
		ScoreLabel = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		ScoreLabel.text = "Score : "+ ManageScore.score[ManageScore.scoreIndex].ToString () ;
		Debug.Log ("Score Update");
	}
}
