using UnityEngine;

public class OpenTheDoor2 : MonoBehaviour
{
    public Animator animator;
    public GameObject door;
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            door.SetActive(true);
            text.SetActive(false);
            animator.SetTrigger("StartStairs");
        }
    }
}
