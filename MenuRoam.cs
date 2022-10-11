using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRoam : MonoBehaviour
{

    private float timeLength;
    private Vector3 change;
    private Rigidbody myRB;
    public bool rabbit;
    public bool fox;
    public bool deer;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        ChangeDirection();

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        
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
