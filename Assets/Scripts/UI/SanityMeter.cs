using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityMeter : MonoBehaviour
{
    public Text sanityText;
    public Image image;
    public int maxSanity;
    public List<Sprite> imageList = new List<Sprite>();
	public void UpdateSanity(int lvl)
	{
        image.sprite = imageList[maxSanity - lvl];
		sanityText.text = "Рассудок: " + lvl;
	}
}
