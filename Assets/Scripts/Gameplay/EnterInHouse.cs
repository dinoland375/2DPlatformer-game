using UnityEngine;

public class EnterInHouse : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.CompareTag("Player"))
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
    }
}
