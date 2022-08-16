using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public GameObject bg1;
    public GameObject bg2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bg1.SetActive(false);
            bg2.SetActive(true);
        }
    }
}
