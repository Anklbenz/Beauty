using UnityEngine;
using Enums;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour
{
  [SerializeField] private int cardValue;
  public int CardValue => cardValue;
  
  private static readonly int Right = Animator.StringToHash("Right");
  private static readonly int Left = Animator.StringToHash("Left");
  private static readonly int None = Animator.StringToHash("None");
  private SpriteRenderer _sprite;
  private Animator _animator;

  private void Awake(){
    _animator = GetComponent<Animator>();
    _sprite = GetComponent<SpriteRenderer>();
  }

  public void SetOrderInLayer(int order) => _sprite.sortingOrder = order;
  public void Visible(bool state) => _sprite.enabled = state;

  public void CardTurn(TurnSide turn){
    switch (turn){
      case TurnSide.Left:
        _animator.SetTrigger(Left);
        break;
      case TurnSide.Right:
        _animator.SetTrigger(Right);
        break;
      case TurnSide.None:
        _animator.SetTrigger(None);
        break;
    }
  }
}