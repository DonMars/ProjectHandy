/*
/*/
///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_BHEL_VRG_Remote : VRG_Editor_BHEL
    {
        //public new static string m_Prefabs = "Tools/BHEL/Prefabs/";

        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (pathLocal)
            {
                // Tools/Vr Games Dev/Unity Services/Remote Config/BHEL/Download the full version
                case m_4_1_5:
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