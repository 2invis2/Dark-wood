using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private float lightingRange = 1.0f;

    private PolygonCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider other)
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
