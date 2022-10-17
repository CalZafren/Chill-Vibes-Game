using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpositionManager : MonoBehaviour
{

    public Exposition exposition;
    private Queue<string> sentences;
    public Text text1;
    public Text text2;
    public Text text3;
    private Text currentText;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        //Loops through exposition object and stores sentences in the queue
        foreach (string sentence in exposition.sentences)
        {
            sentences.Enqueue(sentence);
        }

        
        DisplayNextSentence();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact")){
                DisplayNextSentence();
        }
    }

    public void DisplayNextSentence(){
        //sets the current text object
        if(currentText == text1){
            currentText = text2;
        }else if(currentText == text2){
            currentText = text3;
        }else{
            currentText = text1;
        }

        //Returns if the queue is empty
        if(sentences.Count <= 0){
            gameObject.GetComponent<SceneTransition>().ChangeScene();
            return;
        }

        //Pops the sentence off the queue and displays it in the UI
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Types sentence letter by letter
    IEnumerator TypeSentence(string sentence){
        currentText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            currentText.text += letter;
            yield return new WaitForSeconds(.02f);
        }
    }
}
