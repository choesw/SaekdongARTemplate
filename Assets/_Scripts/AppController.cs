using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour
{

    [Header("CONTROLLERS")]
    [SerializeField] ARDeviceSupport m_ARDeviceSupport;
    [SerializeField] PlacementManager m_placementManager;
    [SerializeField] ARPlaneManager m_arPlaneManager;
    [Space]
    [Header("CANVAS")]
    [SerializeField] GameObject m_loadingCanvas;
    [SerializeField] GameObject m_markerCanvas;
    [SerializeField] GameObject m_arCanvas;
    [Space]
    [Header("MARKER")]
    [SerializeField] GameObject m_markerImage;
    [Header("SETTINGS")]
    [SerializeField] int m_ResetTime;
    public int CountLimit;
    public int CountSticks;

    private void OnEnable() => m_arPlaneManager.planesChanged += OnPlaneChanged;
    private void OnDisable() => m_arPlaneManager.planesChanged -= OnPlaneChanged;
    private void OnPlaneChanged(ARPlanesChangedEventArgs obj)
    {
        foreach (var plane in obj.added)
            plane.gameObject.SetActive(false);
    }


    void Start()
    {
        m_loadingCanvas.SetActive(true);
        StartCoroutine(LoadMarkerCanvas());
    }

    IEnumerator LoadMarkerCanvas(){
        yield return new WaitForSeconds(0.5f);
        GoToMarkerCanvas();
    }

    IEnumerator ResetAppState(){
        yield return new WaitForSeconds(m_ResetTime);
        GoToLoadingCanvas();
    }

    public void GoToLoadingCanvas()
    {
        m_ARDeviceSupport.ResetARSession();
        SceneManager.LoadScene("AR");
    }

    public void GoToMarkerCanvas(){
        m_loadingCanvas.SetActive(false);
        m_arCanvas.SetActive(false);
        m_markerCanvas.SetActive(true);
        m_markerImage.SetActive(true);
        m_ARDeviceSupport.EnableARSession();
    }

    public void GoToARCanvas(){
        m_markerCanvas.SetActive(false);
        m_loadingCanvas.SetActive(false);
        m_arCanvas.SetActive(true);
        foreach (var plane in m_arPlaneManager.trackables)
            plane.gameObject.SetActive(false);
    }

    public void GoToAllColored(){
        m_placementManager.SelectAllElements();
        StartCoroutine(ResetAppState());
    }
}
