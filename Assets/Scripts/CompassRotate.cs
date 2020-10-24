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
		transform.eulerAngles = new Vector3 (0, 0, angle);
	}
	
	public void Anomaly()
	{
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z + Random.Range(-30.0f, 30.0f));
	}
}
