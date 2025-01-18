using System;
using System.Collections.Generic;
using Dan.Main;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey = "250bc396d450d63496768f9bc1e0e99f6f94e98f8a20e830c5072a1cf1eb790b";

    private void Start()
    {
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey,((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                TimeSpan time = TimeSpan.FromMilliseconds(msg[i].Score);
                scores[i].text = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00") + ":" + time.Milliseconds.ToString("000");
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
        {
            if (username.Length > 10)
            {
                username = username.Substring(0, 10);
            }
            GetLeaderboard();
        }));
    }
}
