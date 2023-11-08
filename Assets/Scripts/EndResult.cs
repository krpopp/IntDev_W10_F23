using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndResult : MonoBehaviour
{
    [SerializeField]
    TMP_Text mealText;

    List<string> mealNames = new List<string>();

    private void Start()
    {
        MealDisplay();
    }

    //iterate through our names of meals
    //add them to the end screen text
    private void MealDisplay()
    {
        mealText.text = "";
        for (int i = 0; i < GameManager.Instance.mealInventory.Count; i++)
        {
            mealNames.Add(GameManager.Instance.mealInventory[i]);
            if (i == 0)
            {
                mealText.text = mealNames[i];
            }
            else
            {
                mealText.text = mealText.text + ", " + mealNames[i];
            }
        }
    }
}
