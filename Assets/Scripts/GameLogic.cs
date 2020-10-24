using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameLogic: MonoBehaviour
{
    private static Dictionary<string, bool> itemsCollect = new Dictionary<string, bool>();
    public static Dictionary<string, bool> GetItemsCollect() { return itemsCollect; }

    private static bool isExitAvilable = false;


    public void Start()
    {
        TestInit();
    }

    public static void TestInit()
    {
        //Временная ручная инициализация списка предметов
        List<string> items = new List<string>();
        //items.Add("Keys");
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
        foreach (KeyValuePair<string, bool> item in itemsCollect)
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
            itemsCollect.Add(item, false);
        }

    }

    public static void FinishLevel()
    {
        Debug.Log("finish");
    }


    public static bool CollectItem(string itemName)
    {
        try
        {
            itemsCollect[itemName] = true;
            Debug.Log("list coolect: "+ itemName);

            return true;
        }
        catch (KeyNotFoundException)
        {
            return false;
        }
    }
}
