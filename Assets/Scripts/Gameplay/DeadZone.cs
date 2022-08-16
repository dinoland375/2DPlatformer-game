using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Health healthPlayer;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healthPlayer.healthCountPlayer = 0;
        }
    }
}
