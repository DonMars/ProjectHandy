///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_Analytics : VRG_Editor_Menu
    {
        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (indexLocal)
            {
                // /Unity Services/Analytics/UNITY_ANALYTICS_EVENT_LOGS: Add
                case p_4_2_1:
                    VRG_DefineSymbols.Add("UNITY_ANALYTICS_EVENT_LOGS");
                    print("UNITY_ANALYTICS_EVENT_LOGS: Added ... Recompiling");
                    break;

                // Unity Services/Analytics/UNITY_ANALYTICS_EVENT_LOGS: Remove
                case p_4_2_2:
                    VRG_DefineSymbols.Remove("UNITY_ANALYTICS_EVENT_LOGS");
                    print("UNITY_ANALYTICS_EVENT_LOGS: Removed ... Recompiling");
                    break;

                default:
                    VRG_Editor_Menu.menuFSM(indexLocal, pathLocal);
                    break;
            }
        }

    }
}