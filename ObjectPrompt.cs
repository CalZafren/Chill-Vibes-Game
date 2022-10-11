using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPrompt : MonoBehaviour
{

    private Transform player;
    private QuestObject questObject;
    private Text promptText;
    private string prompt = "'Space'";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        questObject = transform.parent.GetComponent<QuestObject>();
        promptText = transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

        if(questObject.active && questObject.InRange()){
            promptText.text = prompt;
        }else{
            promptText.text = null;
        }
    }
}
