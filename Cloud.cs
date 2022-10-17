using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    private Transform startingPos;
    public float speed;
    private Rigidbody myRb;
    private float speedMultiplier = 50f;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        startingPos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        myRb.velocity = new Vector3(speed * speedMultiplier * Time.deltaTime * -1, 0, 0);
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("Working");
        transform.position = new Vector3(150, transform.position.y, transform.position.z);
    }
}
