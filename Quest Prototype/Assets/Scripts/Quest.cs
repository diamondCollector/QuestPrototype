using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Quest
{
    public string name;
    public string description;
    public string reward;
    public bool isStarted;
    public bool isUpdated;
    public bool isFinished;
    public string status;

    public void onStart()
    {
        Debug.Log("Quest: " + name + " has started. \n Description: " + description + " \n Reward: " + reward);
        isStarted = true;
        status = "Started";
    }

    public void onUpdated()
    {
        Debug.Log("Quest: " + name + " has been updated");
        isUpdated = true;
        status = "Updated";
    }

    public void OnFinished()
    {
        Debug.Log("Quest: " + name + " has been completed. \n You receive: " + reward);
        isFinished = true;
        status = "Finished";
    }  
}
