using System.IO;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;
using UnityEditor.SceneManagement;

using VrGamesDev;

///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    /// <summary>
    ///  It just add menu items under tools/VR Games Dev and calculate some 
    ///  data shared among all the classes
    /// </summary>

    public class VRG_Editor_CORE : VRG_Editor_Menu
    {
        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (pathLocal)
            {
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////

                // Tools/CORE/Game: Create new
                case m_1_1:
                    if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                    {
                        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

                        bool bManagers = VRG_Managers(false, false);

                        if (bManagers)
                        {
                            VRG_Managers(true, false);

                            Html(!bManagers);

                            Main_Camera___Feedback();
                        }
                        else
                        {
                            Main_Camera___Feedback();

                            Html(!bManagers);
                        }
                    }
                    break;

                // Tools/CORE/Scene: Create new
                case m_1_2:
                    // Get existing open window or if none, make a new one:
                    VRG_WindowCreateNewGame window = (VRG_WindowCreateNewGame)EditorWindow.GetWindow(typeof(VRG_WindowCreateNewGame), false, "Create a new Game: Campaign", true);

                    window.maxSize = new Vector2(325f, 180f);
                    window.minSize = window.maxSize;

                    window.Show();
                    break;

                ////////////////////////////////////////////////////////////
                // Tools/CORE/UI/Main Camera: Feedback
                case m_1_3_1: Main_Camera___Feedback(); break;

                // Tools/CORE/UI/Html: (Header, Body, Footer)
                case m_1_3_2: Html(true); break;

                // Tools/CORE/UI/PopUp: Default
                case m_1_3_3: CreatePrefabInCanvas(m_Prefabs + "UI/PopUp - Default"); break;

                ////////////////////////////////////////////////////////////
                // Tools/CORE/UI/Button: Basic
                case m_1_3_4: CreatePrefabInCanvas(m_Prefabs + "UI/" + "VRG_Button - Basic"); break;

                // Tools/CORE/UI/Button: Icon
                case m_1_3_5: CreatePrefabInCanvas(m_Prefabs + "UI/" + "VRG_Button - Icon"); break;

                // Tools/CORE/UI/Button: Label and Icon
                case m_1_3_6: CreatePrefabInCanvas(m_Prefabs + "UI/" + "VRG_Button - Label and Icon"); break;

                ////////////////////////////////////////////////////////////
                // Tools/CORE/UI/Graphical Number: Basic
                case m_1_3_7: CreatePrefabInCanvas(m_Prefabs + "UI/" + "VRG_GraphicalNumber"); break;

                // Tools/CORE/UI/Graphical Number: Animated
                case m_1_3_8: CreatePrefabInCanvas(m_Prefabs + "UI/" + "VRG_GraphicalNumber - Animated"); break;

                // Tools/CORE/UI/Graphical Number: Graphical Number: BackWard Countdown
                case m_1_3_9: CreatePrefabInCanvas(m_Prefabs + "UI/" + "VRG_GraphicalNumber - BackWardCountdown"); break;
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////

                // Tools/CORE/Skins/UI Icon: VRG_SkinPool
                case m_1_4_1: CreatePrefabInCanvas(m_Prefabs + "Skin/" + "VRG_SkinPool - Icon"); break;

                // Tools/CORE/Skins/Add skin: Custom
                case m_1_4_2:
                    // Get existing open window or if none, make a new one:
                    VRG_WindowVRG_Skin windowSkin = (VRG_WindowVRG_Skin)EditorWindow.GetWindow(typeof(VRG_WindowVRG_Skin), false, "Create a custom VRG_Skin");

                    windowSkin.maxSize = new Vector2(325f, 180f);
                    windowSkin.minSize = windowSkin.maxSize;

                    windowSkin.Show();
                    break;

                // Tools/CORE/Skins/Add skin: All
                case m_1_4_3:
                    AddSkinToPool(m_Prefabs + "Skin/" + "VRG_Skin - Elysium");
                    AddSkinToPool(m_Prefabs + "Skin/" + "VRG_Skin - Gaia");
                    AddSkinToPool(m_Prefabs + "Skin/" + "VRG_Skin - Inferno");
                    AddSkinToPool(m_Prefabs + "Skin/" + "VRG_Skin - Limbo");
                    AddSkinToPool(m_Prefabs + "Skin/" + "VRG_Skin - Metropolis");
                    break;

                // Tools/CORE/Skins/Add skin: Elysium
                case m_1_4_4: AddSkinToPool(m_Prefabs + "Skin/" + "VRG_Skin - Elysium"); break;

                // Tools/CORE/Skins/Add skin: Gaia
                case m_1_4_5: AddSkinToPool(m_Prefabs + "Skin/" + "VRG_Skin - Gaia"); break;

                // Tools/CORE/Skins/Add skin: Inferno
                case m_1_4_6: AddSkinToPool(m_Prefabs + "Skin/" + "VRG_Skin - Inferno"); break;

                // Tools/CORE/Skins/Add skin: Limbo
                case m_1_4_7: AddSkinToPool(m_Prefabs + "Skin/" + "VRG_Skin - Limbo"); break;

                // Tools/CORE/Skins/Add skin: Metropolis
                case m_1_4_8: AddSkinToPool(m_Prefabs + "Skin/" + "VRG_Skin - Metropolis"); break;
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////

                // Tools/CORE/Scene Managment/VRG_GoToScene
                case m_1_5_1: CreatePrefab(m_Prefabs + "Scene Managment/VRG_GoToScene"); break;
                // Tools/CORE/Scene Managment/VRG_Managers
                case m_1_5_2: VRG_Managers(true, true); break;

                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////

                // Tools/CORE/Utils/VRG_SessionData
                case m_1_6_1: CreatePrefab(m_Prefabs + "Utils/VRG_SessionData"); break;

                // Tools/CORE/Utils/VRG_OpenUrl
                case m_1_6_2: CreatePrefab(m_Prefabs + "Utils/VRG_OpenUrl"); break;

                // Tools/CORE/Utils/VRG_FPS: Frames Per Second
                case m_1_6_3: CreatePrefab(m_Prefabs + "Utils/VRG_FPS", true); break;

                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////
                default: VRG_Editor_Menu.menuFSM(indexLocal, "CLASS: " + pathLocal); break;
            }
        }

        public static bool VRG_Managers(bool valueLocal, bool printLocal)
        {
            bool bContinue = false;

            if (Object.FindObjectsByType<VRG_Managers>(FindObjectsSortMode.None).Length == 0)
            {
                foreach (EditorBuildSettingsScene child in EditorBuildSettings.scenes)
                {
                    if (child.path.Contains("VRG_Managers"))
                    {
                        bContinue = true;
                        break;
                    }
                }

                if (bContinue)
                {
                    if (valueLocal)
                    {
                        CreatePrefab(m_Prefabs + "Scene Managment/VRG_Managers", true);
                    }
                }
                else
                {
                    if (printLocal)
                    {
                        print("<color=red>ERROR: </color>There aren't any VRG_Managers Scene in the build settings, please add scene");
                    }
                }
            }
            else
            {
                if (printLocal)
                {
                    print("<color=red>ERROR: </color>You already have a VRG_Managers object in the scene");
                }
            }

            return bContinue;
        }
        public static void Html(bool valueLocal)
        {
            CreatePrefabInCanvas(m_Prefabs + "UI/html", valueLocal);
        }
        public static void Main_Camera___Feedback()
        {
            CreatePrefab(m_Prefabs + "UI/Main Camera - Feedback", true);
        }

        protected static GameObject AddSkinToPool(string valueLocal)
        {
            GameObject go_Return = null;

            CreateVRG_SkinPool();

            VRG_SkinPool[] go_SkinPool = GameObject.FindObjectsByType<VRG_SkinPool>(FindObjectsSortMode.None);
            if (go_SkinPool.Length == 1)
            {
                CreatePrefab(valueLocal, go_SkinPool[0].transform);
            }
            else
            {
                print("<color=red>ERROR: </color> Can't create a VRG_SkinPool prefab");
            }

            return go_Return;
        }
    }

    public class VRG_WindowVRG_Skin : EditorWindow
    {
        private GUIStyle m_StyleWrap;

        private string m_SkinName = "Custom";

        void OnGUI()
        {
            this.m_StyleWrap = new GUIStyle(GUI.skin.label);
            this.m_StyleWrap.wordWrap = true;

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            GUILayout.Label("You will add a custom skin with the name below, If there isn't a skinpool, It will add one.", this.m_StyleWrap);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            //GUILayout.Label("VRG_Skin settings", EditorStyles.boldLabel);
            this.m_SkinName = EditorGUILayout.TextField("Skin name", this.m_SkinName);

            GUILayout.FlexibleSpace();
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Create new", GUILayout.Width(300), GUILayout.Height(30)))
            {
                VRG_Editor_CORE.CreateVRG_SkinPool();

                VRG_SkinPool[] go_SkinPool = GameObject.FindObjectsByType<VRG_SkinPool>(FindObjectsSortMode.None);
                if (go_SkinPool.Length > 0)
                {
                    GameObject go_VRG_Skin = VRG_Editor_CORE.CreatePrefab(VRG_Editor_CORE.m_Prefabs + "Skin/" + "VRG_Skin", go_SkinPool[0].transform);

                    go_VRG_Skin.name = "VRG_Skin - " + this.m_SkinName;

                    foreach (Transform child in go_VRG_Skin.transform)
                    {
                        VRG_SessionData childSession = child.GetComponent<VRG_SessionData>();
                        if (childSession != null)
                        {
                            childSession.value = this.m_SkinName;
                        }

                        VRG_SkinApply childApply = child.GetComponent<VRG_SkinApply>();
                        if (childApply != null)
                        {
                            childApply.sessionData = this.m_SkinName;
                        }
                    }
                }

                this.Close();
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }
    }

    public class VRG_WindowCreateNewGame : EditorWindow
    {
        private GUIStyle m_StyleWrap;

        private string m_FolderName = "_Game";

        void OnGUI()
        {
            int i = 0;

            this.m_StyleWrap = new GUIStyle(GUI.skin.label);
            this.m_StyleWrap.wordWrap = true;

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            GUILayout.Label("You will get a folder with all the scenes needed to create a new game, with the folder name you provide.", this.m_StyleWrap);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            this.m_FolderName = EditorGUILayout.TextField("Game name", this.m_FolderName);

            GUILayout.FlexibleSpace();
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();


            if (GUILayout.Button("Create new", GUILayout.Width(300), GUILayout.Height(30)))
            {
                string sNewGamePath = "Assets/" + this.m_FolderName;
                Directory.CreateDirectory(sNewGamePath);

                sNewGamePath = sNewGamePath + "/Scenes/";
                Directory.CreateDirectory(sNewGamePath);


                string sOldPath = VRG_Editor_CORE.CalculateInstallationPath() + "Tools/CORE/Scenes/";

                List<string> aScene = new List<string>();

                // Scenes
                aScene.Add("Campaign.unity");
                aScene.Add("Home.unity");
                aScene.Add("Survival.unity");
                aScene.Add("VRG_Managers.unity");

                string sMessage;
                foreach (string child in aScene)
                {
                    sMessage = "Copying " + child;
                    try
                    {
                        FileUtil.CopyFileOrDirectory(sOldPath + child, sNewGamePath + child);
                    }
                    catch (IOException ex)
                    {
                        sMessage = ex.Message;
                    }

                    //Debug.Log(sMessage);
                }

                AssetDatabase.Refresh();

                List<string> sceneList = new List<string>();

                sceneList.Add(sNewGamePath + "Home.unity");


                // get the scenes just created
                DirectoryInfo info = new DirectoryInfo(sNewGamePath);
                FileInfo[] fileInfo = info.GetFiles();
                foreach (FileInfo child in fileInfo)
                {
                    if (child.Name.Contains(".unity") && !child.Name.Contains(".meta"))
                    {
                        string[] both = child.DirectoryName.Split(new string[] { VRG_Editor.m_OS_Separator + "Assets" }, System.StringSplitOptions.None);

                        if (!sceneList.Contains("Assets" + both[1] + VRG_Editor.m_OS_Separator + child.Name))
                        {
                            sceneList.Add("Assets" + both[1] + VRG_Editor.m_OS_Separator + child.Name);
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

                i = 0;
                // Find valid Scene paths and make a list of EditorBuildSettingsScene
                List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
                foreach (string child in sceneList)
                {
                    if (!string.IsNullOrEmpty(sceneList[i]))
                    {
                        editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(sceneList[i], true));
                    }
                    Debug.Log("Adding Scene: " + i + ") " + sceneList[i]);
                    i++;
                }

                // Set the Build Settings window Scene list
                EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();

                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene(sceneList[0]);
                    Debug.Log("Opening Home Scene");
                }

                this.Close();
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
        }
    }
}