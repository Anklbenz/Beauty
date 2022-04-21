using UnityEngine;
using UnityEngine.Tilemaps;

public class Character : AvatarBase
{
    [SerializeField] private InputReaderWalk inputReader;
    public bool CanWalk{ get; set; }

    private Tilemap _walkingArea;
    private void OnEnable(){
        inputReader.WorkplaceSelectedEvent += WalkToWorkplace;
        inputReader.MoveEvent += TryWalk;
    }

    private void OnDisable(){
        inputReader.WorkplaceSelectedEvent -= WalkToWorkplace;
        inputReader.MoveEvent -= TryWalk;
    }

    public void Initialize(Tilemap walkingArea, Vector2 createPoint){
        _walkingArea = walkingArea;
        transform.position = createPoint;
    }

    private void TryWalk(Vector2 point){
        if (!CanWalk) return;

        var gridPosition = _walkingArea.WorldToCell(point);
        if (!_walkingArea.HasTile(gridPosition)) return;

        Motor.SetDestination(point);
    }

    private void WalkToWorkplace(Workplace workplace){
        if (!CanWalk) return;
        Motor.SetDestination(workplace.WorkerPosition);
    }
    
    

}

