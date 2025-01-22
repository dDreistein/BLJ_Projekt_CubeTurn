using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;
using Unity.VisualScripting;
using Input = UnityEngine.Windows.Input;

public class Timer : MonoBehaviour
{
    private bool timerActive;
    private float currentTime;
    
    public static int EndTime;
    
    public GameObject inputField;
    
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
        if (timerActive)
        {
            EndTime = Convert.ToInt32(currentTime * 1000);
            timerActive = false;
            int fifthTime = 0;
        
            LeaderboardCreator.GetLeaderboard("250bc396d450d63496768f9bc1e0e99f6f94e98f8a20e830c5072a1cf1eb790b", ((msg) => 
            {
                if (msg.Length >= 5)
                {
                    fifthTime = msg[4].Score;
                }
                
                if (EndTime < fifthTime || fifthTime == 0)
                {
                    inputField.SetActive(true);
                }
                else
                {
                    inputField.SetActive(false);
                }
            }));
        }
    }
}
