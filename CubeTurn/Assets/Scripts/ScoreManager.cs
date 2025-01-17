using System;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField inputName;
    
    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        Debug.Log(inputName.text);
        Debug.Log(Timer.EndTime);
        submitScoreEvent.Invoke(inputName.text, Timer.EndTime);
    }
}
