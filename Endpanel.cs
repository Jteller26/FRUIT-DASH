using System.Collections.Generic;
using UnityEngine;
/*
 * This class functions to load the children in EndGame Ui
 */

public class Endpanel : MonoBehaviour
{
    //get list of gameobjects in hierarchy
    private List<GameObject> panels;
    private bool paused = false;
    //Finds all children to where the script is located for gameobject
    void Start()
    {
        panels = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            panels.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    //if time scale is 0 it loads endgame method
    void Update()
    {
        if (Time.timeScale == 0)
        {
            EndGame();
        }
    }
    // sets all children to active so its shown and cursor is visable for use
    void EndGame()
    {
        paused = true;
        foreach (GameObject panel in panels)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            panel.SetActive(true);
        }
    }
}
