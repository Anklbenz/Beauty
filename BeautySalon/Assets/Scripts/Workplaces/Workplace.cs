using UnityEngine;
using Enums;

public abstract class Workplace : MonoBehaviour
{
    [SerializeField] protected WorkerTrigger workerTrigger;
    [SerializeField] protected VisitorTrigger visitorTrigger;
    public WorkplaceType WorkplaceType{ get; protected set; }
    public Visitor ServedVisitor{ get; protected set; }
    public Vector2 WorkerPosition => workerTrigger.transform.position;
    public Vector2 VisitorPosition => visitorTrigger.transform.position;
}