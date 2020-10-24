using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 1;
	public int sanity = 5;
    private Rigidbody2D rb;
	public float compassAngle;
    public GameObject Ui;
    public GameObject lantern;
    public GameObject Sprite_black;
    public GameObject Sprite_color;
	public GameObject SanityMeter;
    private SpriteRenderer black_render;
    private SpriteRenderer color_renderer;
	private bool MapEnabled;

    public Animator animator_black;
    public Animator animator_color;

    public GameObject handR;
    public GameObject handL;

    private AudioSource audio;
    public GameLogic gl;
    public AudioClip Damage;
    // Start is called before the first frame update
    void Start()
    {

		//rb = GetComponent <Rigidbody2D> ();
    }

    private void OnEnable()
    {
       
        SanityMeter.SendMessage("UpdateSanity", sanity);
        audio = GetComponent<AudioSource>();
        audio.Play();
		rb = GetComponent<Rigidbody2D>();
		MapEnabled = false;
        black_render = Sprite_black.GetComponent<SpriteRenderer>();
        color_renderer = Sprite_color.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Moving();
		Minimap();
		Compass();
		//Debug.Log(compassAngle);
    }
	
	void FixedUpdate()
	{
		
        LanternRotation();

    }

    public void Moving()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");
		Vector2 move = new Vector2(axisX, axisY);
		move.Normalize();
        rb.velocity = new Vector2(move.x*speed, move.y*speed);

        if((axisX !=0) || (axisY != 0))
        {
            animator_black.SetFloat("Walk", 1.0f);
            animator_color.SetFloat("Walk", 1.0f);
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else
        {
            animator_black.SetFloat("Walk", 0f);
            animator_color.SetFloat("Walk", 0f);
            audio.Pause();
        }
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

        audio.PlayOneShot(Damage);
		Debug.Log("Sanity decreased");
        sanity--;
        gl.damageTime = Time.time;
		SanityMeter.SendMessage("UpdateSanity", sanity);
		if (sanity == 0) Ui.GetComponent<EndGame>().GameOver("Sanity is gone");
		
	}
	
	public void Minimap()
	{
		if (Input.GetKeyDown("m"))
		{		
			GameObject.FindGameObjectWithTag("Minimap").GetComponent<MinimapShow>().SwitchVisibility();
		}
		
	}
	
	public void Compass()
	{
		GameObject.FindGameObjectWithTag("Exit").GetComponent<Transform>();
		Vector2 exitPoint =  new Vector2(GameObject.FindGameObjectWithTag("Exit").GetComponent<Transform>().position.x - transform.position.x, GameObject.FindGameObjectWithTag("Exit").GetComponent<Transform>().position.y - transform.position.y);
		compassAngle = (Vector2.Angle(exitPoint, Vector2.down) * exitPoint.x/Mathf.Abs(exitPoint.x))+180;
		GameObject.FindGameObjectWithTag("Compass").GetComponent<CompassRotate>().ChangeDirection(compassAngle);	
	}
}
