using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public float speed = 1;
	public float chaseDistance = 4;
	private float distanceToPlayer;
	private bool isActive;
	private bool offSight;
	private Transform target;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }
	
	void Awake()
	{
		isActive = false;
		offSight = true;
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
		distanceToPlayer = Vector3.Magnitude(transform.position - target.position);
		if (offSight)
			CheckStop(chaseDistance); 
    }
	
	
	
	public void OnView(float distance)
	{
		isActive = true;
		offSight = false;
	}
	
	public void OffView()
	{
		offSight = true;
	}
	
	
	public void CheckStop(float maxDist)
	{
		Debug.Log("вне зрения " +offSight + "активен " + isActive + " расстояние " + distanceToPlayer);
		if (maxDist < distanceToPlayer)
		{
			isActive = false;
		}
	}
	
	public void moveToPlayer()
	{
		transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
	}
	
	
	
	
}
