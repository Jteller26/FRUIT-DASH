/*
 * Class that functions as the broker for implementations IFruitObserver interface
 */
using UnityEngine;
using System.Collections.Generic;

public class FruitManager : MonoBehaviour
{
    // Subscriber list
    private static List<IFruitObserver> fruitObservers = new List<IFruitObserver>();

    public static void AddObserver(IFruitObserver o)
    {
        fruitObservers.Add(o);
    }

    public static void RemoveObserver(IFruitObserver o)
    {
        fruitObservers.Remove(o);
    }

    /*
     * Invokes the observer that corresponds with the given GameObject.
     */
    public static int InvokeObserver(GameObject o)
    {
        // Score value
        int value = 0;
        // Fruit type
        Fruit fruit = null;
        
        // Getting fruit type
        fruit = o.GetComponent<Cherry>();
        if (fruit == null)
            fruit = o.GetComponent<Banana>();
        if (fruit == null)
            fruit = o.GetComponent<Watermelon>();
        if (fruit == null)
            return 0;

        // Checking subscriber list for correct fruit
        foreach (var f in fruitObservers)
        {
            if (f.Equals(fruit))
            {
                value = f.Invoke();
                break;
            }
        }

        // Returning score value
        return value;
        }

}
