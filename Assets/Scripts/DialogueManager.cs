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

    [SerializeField] GameObject dialogueBox;
    [SerializeField] Text nameText;
    [SerializeField] Text dialogueText;
    
    public  bool isDialogueStarted;
    public Dialogue dialogue;

    public void StartDialogue(int nameIndex, int textIndex) // nameIndex: 0=Player, 1=Nieghbor,  textIndex: Please check the inspecter on Unity
    {
        dialogueBox.SetActive(true);

        isDialogueStarted = true;
        
        nameText.text = dialogue.name[nameIndex];
        dialogueText.text = dialogue.sentences[textIndex];

        if (nameIndex == 0) // nameText[nameIndex] : 0="You:", 1="Neighbor:"
        {
            dialogueBox.transform.eulerAngles = new Vector3(0, 0, 0);
            nameText.transform.eulerAngles = new Vector3(0, 0, 0);
            dialogueText.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (nameIndex == 1) // nameText[nameIndex] : 0="You:", 1="Neighbor:"
        {
            dialogueBox.transform.eulerAngles = new Vector3(0, 180, 0);//Rotate Y by 180 degrees to change speech bubble view
            nameText.transform.eulerAngles = new Vector3(0, 360, 0);//Rotate Y by 360 degrees to change nameText view
            dialogueText.transform.eulerAngles = new Vector3(0, 360, 0);//Rotate Y by 360 degrees to change dialogueText view
        }
    }
}
