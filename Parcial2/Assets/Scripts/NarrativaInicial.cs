using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NarrativaInicial : MonoBehaviour
{
    [SerializeField] private float typingTime;
    [SerializeField] private int charsToPlay;
    [SerializeField] private AudioClip npcVoz;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(8, 10)] private string[] dialogueLines;

    private AudioSource AudioSource;
  
    private int lineIndex;

    void Start() {
         AudioSource=GetComponent<AudioSource>();
        AudioSource.clip=npcVoz;
        StartDialogue();
    }
    void Update()
    {
         if(Input.GetButtonDown("Fire1"))
        {
            if(dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
                
            }
        }
    }

    private void StartDialogue()
    {
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            SceneManager.LoadScene("Pueblo");
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        int charIndex=0;

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;

            if (charIndex % charsToPlay==0)
            {
                 AudioSource.Play();
            }

            charIndex++;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    
}
    

