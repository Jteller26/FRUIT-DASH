using UnityEngine;
using TMPro;
/*
 * This class functions to use total food action delgate to update total score during the game
 */
public class TotalScore : MonoBehaviour
{
    //create text ui for total score
    public TextMeshProUGUI totalText;
    //int for the total score
    public static int totalScore;

    //if time scale is 0 the text becomes white color
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    private void OnEnable()
    {
        TotalFood.OnTotalText += TotalScores;
    }
    private void OnDisable()
    {
        TotalFood.OnTotalText -= TotalScores;
    }

    //when food is collected the total score goes up
    private void TotalScores(int value)
    {
        totalScore += value;
        totalText.text = totalScore.ToString();
    }
}
