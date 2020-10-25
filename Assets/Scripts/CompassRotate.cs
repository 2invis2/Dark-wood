using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotate : MonoBehaviour
{
    private float timer;
	
	void Start()
	{
		timer = 0;
	}
	
	void Update()
	{
		timer +=Time.deltaTime;
	}
	
	public void ChangeDirection(float angle)
	{
		float prev;
		if (transform.eulerAngles.z>0)
			prev = transform.eulerAngles.z-180;
		else
			prev = transform.eulerAngles.z;
			
		if (timer > 1)
			transform.eulerAngles = new Vector3 (0, 0, ((prev*14/15)+(angle*1/15)+180));
	}
	
	public void Anomaly()
	{
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z + Random.Range(-3.0f, 3.0f));
		timer = 0;
	}
}
