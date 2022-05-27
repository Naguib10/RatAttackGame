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

    public Dialogue dialogue;

    public void StartDialogue(int nameIndex, int textIndex) // nameIndex: 0=Player, 1=NPC,  textIndex: Please check the inspecter on Unity
    {
        nameText.text = dialogue.name[nameIndex];
        dialogueText.text = dialogue.sentences[textIndex];
    }
}
