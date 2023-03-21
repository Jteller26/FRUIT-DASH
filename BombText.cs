using System.Collections;
using UnityEngine;
using TMPro;
/*
 * This class functions to create evnt where score text turns red for a second when bomb hit player
 */
public class BombText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BombDestroy.sampleEvent += ChangeColor2;
    }

    //when bomb hits player the score becomes red for .25 seconds then back to white
    public void ChangeColor2()
    {
        StartCoroutine(UpdateColor2());
    }
    IEnumerator UpdateColor2()
    {
        GetComponent<TextMeshProUGUI>().color = Color.red;
        yield return new WaitForSeconds(.25f);
        GetComponent<TextMeshProUGUI>().color = Color.white;
    }
}
