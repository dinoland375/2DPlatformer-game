using UnityEngine;

public class ActivationPlatform : MonoBehaviour
{
    public GameObject lightPlatform;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lightPlatform.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lightPlatform.SetActive(false);
        }
    }
}
