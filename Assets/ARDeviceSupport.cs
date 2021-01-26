using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARDeviceSupport : MonoBehaviour
{
    [SerializeField] ARSession m_arSession;

    private void OnDisable() => ARSession.stateChanged -= OnArStateChanged;

    void Awake() {
        m_arSession.enabled = false;
    }

    IEnumerator Start()
    {
        if ((ARSession.state == ARSessionState.None) ||
            (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
#if UNITY_EDITOR
            Debug.Log("The AR System is not supported");
#endif
        }

        else
        {
            ARSession.stateChanged += OnArStateChanged;
        }
    }

    public void ResetARSession() => m_arSession.Reset();
    public void EnableARSession(bool enable = true) => m_arSession.enabled = enable;

    void OnArStateChanged(ARSessionStateChangedEventArgs args)
    {
        switch (args.state)
        {
            case ARSessionState.None:
                Debug.Log("The AR System has not been initialized and availability is unknown.");
                break;

            case ARSessionState.Unsupported:
                Debug.Log("The current device doesn't support AR.");
                break;

            case ARSessionState.CheckingAvailability:
                Debug.Log("The system is checking the availability of AR on the current device.");
                break;

            case ARSessionState.NeedsInstall:
                Debug.Log("The current device supports AR, but AR support requires additional software to be installed.");
                break;

            case ARSessionState.Installing:
                Debug.Log("AR software is being installed.");
                break;

            case ARSessionState.Ready:
                Debug.Log("AR is supported and ready.");
                break;

            case ARSessionState.SessionInitializing:
                Debug.Log("An AR session is initializing (that is, starting up). This usually means AR is working, but hasn't gathered enough information about the environment.)");
                break;

            case ARSessionState.SessionTracking:
                Debug.Log("An AR session is running and is tracking (that is, the device is able to determine its position and orientation in the world).");
                break;
        }
    }
}
