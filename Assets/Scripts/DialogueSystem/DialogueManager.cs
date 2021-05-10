using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text NameText;
    public Text diaglogueText;
    public Animator dialogueAnimator;
    bool isSentenceOver = false;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isSentenceOver)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueAnimator.SetBool("isOpen", true);
        NameText.text = dialogue.name;

        sentences.Clear();

        foreach (var item in dialogue.sentences)
        {
            sentences.Enqueue(item);

        }
        DisplayNextSentence();

    }
    public void DisplayNextSentence() 
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        isSentenceOver = false;
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine("TypeSentence", sentence);
    }
    void EndDialogue()
    {
        AudioManager.instance.PlaySound("okey");
        dialogueAnimator.SetBool("isOpen", false);
    }
    IEnumerator TypeSentence(string sentence)
    {
        diaglogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            diaglogueText.text += letter;
            if (diaglogueText.text.Length == sentence.Length) { isSentenceOver = true; }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
