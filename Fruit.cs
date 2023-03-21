/*
 * This abstract class represents a single piece of fruit the player can pick up.
 * The reason for implementing this is to demonstrate contravariace.
 */
using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    // Value of the item if picked up by player
    protected int value;
}
