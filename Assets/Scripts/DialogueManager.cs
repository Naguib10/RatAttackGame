using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    public static DialogueManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialogueManager found!");
            return;
        }

        instance = this;
    }
    #endregion

    [SerializeField] Text nameText;
    [SerializeField] Text dialogueText;

    //private Queue<string> sentences;

    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        //sentences = new Queue<string>();
    }

    public void StartDialogue(int nameIndex, int textIndex) // name: 0=Player, 1=NPC,  text: Please check the inspecter on Unity
    {
        nameText.text = dialogue.name[nameIndex];
        dialogueText.text = dialogue.sentences[textIndex];
    }

}
