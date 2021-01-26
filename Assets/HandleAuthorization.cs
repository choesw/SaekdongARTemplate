using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

/* GET PERMISSION FOR CAMERA */
public class HandleAuthorization : MonoBehaviour
{
    GameObject dialog = null;
    void Start ()
    {
     if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        StartCoroutine(RequestCamera());
    }

    IEnumerator RequestCamera(){
        while (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
            dialog = new GameObject();
            yield return null;
        }
    }

}
