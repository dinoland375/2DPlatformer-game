using UnityEngine;
public class GameControlls : MonoBehaviour
{
    public GameObject settingsMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsMenu.SetActive(true);
        }
    }
}
