using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterSystem
{
   private readonly Character _character;
   private readonly Vector2 _createPoint;
   private readonly Tilemap _walkingMap;
   
   public CharacterSystem(Character prefab, Vector2 createPoint, Transform parent, Tilemap walkingMap){
      _createPoint = createPoint;
      _walkingMap = walkingMap;
      _character = Object.Instantiate(prefab, parent);
   }

   public void Spawn(){
      _character.Initialize(_walkingMap, _createPoint);
      SetControlsActive(true);
   }
   
   public void SetControlsActive(bool state){
      _character.CanWalk = state;
   }
}
