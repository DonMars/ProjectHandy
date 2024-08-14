/*
/*/
///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_DDuA_Examples : VRG_Editor_DDuA
    {
        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (pathLocal)
            {
                // Tools/Vr Games Dev/Examples/DDuA/Download the full version
                case m_5_5_1:
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