using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityMeter : MonoBehaviour
{
	public Text sanityText;
	public void UpdateSanity(int lvl)
	{
		sanityText.text = "Sanity: " + lvl;
	}
}
