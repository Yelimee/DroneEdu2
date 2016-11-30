using System;
using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{

	public Action checkpointAction; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter()
    {
        Debug.Log("Activate");
		if (checkpointAction != null)
			checkpointAction();
       // this.gameObject.SetActive(false);
    }
}
