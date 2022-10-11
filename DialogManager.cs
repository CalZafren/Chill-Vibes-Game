using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogText;
    public GameObject dialogContainer;
    public bool inDialog;
    private Queue<string> sentences;
    private DialogTrigger currentTrigger;
    private QuestManager questManager;
    private MessageManager messageManager;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        questManager = FindObjectOfType<QuestManager>();
        messageManager = FindObjectOfType<MessageManager>();
    }

    void Update(){
        if(inDialog){
            if(Input.GetButtonDown("Interact")){
                DisplayNextSentence();
            }
        }
    }

    public void StartDialog(Dialog dialog, DialogTrigger trigger){
        //Sets the current trigger equal to the object that just triggered this dialog
        currentTrigger = trigger;
        

        //Lets other things in game know we are in dialog
        inDialog = true;

        //Enables the Dialog Container
        dialogContainer.SetActive(true);

        //Sets the characters name in the UI
        nameText.text = dialog.name;

        //Gets rid of any leftover sentences from last conversation
        sentences.Clear();

        //Loops through dialog object and stores sentences in the queue
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        //Returns if the queue is empty
        if(sentences.Count <= 0){
            EndDialog();
            return;
        }

        //Pops the sentence off the queue and displays it in the UI
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    //Types sentence letter by letter
    IEnumerator TypeSentence(string sentence){
        dialogText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(.02f);
        }
    }

    void EndDialog(){
        inDialog = false;

        //Disables the Dialog Container
        dialogContainer.SetActive(false);

        //Finishes the quest if the item has been collected
        if(questManager.FindQuest(currentTrigger).questItemCollected){
             questManager.FinishQuest(questManager.FindQuest(currentTrigger));
             messageManager.ShowText("You Have Found a Key");
        //Starts the quest if it has not been accepted already
        }else if(questManager.FindQuest(currentTrigger).questInProgress == false){
            questManager.StartQuest(questManager.FindQuest(currentTrigger));
        }
    }
}
