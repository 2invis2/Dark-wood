using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col)
	{
		float forceX = -(col.attachedRigidbody.position.x)/Mathf.Abs(col.attachedRigidbody.position.x);
		float forceY = -(col.attachedRigidbody.position.y)/Mathf.Abs(col.attachedRigidbody.position.y);
		Vector2 force = new Vector2 (forceX*5000, forceY*5000);
		col.attachedRigidbody.AddForce(force); 
		Debug.Log("border reached");
	}
}
