/*
/*/
using UnityEngine;

using VrGamesDev.BHEL;

///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_BHEL_Examples : VRG_Editor_BHEL
    {
        //public new static string m_Prefabs = "Tools/BHEL/Prefabs/";

        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (pathLocal)
            {
                // Examples/BHEL/VRG_BHEL: Create a Prefab demo
                case m_5_4_1:
                    VRG_Bhel inScene_VRG_Bhel = GameObject.FindAnyObjectByType<VRG_Bhel>();
                    if (inScene_VRG_Bhel == null)
                    {
                        CreatePrefab(m_Prefabs + "VRG_Bhel", true);
                    }
                    else
                    {
                        Debug.Log("<color=red>ERROR: </color> There is already a VRG_BHEL object in the scene");
                    }
                    break;

                // Examples/BHEL/00 Bhel Demo
                case m_5_4_2:
                    LoadScene("BHEL/Examples/Scenes/" + "00 Demo");
                    break;

                // Examples/BHEL/Download the full version
                case m_5_4_3:
                    PopUp();
                    break;

                default:
                    VRG_Editor_Menu.menuFSM(indexLocal, pathLocal);
                    break;
            }
        }
    }
}
//*/