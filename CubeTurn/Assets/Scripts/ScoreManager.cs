using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public GameObject inputScore;

    [SerializeField] 
    private TMP_InputField inputName;
    
    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, inputScore.GetComponent<Timer>().endTime);
    }
}
