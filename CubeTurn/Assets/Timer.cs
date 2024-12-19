using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private double timer;

    public GameObject cube;
    public bool solved = false;
    public bool started = false;
    
    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        if (started && !solved)
        {
            while (!solved)
            {
                timer += Time.deltaTime;
                
                int minutes = (int)(timer / 60);
                int seconds = (int)(timer % 60);
                int milliseconds = (int)((timer * 1000) % 1000);
                
                timerText.text = $"{minutes:D2}:{seconds:D2}:{milliseconds:D3}";
            }
        }
    }
}
