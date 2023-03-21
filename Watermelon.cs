/*
 * This class represents a watermelon that can be picked up for points.
 */

public class Watermelon : Fruit, IFruitObserver
{
    private void Awake()
    {
        // Setting the value of picking up this item
        value = 3;
    }

    void OnEnable()
    {
        // Subscribing to FruitManager
        FruitManager.AddObserver(this);
    }

    private void OnDisable()
    {
        // Unsubscribing to FruitManager
        FruitManager.RemoveObserver(this);
    }

    /*
     * Sends request to the Audio Manager to play related sound effect.
     * Returns the value of picking up this item.
     */
    public int Invoke()
    {
        AudioManager.Play(this);
        return value;
    }
}