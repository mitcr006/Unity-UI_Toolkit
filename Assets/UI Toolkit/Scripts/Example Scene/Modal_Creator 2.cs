using System;
using UnityEngine;
using UnityEngine.Events;

public class Modal_Creator : MonoBehaviour
{
    [SerializeField]
    private Transform uiTransform;
    [SerializeField]
    private ModalWindowObjectNode node;

    // Start is called before the first frame update
    void Start()
    {
        GameObject window = ModalWindowObjectNode.CreateModalWindowObject(node, AcceptPressed, ExtraPressed, CancelPressed);
        window.transform.SetParent(uiTransform);
        window.transform.localPosition = Vector3.zero;
    }

    public void AcceptPressed()
    {
        Debug.Log("Accept");
    }
    public void CancelPressed()
    {
        Debug.Log("Cancel");
    }
    public void ExtraPressed()
    {
        Debug.Log("Extra");
    }
}
