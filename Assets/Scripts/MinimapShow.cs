using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapShow : MonoBehaviour
{
    public void SwitchVisibility()
	{
		if (this.transform.GetChild(0).gameObject.activeSelf)
		{
			this.transform.GetChild(0).gameObject.SetActive(false);
			this.transform.GetChild(1).gameObject.SetActive(false);	
			//this.transform.GetChild(2).gameObject.SetActive(false);	
		}
		else
		{
			this.transform.GetChild(0).gameObject.SetActive(true);
			this.transform.GetChild(1).gameObject.SetActive(true);
			//this.transform.GetChild(2).gameObject.SetActive(true);	
			GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Transform>().position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
		}
	}
	
	void Start()
	{
		SwitchVisibility();
	}
}
