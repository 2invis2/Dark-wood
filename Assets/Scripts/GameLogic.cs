using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameLogic: MonoBehaviour
{
    private static Dictionary<string, bool> itemsToCollect = new Dictionary<string, bool>();
    public static Dictionary<string, bool> GetItemsCollect() { return itemsToCollect; }

    private static bool isExitAvilable = false;

    public AudioClip backMusic;
    private AudioSource audio;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(backMusic);
        TestInit();
        
    }

    //Временная ручная инициализация списка предметов
    public static void TestInit()
    {

        List<string> items = new List<string>();
        items.Add("Keys");
        items.Add("Compass");
        InitItemList(items);

    }

    public static void TryToEscape()
    {
        if (isAllItermsCollect())
        {
            FinishLevel();
        }
    }
    private static bool isAllItermsCollect()
    {
        bool isTrue = true;
        foreach (KeyValuePair<string, bool> item in itemsToCollect)
        {
            if (!item.Value)
            {
                isTrue = false;
            }
        }
        return isTrue;
    }
    public static void InitItemList(List<string> items)
    {
        foreach (string item in items)
        {
            itemsToCollect.Add(item, false);
        }

        Debug.Log("Init Item to Collect Dictionary: Succses");
        Debug.Log(itemsToCollect);
    }

    public static void FinishLevel()
    {
        Debug.Log("finish");
    }


    public static bool CollectItem(string itemName)
    {
        try
        {
            if (!itemsToCollect[itemName])
            {
                itemsToCollect[itemName] = true;
                Debug.Log("list coolect: " + itemName);
            }

            return true;
        }
        catch (KeyNotFoundException)
        {
            Debug.Log("Failed to collect: " + itemName);
            return false;
        }
    }
}
