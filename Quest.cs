using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public int questNum;
    public GameObject questGiver;
    public GameObject questGoal;
    public bool questInProgress;
    public bool questItemCollected;
    public bool questFinished;
}
