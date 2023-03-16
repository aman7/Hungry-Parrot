using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int currentPlayerHealth;
    [SerializeField] int score = 0;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] float healthDecreaseTimer = .5f;
    [SerializeField] int healthToDecreaseWithTime = 5;

    int maxPlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text =  score.ToString("0000000000");
        
        maxPlayerHealth = FindObjectOfType<PlayerController>().getPlayerHealth();
        currentPlayerHealth = maxPlayerHealth;
        UpdateHealthBar();
        StartCoroutine(DecreaseHealthWithTime(healthToDecreaseWithTime));
    }

    // Update is called once per frame
    void Update()
    {
        
        //InvokeRepeating("DecreaseHealthWithTime", 5f, 5f);
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString("0000000000");
    }

    public void AddToHealth(int healthToAdd)
    {
        if(currentPlayerHealth == maxPlayerHealth)
        return;

        if(currentPlayerHealth < maxPlayerHealth)
        currentPlayerHealth += healthToAdd;
        
        if(currentPlayerHealth >  maxPlayerHealth)
        currentPlayerHealth = maxPlayerHealth;

        UpdateHealthBar();
    }

    public void SubtractFromHealth(int healthToSubtract)
    {
        if(currentPlayerHealth <= 0)
        return;

        currentPlayerHealth -= healthToSubtract;

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        playerHealthSlider.maxValue = maxPlayerHealth;
        playerHealthSlider.value = currentPlayerHealth;
    }

    IEnumerator DecreaseHealthWithTime(int healthToDecrease)
    {
        while(true)
        {
            yield return new WaitForSeconds(healthDecreaseTimer);
            currentPlayerHealth -= healthToDecrease;
            UpdateHealthBar();
        }
        
    }
}
