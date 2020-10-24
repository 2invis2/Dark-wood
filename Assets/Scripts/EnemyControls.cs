using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public float speed = 1;
	private bool isActive;
	private Transform target;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }
	
	void Awake()
	{
		isActive = false;
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {

    }
	
	void FixedUpdate()
    {
		if (isActive)
			moveToPlayer();
    }
	
	
	
	public void OnView(float distance)
	{
		isActive = true;
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			isActive = false;
		}
	}
	
	public void moveToPlayer()
	{
		transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
	}
	
	
	
	
}
