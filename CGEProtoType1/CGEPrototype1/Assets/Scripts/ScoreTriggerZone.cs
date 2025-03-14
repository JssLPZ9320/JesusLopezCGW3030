using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    public AudioClip scoreSound;
    private AudioSource scoreAudio;
    

    //create a variable to keep track whethere trigger is active 
    bool active = true;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(active && collision.gameObject.tag == "Player")
        {
            //deactivate the trigger zone
            active = false;
            ScoreManager.score++;
            //play coin sound effect
            PlatformerPlayerController platformer = collision.gameObject.GetComponent<PlatformerPlayerController>();

            platformer.PlayCoinSound();

            Destroy(gameObject);
        }
        
    }
    
}
