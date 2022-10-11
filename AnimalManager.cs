using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{

    private GameObject player;
    public float range = 5f;
    public bool pauseRoam = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MakeChecks();
    }

    void MakeChecks(){
        if(Vector3.Distance(transform.position, player.transform.position) <= range){
            pauseRoam = true;
        }else{
            pauseRoam = false;
        }
    }
}
