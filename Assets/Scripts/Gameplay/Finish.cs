using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public string playerTag;
    public string NextSceneName;
    public Image ScreenBackground;

    private bool finished;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(finished)
            return;
        if(!other.gameObject.CompareTag(playerTag))
            return;
        finished = true;
    }

    private void Update()
    {
        UpdateScreenBackground();
    }

    private void UpdateScreenBackground()
    {
        if(!finished)
            return;

        if (ScreenBackground.color.a >= 1f)
        {
            SceneManager.LoadScene(NextSceneName);
            
            enabled = false;
        }

        var color = ScreenBackground.color;
        color.a += 0.02f;
        ScreenBackground.color = color;
    }    
    
}
