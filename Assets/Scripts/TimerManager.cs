using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    float _timeElapsed = 0;
    public float getTimeElapsed { get { return _timeElapsed; } }
    bool isTimerRunning;
    public Action<float> OnTimerTick;


    IEnumerator stiff;
   public void BeginTimer()
    {
        isTimerRunning = true;
        StartCoroutine("TickforSeconds");
    }
    void ResetTimer()
    {
        _timeElapsed = 0;
    }
    // Update is called once per frame
 
    private void LateUpdate()
    {
        
    }
   IEnumerator TickforSeconds()
    {
        Debug.Log("Ticking starts");
        while(isTimerRunning)
        {
            yield return new WaitForSeconds(1);
            _timeElapsed++;

            if(OnTimerTick!= null)
            OnTimerTick(_timeElapsed);
        }
        yield return null;
    }

    
}
