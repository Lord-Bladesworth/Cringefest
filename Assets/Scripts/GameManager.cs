using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
  
    TimerManager timerManager;
    EnemyManager enemyManager;
    [SerializeField]
    GameObject dedpanel;
    GameEntity player;

    [SerializeField]
    AudioSource bgmSource;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
       timerManager = GameObject.FindObjectOfType<TimerManager>();
       enemyManager = GameObject.FindObjectOfType<EnemyManager>();
        timerManager.BeginTimer();
        player = GameObject.FindWithTag("Player").GetComponent<GameEntity>();
        player.OnDeath += EndRound;

    }
    void StartRound()
    {

    }
    void RestartRound()
    {

    }
    

    public void EndRound(GameObject player)
    {
        enemyManager.ClearStage();
        player.gameObject.SetActive(false);
        dedpanel.SetActive(true);
        timerManager.StopTimer();
    }
 
}
