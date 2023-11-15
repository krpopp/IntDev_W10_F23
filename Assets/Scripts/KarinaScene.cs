using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarinaScene : MonoBehaviour
{

    //prefab that will display the food we collect
    [SerializeField]
    GameObject mealIcon;

    [SerializeField]
    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.mealIcon = mealIcon;
        GameManager.Instance.canvas = canvas;
    }

}
