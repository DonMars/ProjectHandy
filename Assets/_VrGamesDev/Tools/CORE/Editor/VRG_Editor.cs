using System;
using System.Collections.Generic;
using System.Diagnostics;

using UnityEditor;
using UnityEditor.SceneManagement;

using UnityEngine;

using Object = UnityEngine.Object;



///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor : VRG_Base
    {
        public static string m_InstallationPath = "Assets/_VrGamesDev/";

        public static string m_Prefabs = "Tools/CORE/Prefabs/";

#if UNITY_EDITOR_OSX
        public static string m_OS_Separator = "/";
#else
        public static string m_OS_Separator = "\\";
#endif


        public static string CalculateInstallationPath()
        {
            string[] stringSeparators = new string[] { "/Assets/" };

            // the stackframe holds the info of how it is running 
            StackFrame stackFrame = new StackFrame(0, true);

            string[] result = stackFrame.GetFileName().Split(stringSeparators, StringSplitOptions.None);

            if (result.Length == 2)
            {
                stringSeparators = new string[] { "_VrGamesDev/" };

                result = result[1].Split(stringSeparators, StringSplitOptions.None);

                if (result.Length == 2)
                {
                    m_InstallationPath = "Assets/" + result[0] + "_VrGamesDev/";
                }
            }

            return m_InstallationPath;
        }



        public static GameObject CreatePrefab(string valueLocal)
        {
            return CreatePrefab(valueLocal, false, null);
        }
        public static GameObject CreatePrefab(string valueLocal, bool forceUnparent)
        {
            return CreatePrefab(valueLocal, forceUnparent, null);
        }
        public static GameObject CreatePrefab(string valueLocal, Transform parentLocal)
        {
            return CreatePrefab(valueLocal, false, parentLocal);
        }
        public static GameObject CreatePrefab(string valueLocal, bool forceUnparent, Transform parentLocal)
        {
            GameObject go_Return = null;
            if (valueLocal.Trim() != "")
            {
                Object object_Undo;
                string sPath = CalculateInstallationPath() + valueLocal + ".prefab";

                Object prefab = AssetDatabase.LoadAssetAtPath(sPath, typeof(GameObject));

                if (prefab != null)
                {
                    if (parentLocal == null)
                    {
                        if (Selection.activeTransform == null || forceUnparent)
                        {
                            object_Undo = PrefabUtility.InstantiatePrefab(prefab, null);
                        }
                        else
                        {
                            object_Undo = PrefabUtility.InstantiatePrefab(prefab, Selection.activeTransform.gameObject.transform);
                        }
                    }
                    else
                    {
                        object_Undo = PrefabUtility.InstantiatePrefab(prefab, parentLocal);
                    }

                    go_Return = object_Undo as GameObject;

                    string[] sFinalSplit = valueLocal.Split('/');

                    Undo.RegisterCreatedObjectUndo(object_Undo, sFinalSplit[sFinalSplit.Length - 1]);

                    print("Adding " + sFinalSplit[sFinalSplit.Length - 1]);
                }
                else
                {
                    print("<color=red>ERROR: " + sPath + " NOT FOUND</color>, please check " + CalculateInstallationPath() + " installation.");
                }
            }
            else
            {
                print("<color=red>ERROR: No m_PrefabToLoad defined</color>");
            }

            return go_Return;
        }



        public static void CreateVRG_EventSystem()
        {
            if (Object.FindObjectsByType<VRG_EventSystem>(FindObjectsSortMode.None).Length == 0)
            {
                CreatePrefab(m_Prefabs + "VRG_EventSystem", true);
            }
        }

        public static void CreateVRG_SkinPool()
        {
            if (Object.FindObjectsByType<VRG_SkinPool>(FindObjectsSortMode.None).Length == 0)
            {
                CreatePrefab(m_Prefabs + "VRG_SkinPool", true);
            }
        }

        protected static GameObject CreatePrefabInCanvas(string valueLocal) => CreatePrefabInCanvas(valueLocal, true);
        protected static GameObject CreatePrefabInCanvas(string valueLocal, bool extrasLocal)
        {
            bool bReturn = false;
            bool bContinue = true;

            GameObject go_Return = null;

            if (Selection.activeTransform != null)
            {
                Canvas myCanvas;
                GameObject go_Canvas = Selection.activeTransform.gameObject;

                while (bContinue && go_Canvas != null)
                {
                    myCanvas = go_Canvas.transform.GetComponent<Canvas>();

                    if (myCanvas != null)
                    { 
                        bReturn = true;
                        bContinue = false;
                    }
                    else
                    {
                        if (go_Canvas.transform.parent != null)
                        {
                            go_Canvas = go_Canvas.transform.parent.gameObject;
                        }
                        else
                        {
                            bContinue = false;
                        }
                    }
                }
            }

            if (bReturn)
            {
                CreatePrefab(valueLocal);
            }
            else
            {
                GameObject go_UI = CreatePrefab(m_Prefabs + "VRG_UI", true);

                CreatePrefab(valueLocal, go_UI.transform);
            }

            if (extrasLocal)
            {
                if (Object.FindObjectsByType<VRG_Managers>(FindObjectsSortMode.None).Length == 0)
                {
                    CreateVRG_EventSystem();

                    CreateVRG_SkinPool();
                }
            }

            return go_Return;
        }

        public static void LoadScene(string valueLocal)
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(CalculateInstallationPath() + valueLocal + ".unity");
            }
        }

        public static void ClearBuildSettings()
        {
            List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
           
            // Set the Build Settings window Scene list
            EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
        }

        public static void AddScenesToBuildSettings(string[] valueLocal) => AddScenesToBuildSettings(valueLocal, true);
        public static void AddScenesToBuildSettings(string[] valueLocal, bool bFirstLocal)
        {
            if (valueLocal.Length > 0)
            {
                List<string> sceneList = new List<string>();

                if (bFirstLocal)
                {
                    for (int i = 0; i < valueLocal.Length; i++)
                    {
                        if (valueLocal[i].Trim() != string.Empty)
                        {
                            if (!sceneList.Contains(CalculateInstallationPath() + valueLocal[i] + ".unity"))
                            {
                                sceneList.Add(CalculateInstallationPath() + valueLocal[i] + ".unity");
                            }
                        }
                    }
                }

                foreach (EditorBuildSettingsScene child in EditorBuildSettings.scenes)
                {
                    if (!sceneList.Contains(child.path))
                    {
                        sceneList.Add(child.path);
                    }
                }


                if (!bFirstLocal)
                {
                    for (int i = 0; i < valueLocal.Length; i++)
                    {
                        if (valueLocal[i].Trim() != string.Empty)
                        {
                            if (!sceneList.Contains(CalculateInstallationPath() + valueLocal[i] + ".unity"))
                            {
                                sceneList.Add(CalculateInstallationPath() + valueLocal[i] + ".unity");
                            }
                        }
                    }
                }

                // Find valid Scene paths and make a list of EditorBuildSettingsScene
                List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (!string.IsNullOrEmpty(sceneList[i]))
                    {
                        editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(sceneList[i], true));
                    }
                }

                // Set the Build Settings window Scene list
                EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
            }
        }

        public static void RemoveScenesFromoBuildSettings(string[] valueLocal)
        {
            if (valueLocal.Length > 0)
            {
                List<string> sceneList = new List<string>();

                Array.Sort(valueLocal);

                foreach (EditorBuildSettingsScene child in EditorBuildSettings.scenes)
                {
                    if (Array.BinarySearch(valueLocal, ((child.path.Replace(".unity", "")).Replace(CalculateInstallationPath(), "")).Trim()) < 0)
                    {
                        sceneList.Add(child.path);
                    }
                }

                // Find valid Scene paths and make a list of EditorBuildSettingsScene
                List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (!string.IsNullOrEmpty(sceneList[i]))
                    {
                        editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(sceneList[i], true));
                    }
                }

                // Set the Build Settings window Scene list
                EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
            }
        }
    }
}