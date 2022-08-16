using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("OpenDoor");
            Destroy(gameObject, 1.5f);
        }
    }
}
