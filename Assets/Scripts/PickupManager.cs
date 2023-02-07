using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] int pointsForFoodPickup = 20;
    [SerializeField] int healthForFoodPickup = 10;
    [SerializeField] int pickupHealth;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
        {
            FindObjectOfType<GameSession>().AddToScore(pointsForFoodPickup);
            FindObjectOfType<GameSession>().AddToHealth(pickupHealth);
            Destroy(gameObject);
        }
        
    }
    
}
