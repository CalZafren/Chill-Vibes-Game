using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{

    private QuestManager questManager;
    private Quest myQuest;
    private Transform player;
    [HideInInspector]
    public bool active = false;
    private float range = 5f;
    private bool promptActive = false;

    // Start is called before the first frame update
    void Start()
    {
        FindComponents();
    }

    // Update is called once per frame
    void Update()
    {
        if(myQuest!= null && myQuest.questInProgress){
            active = true;
        }

        if(active && InRange()){
            ShowPrompt();
        }else if(promptActive){
            HidePrompt();
        }

        if(active && InRange() && Input.GetButtonDown("Interact")){
            CollectObject();
        }

    
    }

    void FindComponents(){
        questManager = FindObjectOfType<QuestManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Should loop through quests to find which quest it is connected to, but it is not running
        foreach (Quest quest in questManager.questArray)
        {
            if(GameObject.ReferenceEquals(transform.gameObject, quest.questGoal)){
                myQuest = quest;
            }
        }
    }

    void ShowPrompt(){
        Debug.Log("Showing Prompt for " + transform.gameObject);
        promptActive = true;
    }

    void HidePrompt(){
        Debug.Log("Hiding Prompt for " + transform.gameObject);
        promptActive = false;
    }

    public bool InRange(){
        return Vector3.Distance(player.position, transform.position) < range;
    }

    void CollectObject(){
        myQuest.questItemCollected = true;
        Destroy(gameObject);
    }
}
