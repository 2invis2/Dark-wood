using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLogic: MonoBehaviour
{
    private static Dictionary<string, bool> itemsToCollect = new Dictionary<string, bool>();
    public static Dictionary<string, bool> GetItemsCollect() { return itemsToCollect; }

    private static bool isExitAvilable = false;

    public AudioClip backMusic;

    private AudioSource audio;

    public Dictionary<string, Sprite> listAllItems = new Dictionary<string, Sprite>();

    public List<string> itemsNames = new List<string>();
    public List<Sprite> itemsSprites = new List<Sprite>();

    public Text uITextQuestList;
    public List<Image> questImages;

    public GameObject uIQuestList;

    public GameObject window;
    public float damageTime;
    public float damageCooldown = 0.7f;
    public void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(backMusic);

        InitDictionary();
        TestInit();
        InitQuestList();
        //window = GameObject.Find("BlackWindow");
        damageTime = Time.time;

    }


    public void Update()
    {
        BlackWindow();
        if (Input.GetButtonDown("QuestList"))
        {
            Debug.Log(uIQuestList.active);
            SwitchQuestList();
        }
    }


    public void SwitchQuestList()
    {
        Debug.Log(uIQuestList.active);
        RefreshQuestList();
        if (uIQuestList.active)
        {
            uIQuestList.SetActive(false);

        }
        else
        {
            uIQuestList.SetActive(true);

        }


    }
    public void InitDictionary()
    {
        int i = 0;
        for(i =0; i<itemsNames.Count; i++)
        {
            listAllItems.Add(itemsNames[i], itemsSprites[i]);
            Debug.Log(itemsNames[i], itemsSprites[i]);
        }
        
    }
    //Временная ручная инициализация списка предметов
    public static void TestInit()
    {

        List<string> items = new List<string>();
        items.Add("Keys");
        items.Add("Compass");
        InitItemList(items);

    }

    public void InitQuestList()
    {
        string listText = "";
        int count = 0;
        foreach (KeyValuePair<string, bool> item in itemsToCollect)
        {
            Sprite sp;
            listText += item.Key + "\n";
            if (listAllItems.TryGetValue(item.Key, out sp))
            {
                questImages[count].enabled = true;
                questImages[count].sprite = sp;
            }
            count += 1;

        }
        for(int i =count; i <= 5; i++)
        {
            listText += "\n";
        }
        uITextQuestList.text = listText;


    }

    public void RefreshQuestList()
    {
        foreach (KeyValuePair<string, bool> item in itemsToCollect)
        {
            if ((item.Value)&&(! uITextQuestList.text.Contains(item.Key + "✓")))
            {
                uITextQuestList.text = uITextQuestList.text.Replace(item.Key, item.Key + "✓");
            }
        }
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

    public static void FailedLevel()
    {

    }

    public  void BlackWindow()
    {
        if(Time.time - damageTime <= damageCooldown)
        {
            window.GetComponent<Image>().color = new Color(0,0,0,1- ((Time.time - damageTime)/ damageCooldown));
        }
        else
        {
            window.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }


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
