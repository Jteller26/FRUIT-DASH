/*
 * This class functions to destory the food when collided with 
 * and return score to the score ui
 */
using UnityEngine;

public class CollectFood : MonoBehaviour
{   //creates delegate for score value 
    public delegate void SampleDel(int i);
    public static SampleDel del;
    
    //When collided with food tag the food destorys and score goes up
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Food")
        {
            // Invoking via FruitManager. Return is score value of picked up item.
            int value = FruitManager.InvokeObserver(other.gameObject);
            
            if (del != null)
            {
                del(value);
            }
            TotalFood.OnTotalText(value);

            Destroy(other.gameObject);
        }

    }

}
