using UnityEngine;
using System.Collections;

public class QuitAll : MonoBehaviour {

    void Start()
    {
        StartCoroutine(sDelayTime(3.0f));
    }

    IEnumerator sDelayTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Application.Quit();
    }
}