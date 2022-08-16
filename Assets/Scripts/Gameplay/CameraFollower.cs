using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float speed = 0.5f;
    public new Transform camera; 
    public Transform player; 
    
    private void FixedUpdate()
    {
        var cameraPosition = camera.position;
        cameraPosition.x = Mathf.Lerp(cameraPosition.x, player.position.x, speed); 
        cameraPosition.y = Mathf.Lerp(cameraPosition.y + 1f, player.position.y + 1f, speed);
        
        camera.position = cameraPosition; 
    }
}
