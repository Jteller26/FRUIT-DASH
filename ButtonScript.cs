using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * This class functions to make a event handler for ui buttons when pressed
 */
public class ButtonScript : MonoBehaviour
{
    //loads scene 1 when button is pressed
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    //exits game when exit button is pressed
    public void ExitGame()
    {
        Application.Quit();
    }
}
