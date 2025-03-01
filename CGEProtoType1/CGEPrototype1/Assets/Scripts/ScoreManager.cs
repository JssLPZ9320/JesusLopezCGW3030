using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    /*public static variables notice publick static variables can be accessed from any script but cannot be seen in the inspector*/

    public static bool gameOver;
    public static bool won;
    public static int score;
    public TMP_Text textbox;

    public int scoreToWin;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            textbox.text = "Score: " + score;
        }

        if(score>= scoreToWin)
        {
            won = true;
            gameOver = true;
        }

        if(gameOver)
        {
            if(won)
            {
                textbox.text = "You win! \nPress R to Try Again!";
            }
            else
            {
                textbox.text = "You Lose! \nPress R to Try Again!";
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                //reload currect scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            }
        }


    }
}
