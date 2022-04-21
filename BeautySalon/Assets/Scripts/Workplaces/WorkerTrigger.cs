using System;
using UnityEngine;

public class WorkerTrigger : MonoBehaviour
{
    public event Action TriggerEvent;
    public bool WorkerCame{ get; private set; }
    private void OnTriggerEnter2D(Collider2D other){
        AvatarOnTable(other, true);
    }

    private void OnTriggerExit2D(Collider2D other){
        AvatarOnTable(other, false);
    }
    
    private void AvatarOnTable(Collider2D other, bool connect){
        var worker = other.GetComponent<Character>();
        if (!worker) return;

        WorkerCame = connect;
        TriggerEvent?.Invoke();
    }
}
