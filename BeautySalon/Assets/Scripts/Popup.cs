using UnityEngine;
using UnityEngine.UI;

public class Popup
{
    private readonly Animator _animator;
    private readonly Text _serviceNumberLabel;

    public Popup(Text serviceNumberLabel, Animator animator){
        _serviceNumberLabel = serviceNumberLabel;
        _animator = animator;
    }

    public void Show(bool state) => _animator.SetBool("Visible", state);

    public void SetNumber(string txt) => _serviceNumberLabel.text = txt;
}
