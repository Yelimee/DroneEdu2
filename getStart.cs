﻿using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;

public class getStart : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("selectStage");
    }
}
