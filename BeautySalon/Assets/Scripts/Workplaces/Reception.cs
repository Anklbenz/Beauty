using UnityEngine;
using UnityEngine.UI;

public class Reception : Workplace
{
    [SerializeField] private Button serviceButton;

    private void OnEnable(){
        workerTrigger.TriggerEvent += ReadyToWork;
        visitorTrigger.TriggerEvent += ReadyToWork;

    }

    private void OnDisable(){
        workerTrigger.TriggerEvent -= ReadyToWork;
        visitorTrigger.TriggerEvent -= ReadyToWork;

    }

    private void ReadyToWork(){
        if (workerTrigger.WorkerCame && visitorTrigger.VisitorCame)
            serviceButton.gameObject.SetActive(true);
        else
            serviceButton.gameObject.SetActive(false);
    }
}