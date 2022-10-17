using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flare : MonoBehaviour
{

    public SceneTransition sceneTransition;
    private Text promptText;
    private Transform player;
    private Animator anim;
    private bool promptActive = false;
    private string prompt = "'Space'";
    private float range = 2f;
    private bool flareActivated = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        promptText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if(InRange() && !flareActivated){
            ShowPrompt();
        }else{
            HidePrompt();
        }


      if(InRange() && Input.GetButtonDown("Interact")){
        ActivateFlare();
      }
    }

    private void ShowPrompt(){
        promptText.text = prompt;
    }

    private void HidePrompt(){
        promptText.text = null;
    }

    public bool InRange(){
        return Vector3.Distance(player.position, transform.position) < range;
    }

    private void ActivateFlare(){
        HidePrompt();
        flareActivated = true;
        anim.SetTrigger("activate");
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame(){
        yield return new WaitForSeconds(5f);
        sceneTransition.ChangeScene();

    }
}
