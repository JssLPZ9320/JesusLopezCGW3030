using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{

    //create a variable to keep track whethere trigger is active 
    bool active = true;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(active && collision.gameObject.tag == "Player")
        {
            //deactivate the trigger zone
            active = false;
            ScoreManager.score++;


            Destroy(gameObject);
        }
        
    }
    
}
