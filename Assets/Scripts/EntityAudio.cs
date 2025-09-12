using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAudio : MonoBehaviour
{
    GameEntity gameEntity;
    Controller controller;
    AttackBehaviour attackBehaviour;

    AudioSource source;

    [SerializeField]
    AudioCues[] audioCues;

    private void Awake()
    {
        gameEntity = GetComponent<GameEntity>();
        controller = gameEntity.GetComponent<Controller>();
        attackBehaviour = gameEntity.GetComponent<AttackBehaviour>();

        controller.OnMovement += playMoveSFX;
      
    }

    private void FixedUpdate()
    {
        //handle "now playing"
        //check what audio is currently playing.
        //if a new audio is needed, then play the new audio

    }

    void playMoveSFX(Vector2 input)
    {


    }    

}
public enum audioCueEnum 
{
    Hit, Attack, Walk, Death
}

[System.Serializable]
public class AudioCues
{
    public AudioClip clip;
    public audioCueEnum audioCue;
}


