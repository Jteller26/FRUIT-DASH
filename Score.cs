using UnityEngine;
using TMPro;

/*
 * This class functions to update score text 
 * and calls from colled food and bomb destroy
 */
public class Score : MonoBehaviour
{
    //create a int for score
    public static int score;
    //create ui text for the score
    private TextMeshProUGUI scoreText;

    //get component of ui text
    //call collect food delgate to update the score
    //makes bomb destory event
    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        CollectFood.del += UpdateScore;
        BombDestroy.sampleEvent += SetScoreToZero;
    }

    //score goes up when food is collected
    private void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
    //set score to zero when bomb hits you
    private void SetScoreToZero()
    {
        scoreText.text = (score = 0).ToString();
    }

}
