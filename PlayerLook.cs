/*
 * This class contains the functionality for player rotation from mouse movement.
 */
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //create public float mouse sensitvity for looking around and a range it can be between
    [Range(100, 500)]
    public float mouseSensitivity;
    //tranform the player 
    public Transform player;
    
    //when moving mouse should be loacked when playing game
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //when looking left or right the camera moves
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        
        player.Rotate(Vector3.up * mouseX);
    }
}

