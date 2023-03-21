/*
 * This class functions to use delegate function to calculate the score missed when game is played
 */
using UnityEngine;
using System;
using TMPro;

public class MissedScore : MonoBehaviour
{
    //create func for 2 ints and one int result
    event Func<int, int, int> Event;
    //create ui text for the func result
    TextMeshProUGUI missedText;
    //create int for score
    int missed;
    
    //get component of ui text
    //makes event add when will happen
    void Start()
    {
        missedText = GetComponent<TextMeshProUGUI>();
        Event += Subtract;
    }

    
    void Update()
    {
        // If points were lost, total score will not equal score
        if (TotalScore.totalScore != Score.score)
        {
            Event(TotalScore.totalScore, Score.score);
        }
        // make text color white when time scale is 0
        if(Time.timeScale == 0)
        {
            GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    //return the totalscore - score to get the missed score and make it a string for ui
    int Subtract(int totalScore, int score)
    {
        missed = (totalScore - score);
        missedText.SetText(missed.ToString());
        return missed;

    }
    
}
