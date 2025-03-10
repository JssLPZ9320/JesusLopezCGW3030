using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//need this for tmp text
using TMPro;
using System.Security.Cryptography.X509Certificates;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text textbox;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueBtn;
    public GameObject dialogPanel;


    void OnEnable()
    {
        continueBtn.SetActive(false);
        StartCoroutine(Type());

    }

    //Coroutine for our typewritter effect
    IEnumerator Type()
    {
        //set initial text for textbox to empty string
        textbox.text = "";
        foreach (char letter in sentences[index])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueBtn.SetActive(true);
    }

    public void NextSentence()
    {
        continueBtn.SetActive(false);

        if(index < sentences.Length - 1 )
        {
            index++;
            textbox.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textbox.text = "";
            dialogPanel.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
