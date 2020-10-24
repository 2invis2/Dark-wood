using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D rb;
    public GameObject lantern;
	
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
        LanternRotation();

    }
	
	public void Moving()
	{
		float axisX = Input.GetAxis ("Horizontal");
		float axisY = Input.GetAxis ("Vertical");
		rb.velocity = new Vector2 (axisX*speed, axisY*speed);	
	}
	
	public void LanternRotation()
	{
		/*
          Vector3 mouse = Input.mousePosition;
		Vector3 lightPoint = Camera.main.ScreenToWorldPoint(mouse);
		Debug.Log(lightPoint);
        */
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        lantern.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
