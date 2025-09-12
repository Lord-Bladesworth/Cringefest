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

        controller.OnMovement += PlayMoveSFX;
        attackBehaviour.OnAttack += PlayAttackSFX;
        gameEntity.OnHurt += PlayHitSFX;
      
    }
    AudioClip nowPlaying { get { return source.clip; } set { source.clip = value; } }
    AudioClip current;
    private void FixedUpdate()
    {
        
       
    }

    void PlayMoveSFX(Vector2 input)
    {
       

    }    

    void PlayAttackSFX()
    {
        //Debug.Log("Attack!");

    }
    void PlayHitSFX()
    {

    }
    AudioClip checkLibrary(audioCueEnum cue)
    {
        for(int i=0; i< audioCues.Length; i++)
        {
            if (audioCues[i].audioCue == cue)
                return audioCues[i].clip;
        }
        Debug.LogError("AUDIO CUE IS MISSING");
        return null;

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


