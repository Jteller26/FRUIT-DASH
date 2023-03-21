using UnityEngine;
using TMPro;
/*
 * This class functions to update ui text to turn white when time scale is 0
 */

public class EndGame : MonoBehaviour
{
    TextMeshProUGUI Text;
    //Gets the ui text component
    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    // when time scale is o the text color turns white
    void Update()
    {
        if (Time.timeScale == 0)
        {
            GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
}
