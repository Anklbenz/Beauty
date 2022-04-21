using System;
using UnityEngine;

public class VisitorTrigger : MonoBehaviour
{
    public event Action TriggerEvent;
    public Visitor Visitor{ get; private set; }
    public bool VisitorCame{ get; private set; }

    private void OnTriggerEnter2D(Collider2D other){
        AvatarOnTable(other, true);
    }

    private void OnTriggerExit2D(Collider2D other){
        AvatarOnTable(other, false);
    }

    private void AvatarOnTable(Collider2D other, bool connect){
        var visitor = other.GetComponent<Visitor>();
        
        if (visitor){
            VisitorCame = connect;
            Visitor = visitor;
            TriggerEvent?.Invoke();
        }
        else{
            Visitor = null;
        }
    }
}
