using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//CREDITS TO: JLJac on Unity Answer Forums, thanks for the help!!!

public class ParentEditor : EditorWindow
{
    public Transform rootObject;
    public Transform newArmature;
    public string rootBoneName = "Hips";
    public bool pressToReassign;

    [MenuItem("Window/AW Parent Editor")]
    public static void ShowWindow()
    {
        GetWindow<ParentEditor>("AW Parent Editor");
    }

    void OnGUI()
    {
        EditorGUILayout.Space();
        rootObject = EditorGUILayout.ObjectField("Destination Prefab", rootObject, typeof(Transform), true) as Transform;
        EditorGUILayout.Space();
        newArmature = EditorGUILayout.ObjectField("New Armature", newArmature, typeof(Transform), true) as Transform;
        rootBoneName = EditorGUILayout.TextField("Root Bone Name", rootBoneName);
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if (GUILayout.Button("Reassign Bones"))
        {
            Reassign();
        }
        EditorGUILayout.Space();

    }

    public void Reassign()
    {
        if (newArmature == null) {
            Debug.Log("No new armature assigned");
            return;
        }

        if (newArmature.Find(rootBoneName) == null) {
            Debug.Log("Root bone not found");
            return;
        }

        Debug.Log("Reassigning bones");
        SkinnedMeshRenderer rend = Selection.activeGameObject.GetComponent<SkinnedMeshRenderer>();
        Transform[] bones = rend.bones;

        rend.rootBone = newArmature.Find(rootBoneName);

        Transform[] children = newArmature.GetComponentsInChildren<Transform>();

        for (int i = 0; i < bones.Length; i++)
            for (int a = 0; a < children.Length; a++)
                if (bones[i].name == children[a].name) {
                    bones[i] = children[a];
                    break;
                }

        rend.bones = bones;
        GameObject rootObject = newArmature.parent.gameObject;
        rend.transform.SetParent(rootObject.transform, false);
    }

}
