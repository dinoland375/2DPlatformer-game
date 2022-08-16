using UnityEngine;
using UnityEngine.UI;
public class HealthEnemy : MonoBehaviour
{
    public Image healthImage;
    public int healthCount = 100;
    public int damageToEnemy = 20;
    public Animator animator;
    public GameObject shootEffect;
    public GameObject scoreImage;
    public Ai ai;
    public AudioSource audioSource;
    public AudioClip audioClips; 
    
    void Update()
    {
        UpdateUi();
        
        if (healthCount <= 0)
        {
            Kill();
            ai.speed = 0f;
            Destroy(gameObject, 1.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            audioSource.PlayOneShot(audioClips);
            shootEffect.SetActive(true);
            GetComponentInChildren<ParticleSystem>().Play();
            healthCount = healthCount - damageToEnemy;
        }
    }
    void UpdateUi()
    {
        healthImage.fillAmount = healthCount / 100f;
    }
    void Kill()
    {
        animator.SetBool("Dead", true);
    }
    void EventKill()
    {
        scoreImage.SetActive(true);
    }
    
}
