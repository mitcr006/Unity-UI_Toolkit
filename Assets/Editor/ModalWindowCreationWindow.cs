using UnityEngine;
using UnityEditor;
using System.IO;

public class ModalWindowCreationWindow : EditorWindow
{
    private ModalWindowObjectNode windowToCreate;
    [MenuItem("UI Toolkit/Modal Window/Create New Window")]
    public static void ShowWindow()
    {
        ModalWindowCreationWindow instance = GetWindow<ModalWindowCreationWindow>("Modal Window Generator");
        instance.windowToCreate = CreateInstance<ModalWindowObjectNode>();
    }

    void OnGUI()
    {
        if(windowToCreate != null)
        {
            windowToCreate.windowName = EditorGUILayout.TextField("Window Name", windowToCreate.windowName);
            windowToCreate.headerText = EditorGUILayout.TextField("Header Text", windowToCreate.headerText);
            windowToCreate.bodyText = EditorGUILayout.TextField("Content Text", windowToCreate.bodyText);
            windowToCreate.bodyImage = (Sprite)EditorGUILayout.ObjectField("Content Image", windowToCreate.bodyImage, typeof(Sprite), allowSceneObjects: true);
            windowToCreate.confirmButtonText = EditorGUILayout.TextField("Confirm Button Text", windowToCreate.confirmButtonText);
            windowToCreate.cancelButtonText = EditorGUILayout.TextField("Cancel Button Text", windowToCreate.cancelButtonText);
            windowToCreate.additionalButtonText = EditorGUILayout.TextField("Additional Button Text", windowToCreate.additionalButtonText);

            if (GUILayout.Button("Create Window"))
            {
                if (!AssetDatabase.IsValidFolder("Assets/Resources/UI_Toolkit"))
                {
                    AssetDatabase.CreateFolder("Assets/Resources", "UI_Toolkit");
                }

                if (!AssetDatabase.IsValidFolder("Assets/Resources/UI_Toolkit/Modal_Windows"))
                {
                    AssetDatabase.CreateFolder("Assets/Resources/UI_Toolkit", "Modal_Windows");
                }
                if (windowToCreate.windowName != null)
                {
                    AssetDatabase.CreateAsset(windowToCreate, "Assets/Resources/UI_Toolkit/Modal_Windows/" + windowToCreate.windowName + ".asset");
                }
                else
                {
                    string[] files = Directory.GetFiles("Assets/Resources/UI_Toolkit/Modal_Windows");
                    AssetDatabase.CreateAsset(windowToCreate, "Assets/Resources/UI_Toolkit/Modal_Windows/newWindow" + files.Length + ".asset");
                }
                this.Close();
            }
        }
    }
}
