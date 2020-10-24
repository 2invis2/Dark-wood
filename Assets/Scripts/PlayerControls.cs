using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D rb;

    public GameObject lantern;
    public GameObject Sprite_black;
    public GameObject Sprite_color;
    private SpriteRenderer black_render;
    private SpriteRenderer color_renderer;

    public GameObject handR;
    public GameObject handL;

    // Start is called before the first frame update
    void Start()
    {
		//rb = GetComponent <Rigidbody2D> ();
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        black_render = Sprite_black.GetComponent<SpriteRenderer>();
        color_renderer = Sprite_color.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Moving();
    }
	
	void FixedUpdate()
	{
		
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
        if (Mathf.Abs(rot_z) > 90)
        {
            black_render.flipX = true;
            color_renderer.flipX = true;
            handL.SetActive(true);
            handR.SetActive(false);


        }
        else
        {
            black_render.flipX = false;
            color_renderer.flipX = false;
            handL.SetActive(false);
            handR.SetActive(true);

        }

        lantern.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
 
    }
	
	public void CaughtByEnemy()
	{
		Debug.Log("Sanity decreased");
	}
	
}
