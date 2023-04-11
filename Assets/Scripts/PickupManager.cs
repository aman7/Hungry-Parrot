using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupManager : MonoBehaviour
{
    [SerializeField] int pointsForFoodPickup = 100;
    //[SerializeField] int healthForFoodPickup = 10;

    [SerializeField] int pickupHealth = 5;
    [SerializeField] int poisonChance = 7;
    [SerializeField] GameObject impactEffect;
    //[SerializeField] TMP_Text eventText;
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
        {
            FindObjectOfType<GameSession>().AddToScore(pointsForFoodPickup);
            if(isPoisoned())
            {
                FindObjectOfType<GameSession>().SubtractFromHealth(pickupHealth);
                FindObjectOfType<ShowUI>().showPoisonText();
                FindObjectOfType<ShowUI>().hidePoisonText();
                
            }
            else
            {
                FindObjectOfType<GameSession>().AddToHealth(pickupHealth);
            }

            FindObjectOfType<PlayerController>().PlaySoundEffect();
            if(impactEffect !=null)
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
        
    }

    private bool isPoisoned()
    {
        int randomPoisonChance = Random.Range(0, poisonChance);
        if(randomPoisonChance > 4)
            return true;
        
        return false;
    }

    
    
}
