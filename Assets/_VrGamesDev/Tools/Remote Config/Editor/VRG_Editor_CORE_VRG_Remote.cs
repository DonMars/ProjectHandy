using UnityEngine;

//  This namespace is the base to all the editor classes of VRG packages
///#IGNORE
namespace VrGamesDev.Editor
{
    public class VRG_Editor_VRG_Remote : VRG_Editor_Menu
    {
        public new static string m_Prefabs = "Tools/Remote Config/Prefabs/";

        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (indexLocal)
            {
                //  Tools/Unity Services/Remote Config/Add VRG_Remote Prefab
                case p_4_1_1: CreatePrefab(m_Prefabs + "VRG_Remote", true); break;

                // Unity Services/Remote Config/REMOTE_CONFIG_INSTALLED: Add
                case p_4_1_2:
                    VRG_DefineSymbols.Add("REMOTE_CONFIG_INSTALLED");
                    print("REMOTE_CONFIG_INSTALLED: Added ... Recompiling");
                    break;

                // Unity Services/Remote Config/REMOTE_CONFIG_INSTALLED: Remove
                case p_4_1_3:
                    VRG_DefineSymbols.Remove("REMOTE_CONFIG_INSTALLED");
                    print("REMOTE_CONFIG_INSTALLED: Removed ... Recompiling");
                    break;

                // Unity Services/Remote Config/VRG_Announcement/Add preconfigured VRG_Remote
                case p_4_1_4_1: Add_VRG_Remote_VRG_Announcement(); break;

                // Unity Services/Remote Config/VRG_Announcement/UI: Icon
                case p_4_1_4_2: CreatePrefabInCanvas(m_Prefabs + "Announcement/" + "VRG_Announcement - Icon"); break;

                // Unity Services/Remote Config/VRG_Announcement/UI: PopUp window
                case p_4_1_4_3:
                    CreateVRG_EventSystem();

                    CreateVRG_SkinPool();

                    VRG_Announcement inScene_VRG_Announcement = GameObject.FindAnyObjectByType<VRG_Announcement>();

                    if (inScene_VRG_Announcement == null)
                    {
                        CreatePrefab(m_Prefabs + "Announcement/" + "VRG_Announcement", true);
                        inScene_VRG_Announcement = GameObject.FindAnyObjectByType<VRG_Announcement>();
                    }
                    else
                    {
                        Debug.Log("<color=red>ERROR: </color> There is already a VRG_Announcement object in the scene");
                    }

                    VRG_Editor_VRG_Remote.Add_VRG_Remote_VRG_Announcement();
                    break;


                default:
                    VRG_Editor_Menu.menuFSM(indexLocal, "CLASS: " + pathLocal);
                    break;
            }
        }

        public static void Add_VRG_Remote_VRG_Announcement()
        {
            VRG_Remote go_Remote = CreateRemote("VRG_Announcement");

            if (go_Remote != null)
            {
                go_Remote.AddInt("VRG_Announcement.repeat", 0);

                go_Remote.AddString("VRG_Announcement.date", "2000-01-01");
                go_Remote.AddString("VRG_Announcement.title", "Added from Menu");
                go_Remote.AddString("VRG_Announcement.body", "Edit the VRG_Remote object added to customize this local message.<br><br>Remember to create the server version when you publish your game");
            }
        }
        
        public static VRG_Remote CreateRemote(string valueLocal)
        {
            bool IsNew = true;
            VRG_Remote go_Return = null;
            VRG_Remote[] go_Returns = GameObject.FindObjectsByType<VRG_Remote>(FindObjectsSortMode.None);

            foreach (VRG_Remote child in go_Returns)
            {
                if (child.id == valueLocal)
                {
                    IsNew = false;
                    break;
                }
            }

            if (IsNew)
            {
                GameObject go_InScene = CreatePrefab(m_Prefabs + "VRG_Remote", true);
                go_InScene.GetComponent<VRG_Remote>().id = valueLocal;

                go_Returns = GameObject.FindObjectsByType<VRG_Remote>(FindObjectsSortMode.None);
                foreach (VRG_Remote child in go_Returns)
                {
                    if (child.id == valueLocal)
                    {
                        go_Return = child;
                        break;
                    }
                }
            }
            else
            {
                print("<color=red>ERROR: </color> There is already a VRG_Remote - (" + valueLocal + ") object in the scene");
            }
            return go_Return;
        }
    }
}