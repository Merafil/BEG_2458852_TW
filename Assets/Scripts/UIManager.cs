using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject activeTowers;
    [SerializeField] private GameObject activeBullets;


    [SerializeField] TextMeshProUGUI tmpGameTime;
    [SerializeField] TextMeshProUGUI tmpTowers;
    [SerializeField] TextMeshProUGUI tmpBullets;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        CalculateGameTime();

        var amount = GetAmountObjects(activeTowers);
        tmpTowers.text = amount.ToString();
        amount = GetAmountObjects(activeBullets);
        tmpBullets.text = amount.ToString();
    }

    private int GetAmountObjects(GameObject obj)
    {
        int count = 0;
        for (int i= 0; i< obj.transform.childCount; i++)
        {
            count++;
        }
        return count;
    }

    private void CalculateGameTime()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        if(Mathf.Round(t % 60) < 10)
        {
            seconds = "0" + seconds;
        }
        tmpGameTime.text = minutes + " : " + seconds;
    }


}
