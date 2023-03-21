using System.Collections;
using UnityEngine;
using TMPro;
/*
 * This class functions to make score green when a food is collected
 */

public class TextColor : MonoBehaviour
{
    //when collected food is called it chnages color
    private void Start()
    {
        CollectFood.del += ChangeColor;
    }

    //creates the green color on text when score goes up
    private void ChangeColor(int value)
    {
        if(value > 0)
            StartCoroutine(UpdateColor());
    }
    IEnumerator UpdateColor()
    {
        GetComponent<TextMeshProUGUI>().color = Color.green;
        yield return new WaitForSeconds(.25f);
        GetComponent<TextMeshProUGUI>().color = Color.white;
    }
}
