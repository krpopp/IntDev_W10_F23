using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //SINGLETON this is declaring our INSTANCE
    public static GameManager Instance { get; private set; }

    //lists for meal names and sprites that we collect
    public List<string> mealInventory = new List<string>();
    public List<Sprite> mealSprites = new List<Sprite>();

    //prefab that will display the food we collect
    [SerializeField]
    GameObject mealIcon;

    [SerializeField]
    GameObject canvas;

    //SINGLETON if Instance has not been set and instance is not this, destroy this
    //otherwise, set this script to be the Instance and don't let it destroy itself
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //add the meal name and sprite to our lists
    //add it to the screen and turn off the object in the room
    public void AddInventory(GameObject newItem)
    {
        mealInventory.Add(newItem.name);
        Sprite newSprite = newItem.GetComponentInChildren<SpriteRenderer>().sprite;
        mealSprites.Add(newSprite);
        AddDisplayInventory(newSprite);
        newItem.SetActive(false);
    }

    //create a new item icon and set its position
    private void AddDisplayInventory(Sprite newSprite)
    {
        GameObject newIcon = Instantiate(mealIcon, canvas.transform);
        AdjustIconSize(newIcon.GetComponent<Image>(), newSprite);
        newIcon.GetComponent<RectTransform>().anchoredPosition = AdjustIconPos(newIcon);
    }

    //adjust the size of the icon
    private void AdjustIconSize(Image iconImage, Sprite newSprite)
    {
        iconImage.sprite = newSprite;
        iconImage.SetNativeSize();
        iconImage.rectTransform.localScale = new Vector3(0.2f, 0.2f, 0f);
    }

    //adjust the position of the icon
    private Vector3 AdjustIconPos(GameObject newIcon)
    {
        Vector3 newPos = newIcon.GetComponent<RectTransform>().anchoredPosition;
        newPos.x = newPos.x + (50f * mealSprites.Count);
        return newPos;
    }

}
