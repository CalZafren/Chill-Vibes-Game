using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedGateText : MonoBehaviour
{
    private LockedGate parentGate;
    private PlayerInventory playerInv;
    private string prompt = "Press 'Space' to Open";
    private Text text;

    void Start(){
        parentGate = transform.parent.parent.GetComponent<LockedGate>();
        playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(parentGate.CanOpen()){
            ChangeText();
        }   

        if(parentGate.opened){
            DestroyText();
        }
    }

    void ChangeText(){
        text.text = prompt;
    }

    void DestroyText(){
        text.text = null;
    }
}
