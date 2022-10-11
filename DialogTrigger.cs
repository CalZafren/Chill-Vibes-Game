using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public int questNum;
    private Text animalText;
    private AnimalManager animalManager;
    public Dialog initialDialog;
    public Dialog endDialog;
    private DialogManager dialogManager;
    private QuestManager questManager;
    public Quest myQuest;
    

    // Start is called before the first frame update
    void Start()
    {
        FindComponents();
    }

    // Update is called once per frame
    void Update()
    {
        //Only calls if within range of animal and the interact button is pressed while not in dialog and not already talked to
        if(animalManager.pauseRoam && Input.GetButtonDown("Interact") && !dialogManager.inDialog){
            TriggerDialog();
        }
    }

    void FindComponents(){
        animalText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        animalManager = GetComponent<AnimalManager>();
        dialogManager = FindObjectOfType<DialogManager>();
        questManager = FindObjectOfType<QuestManager>();
        myQuest = questManager.FindQuest(this);
    }

    public void TriggerDialog(){
        if(!myQuest.questInProgress && !myQuest.questFinished){
            dialogManager.StartDialog(initialDialog, this);
        }else if(myQuest.questItemCollected && !myQuest.questFinished){
            dialogManager.StartDialog(endDialog, this);
        }
    }
}
