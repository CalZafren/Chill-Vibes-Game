using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public Quest quest1;
    public Quest quest2;
    public Quest quest3;
    public Quest[] questArray;
    public Quest currentQuest;
    private PlayerInventory playerInv;
    

    // Start is called before the first frame update
    void OnEnable()
    {
        questArray = new Quest[] {quest1, quest2, quest3};
        playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    public Quest FindQuest(DialogTrigger trigger){
        foreach (Quest quest in questArray)
        {
            if(trigger.questNum == quest.questNum){
                return quest;
            }
        }

        return null;
    }
    

    public void StartQuest(Quest quest){
        currentQuest = quest;
        quest.questInProgress = true;
        Debug.Log("Starting quest for " + quest.questGoal);
    }
    
    public void FinishQuest(Quest quest){
        quest.questFinished = true;
        //Give a key to the player
        playerInv.keysCollected++;

        Debug.Log("Player has " + playerInv.keysCollected + " keys");
    }
}
