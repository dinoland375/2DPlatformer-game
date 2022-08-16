using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public Image healthImage;
    public int healthCountPlayer = 100;
    
    public Animator animator;
    public GameObject respawnMenu;

    void FixedUpdate()
    {
        UpdateUi();

        if (healthCountPlayer <= 0)
        {
            DeathProcess();
        }
    }
    void UpdateUi()
    {
        healthImage.fillAmount = healthCountPlayer / 100f;
    }
    
    void DeathProcess()
    {
        animator.SetBool("Dead", true);
    }

    public void StopingGame()
    {
        Time.timeScale = 0;
        Destroy(gameObject);
        respawnMenu.SetActive(true);
    }
}
