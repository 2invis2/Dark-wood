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
	public Animator animator;

	private CharState State
	{
		get { return (CharState)animator.GetInteger("State"); }
		set { animator.SetInteger("State", (int)value); }
	}
	
	void Awake()
	{
		isActive = false;
		offSight = true;
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animator = GetComponentInChildren<Animator>();
	}
	
	void FixedUpdate()
    {
		if (isActive)
		{
			moveToPlayer();
			if (!offSight)
			{
				State = CharState.Move;
			}
			else
            {
				State = CharState.MoveShadow;
			}

		}

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
		//Debug.Log("вне зрения " +offSight + "активен " + isActive + " расстояние " + distanceToPlayer);
		if (maxDist < distanceToPlayer)
		{
			isActive = false;
			State = CharState.Shadow;
		}
	}
	
	public void moveToPlayer()
	{
		transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.gameObject.tag == "Player")
			{
				collision.collider.gameObject.SendMessage("CaughtByEnemy");
				JobDone();
			}
	}
	
	public void JobDone()
	{
		Destroy(this.gameObject);
	}
}

public enum CharState
{
	Shadow,
	Move,
	MoveShadow
}
