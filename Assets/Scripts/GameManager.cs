using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
  
    TimerManager timerManager;
    // Start is called before the first frame update
    void Start()
    {
       timerManager = GameObject.FindObjectOfType<TimerManager>();
        timerManager.BeginTimer();
        StartCoroutine("Test");
    }

    IEnumerator Test()
    {
        Debug.Log("Yo!");
        yield return null;
    }
    void StartRound()
    {

    }
    void RestartRound()
    {

    }

    void EndRound()
    {

    }
 
}
