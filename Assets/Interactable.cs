using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private AppController appController;
    private ElementsPrefabs elementsPrefabs;

    private void Start()
    {
        appController = FindObjectOfType<AppController>();
        elementsPrefabs = GetComponent<ElementsPrefabs>();
    }

    private void OnMouseDown()
    {
        elementsPrefabs.EnableElement();
        appController.CountSticks++;        
        if(appController.CountSticks >= appController.CountLimit){
            appController.GoToAllColored();
        }
    }
}
