using UnityEngine;

public class Stairs : MonoBehaviour
{
    public float speed;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
