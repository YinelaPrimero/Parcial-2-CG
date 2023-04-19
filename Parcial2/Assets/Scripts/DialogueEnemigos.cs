using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueEnemigos : MonoBehaviour
{
    [SerializeField] private float typingTime;
    [SerializeField] private int charsToPlay;


    [SerializeField] private AudioClip npcVoz;
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    

   

    private AudioSource AudioSource;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;


   private void Start(){
        AudioSource=GetComponent<AudioSource>();
        AudioSource.clip=npcVoz;
        
   }


    void Update()
    {
        if(isPlayerInRange && !didDialogueStart){
            StartDialogue();
        }

        if(isPlayerInRange && Input.GetButtonDown("Fire1") &&didDialogueStart)
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
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
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
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
// Aca se haria la activacion de ataque

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }

}