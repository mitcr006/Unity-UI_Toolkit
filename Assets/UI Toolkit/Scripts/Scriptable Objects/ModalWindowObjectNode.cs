using System;
using UnityEngine;
using UnityEngine.Events;

public class ModalWindowObjectNode : ScriptableObject
{
    [Header("Window Name")]
    public string windowName;

    [Header("Header")]
    public string headerText;

    [Header("Body")]
    public string bodyText;
    public Sprite bodyImage;

    [Header("Footer")]
    public string confirmButtonText;
    public string cancelButtonText;
    public string additionalButtonText;

    private static readonly string MODAL_WINDOW_PREFAB = "UI_Toolkit/Prefabs/Modal Window Prefab";
    // Start is called before the first frame update
    public static GameObject CreateModalWindowObject(ModalWindowObjectNode modalNode, Action onAccept = null, Action onExtra = null, Action onCancel = null)
    {
        GameObject modalWindowPrefab = Resources.Load(MODAL_WINDOW_PREFAB) as GameObject;
        GameObject modalWindow = GameObject.Instantiate(modalWindowPrefab, Vector3.zero, Quaternion.identity);
        modalWindow.transform.localPosition = Vector3.zero;
        modalWindow.GetComponent<ModalWindow>().CreateModalWindow(modalNode, onAccept, onExtra, onCancel);
        return modalWindow;
    }
}
