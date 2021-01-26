using Lean.Touch;
using UnityEngine;

[RequireComponent(typeof(LeanSelectable))]
[RequireComponent(typeof(LeanPinchScale))]
[RequireComponent(typeof(LeanDragTranslate))]
[RequireComponent(typeof(BoxCollider))]
public class ElementsPrefabs : MonoBehaviour
{
    public bool isSortedOne;
    BoxCollider thisBoxCollider;
    LeanSelectable leanSelectable;
    LeanPinchScale leanPinchScale;
    LeanDragTranslate leanDragTranslate;
    public BoxCollider ThisBoxCollider { get => thisBoxCollider; set => thisBoxCollider = value; }


    private void Awake()
    {
        leanSelectable = GetComponent<LeanSelectable>();
        leanPinchScale = GetComponent<LeanPinchScale>();
        leanDragTranslate = GetComponent<LeanDragTranslate>();
        ThisBoxCollider = GetComponent<BoxCollider>();
        DisableElement();
    }

    public void DisableElement()
    {
        isSortedOne = true;
        ActivateInteraction(true);
    }

    public void EnableElement()
    {
        isSortedOne = false;
        changeColor();
        ActivateInteraction(false);
    }
    public void ActivateInteraction(bool enable = true)
    {
        if (leanSelectable != null)
            leanSelectable.enabled = enable;

        if (leanPinchScale != null)
        {
        leanPinchScale.Use.RequiredSelectable = null;
            leanPinchScale.enabled = enable;
        }

        if (leanDragTranslate != null)
            leanDragTranslate.enabled = enable;

        if (ThisBoxCollider != null)
            ThisBoxCollider.enabled = enable;
    }

    private void changeColor(){
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];
        int i = 0;
        while (i < vertices.Length) {
            colors[i] = Color.white;
            i++;
        }
        mesh.colors = colors;
    }
}
