using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowUI : MonoBehaviour
{

    [SerializeField] TMP_Text eventText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showPoisonText()
    {
        eventText.gameObject.SetActive(true);
    }

    public void hidePoisonText()
    {
        StartCoroutine(hidePoisonedTextCoroutine());
    }
    IEnumerator hidePoisonedTextCoroutine()
    {
        yield return new WaitForSeconds(1);
        eventText.gameObject.SetActive(false);
    }
}
