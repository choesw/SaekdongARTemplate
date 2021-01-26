using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class FloatingObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ElementsPrefabs> ElementsPrefabs;
    public GameObject cubeRoomRef;
    public LeanPinchScale leanPinchScale;
    public BoxCollider thisBoxCollider;
}
