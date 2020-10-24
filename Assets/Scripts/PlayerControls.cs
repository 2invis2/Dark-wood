﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 1;
	private Rigidbody2D rb;
	
	// Start is called before the first frame update
    void Start()
    {
		rb = GetComponent <Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	void FixedUpdate()
	{
		Moving();
	}
	
	public void Moving()
	{
		float axisX = Input.GetAxis ("Horizontal");
		float axisY = Input.GetAxis ("Vertical");
		rb.velocity = new Vector2 (axisX*speed, axisY*speed);	
	}
}