///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_CORE_VRG_Remote_Examples : VRG_Editor_DDuA
    {
        private static string m_ExamplesFolder = "Remote Config/Examples/Scenes/";

        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (pathLocal)
            {
                // Tools/Vr Games Dev/Examples/Remote Config/01 UI Text
                case m_5_2_1:   LoadScene(m_ExamplesFolder + "01 UI Text");             break;

                // Tools/Vr Games Dev/Examples/Remote Config/02 A simple combat
                // 
                case m_5_2_2:   LoadScene(m_ExamplesFolder + "02 A simple combat");     break;
                
                // Tools/Vr Games Dev/Examples/Remote Config/03 VRG_Announcement
                case m_5_2_3:   LoadScene(m_ExamplesFolder + "03 VRG_Announcement");    break;

                default:
                    VRG_Editor_Menu.menuFSM(indexLocal, pathLocal);
                break;
            }
        }
    }
}
