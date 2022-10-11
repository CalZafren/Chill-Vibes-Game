using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalPrompt : MonoBehaviour
{

    private Transform player;
    private AnimalManager animalManager;
    private DialogManager dialogManager;
    private DialogTrigger dialogTrigger;
    private Text text;
    private string prompt = "'Space'";
    private string originalText;

    // Start is called before the first frame update
    void Start()
    {
        FindComponents();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

        if(animalManager.pauseRoam && dialogManager.inDialog == false && (dialogTrigger.myQuest.questInProgress == false || dialogTrigger.myQuest.questItemCollected == true) && dialogTrigger.myQuest.questFinished == false){
            text.text = prompt;
        }else{
            text.text = null;
        }
    }

    void FindComponents(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animalManager = transform.parent.GetComponent<AnimalManager>();
        dialogManager = FindObjectOfType<DialogManager>();
        dialogTrigger = transform.parent.GetComponent<DialogTrigger>();
        text = transform.GetChild(0).GetComponent<Text>();
        originalText = text.text;
    }
}
