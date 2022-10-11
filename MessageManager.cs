using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{

    public Text messageText;

    // Start is called before the first frame update
    void Start()
    {
        ShowText("Find the Flare");
    }

    public void ShowText(string text){
        messageText.gameObject.SetActive(true);
        messageText.text = text;
        StartCoroutine(HideText());

    }

    private IEnumerator HideText(){
        yield return new WaitForSeconds(3f);
        messageText.gameObject.SetActive(false);        
    }
}
