using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotate : MonoBehaviour
{
    public void ChangeDirection(float angle)
	{
		transform.eulerAngles = new Vector3 (0, 0, angle);
	}
}
