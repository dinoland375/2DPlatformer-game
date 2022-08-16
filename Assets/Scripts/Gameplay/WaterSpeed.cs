using UnityEngine;

public class WaterSpeed : MonoBehaviour
{
    public CharacterControlls speedPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speedPlayer.speed = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speedPlayer.speed = 4;
        }
    }
}
