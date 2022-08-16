using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport toTeleport;
    private bool isEnable;
    
    private Transform objectToMove;
    private void Start()
    {
        isEnable = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnable == false) return;
        
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(moveToTeleport(collision.gameObject.transform));
        }
    }
    IEnumerator moveToTeleport(Transform targetObject)
    {
        yield return new WaitForSeconds(0.5f);
 
        toTeleport.isEnable = false;
        
        targetObject.position = toTeleport.transform.position;
 
        yield return new WaitForSeconds(0.1f);
        toTeleport.isEnable = true;
    }
}
