using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedGate : MonoBehaviour
{

    private GameObject player;
    private PlayerInventory playerInv;
    public float range;
    private Animator anim;
    [HideInInspector]
    public bool opened = false;
    private bool canOpen = false;
    public bool firstGate;
    public bool secondGate;
    public bool thirdGate;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && InRange() && CanOpen()){
            OpenGate();
        }
    }

    bool InRange(){
        if(Vector3.Distance(transform.position, player.transform.position) < range){
            return true;
        }else{
            return false;
        }
    }

    public bool CanOpen(){
        if(firstGate){
            if(playerInv.keysCollected >= 1){
                return true;
            }else{
                return false;
            }
        }else if(secondGate){
            if(playerInv.keysCollected >= 2){
                return true;
            }else{
                return false;
            }
        }else if(thirdGate){
            if(playerInv.keysCollected >= 3){
                return true;
            }else{
                return false;
            }
        }else{
            return false;
        }
    }

    void OpenGate(){
        anim.SetTrigger("Open");
        opened = true;
    }


}
