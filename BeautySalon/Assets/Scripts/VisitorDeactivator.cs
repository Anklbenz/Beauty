using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorDeactivator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        var visitor = other.GetComponent<Visitor>();

        if (!visitor) return;
        visitor.Disable();
    }
}
