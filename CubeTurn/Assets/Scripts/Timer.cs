using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private bool timerActive;
    private float currentTime;
    
    public static int EndTime;
    
    [SerializeField] private TMP_Text text;
    
    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime += Time.deltaTime;
        }
        
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        
        text.text = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00") + ":" + time.Milliseconds.ToString("000");
    }

    public void StartTimer()
    {
        if (!timerActive)
        { 
            EndTime = 0;
            currentTime = 0;
            timerActive = true;
        }
    }

    public void StopTimer()
    {
        EndTime = Convert.ToInt32(currentTime * 1000);
        timerActive = false;
    }
}
