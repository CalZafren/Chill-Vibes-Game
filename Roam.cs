using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roam : MonoBehaviour
{
    private float timeLength;
    private Vector3 change;
    private Rigidbody myRB;
    private AnimalManager animalManager;
    public bool rabbit;
    public bool fox;
    public bool deer;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        animalManager = GetComponent<AnimalManager>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        //Only moves if player is not within range
        if(animalManager.pauseRoam == false){
            Move();
        }else{
            myRB.velocity = Vector3.zero;
        }

        if(deer){
            transform.forward = change * -1;
        }else{
            transform.forward = change;
        }    
    }

    void Move(){
        timeLength -= Time.deltaTime;
        if(timeLength <= 0){
            ChangeDirection();
        }

        //Set the velocity
        myRB.velocity = change;
    }

    void ChangeDirection(){
        timeLength = RandomNum(5, 15);
        change = new Vector3(RandomNum(-2,2), myRB.velocity.y, RandomNum(-2,2));
    }

    private float RandomNum(float min, float max){
        return Random.Range(min, max);
    }
}
