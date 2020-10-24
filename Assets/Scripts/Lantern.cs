using UnityEngine;

public class Lantern : MonoBehaviour
{

    private float lightingRange = 1.0f;

    private PolygonCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        float distance = Vector3.Magnitude(transform.position - other.gameObject.transform.position);
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.SendMessage("OnView", distance);
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.SendMessage("OffView");
    }
}
