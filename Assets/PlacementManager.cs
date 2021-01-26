using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] AppController m_appController;
    [SerializeField] ARTrackedImageManager m_arTrackedImageManager;
    [SerializeField] ARRaycastManager m_arRaycastManager;
    [SerializeField] FloatingObjects m_groupObjectsPrefab;
    FloatingObjects groupObjects;

    private void OnEnable() => m_arTrackedImageManager.trackedImagesChanged += OnARTrackedImageChanged;
    private void OnDisable() => m_arTrackedImageManager.trackedImagesChanged -= OnARTrackedImageChanged;
    private void OnARTrackedImageChanged(ARTrackedImagesChangedEventArgs Images){
        foreach(var image in Images.added ){
            m_appController.GoToARCanvas();
            m_arTrackedImageManager.enabled = false;
            CreateElementField(image);
        }
    }
    private void CreateElementField(ARTrackedImage arTrackedImage = null){
        if(groupObjects == null) this.groupObjects = Instantiate(m_groupObjectsPrefab);
        if(arTrackedImage != null) this.groupObjects.transform.SetParent(arTrackedImage.transform);
    }

    public void SelectAllElements(){
        foreach(var item in groupObjects.ElementsPrefabs){
            item.EnableElement();
            item.ActivateInteraction(false);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
