using UnityEditor;

///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_Menu : VRG_Editor
    {
//*
        public const string  m_MenuPathBase = "Tools/Vr Games Dev/";
/*/
        public const string  m_MenuPathBase = "Tools/";
// */


        protected const int p_Next = 1;        
        protected const int p_Raya = 11;        
        protected const string f_Diagonal = "/";
        protected const string f_CORE = m_MenuPathBase + "CORE" + f_Diagonal;
        protected const string f_BHEL = m_MenuPathBase + "BHEL";
        protected const string f_DDUA = m_MenuPathBase + "DDUA";
        protected const string f_US = m_MenuPathBase + "Unity Services" + f_Diagonal;
        protected const string f_Examples = m_MenuPathBase + "Examples" +f_Diagonal;
        protected const string f_About = m_MenuPathBase + "About" + f_Diagonal;
  
        protected const string f_CORE_UI = f_CORE + "UI" + f_Diagonal;
        protected const string f_CORE_Skins = f_CORE + "Skins" + f_Diagonal;
        protected const string f_CORE_SM = f_CORE + "Scene Managment" + f_Diagonal;
        protected const string f_CORE_Utils = f_CORE + "Utils" + f_Diagonal;

        protected const string f_US_RC = f_US + "Remote Config" + f_Diagonal;
        protected const string f_US_RC_A = f_US_RC + "VRG_Announcement" + f_Diagonal;
        protected const string f_US_RC_B = f_US_RC + "BHEL";
        protected const string f_US_RC_D = f_US_RC + "DDUA" + f_Diagonal;
        protected const string f_US_A = f_US + "Analytics" + f_Diagonal;

        protected const string f_Examples_Core = f_Examples + "CORE" + f_Diagonal;
        protected const string f_Examples_RC = f_Examples + "Remote Config" + f_Diagonal;

        protected const string f_Examples_5s = f_Examples + "5 seconds" + f_Diagonal;
        protected const string f_Examples_Bhel = f_Examples + "BHEL" + f_Diagonal;
        protected const string f_Examples_DDuA = f_Examples + "DDuA" + f_Diagonal;
        protected const string f_Download = "Download the full version";





        protected const string m_1_1 = f_CORE + "Scene: Create new";                    protected const int p_1_1 = p_Next;
        protected const string m_2 = f_BHEL;                                            protected const int p_2 = p_1_1 + p_Raya;
        protected const string m_3 = f_DDUA;                                            protected const int p_3 = p_2 + p_Raya;
        protected const string m_4_1_1 = f_US_RC + "Add VRG_Remote Prefab";             protected const int p_4_1_1 = p_3 + p_Raya;
        protected const string m_5_1 = f_Examples + "Instructions to use examples";     protected const int p_5_1 = p_4_1_1 + p_Next;

        protected const string m_5_1_1 = f_Examples_Core + "Clear Build Settings from examples";     protected const int p_5_1_1 = p_5_1 + p_Raya;

        protected const string m_6_1 = f_About + "Installation path";                   protected const int p_6_1 = p_5_1 + p_Next;
       
       

        protected const string m_1_2 = f_CORE + "Game: Create new";                                     protected const int p_1_2 = p_1_1 + p_Next;

        protected const string m_1_3_1 = f_CORE_UI + "Main Camera: Feedback";                           protected const int p_1_3_1 = p_1_2 + p_Raya;
        protected const string m_1_3_2 = f_CORE_UI + "Html: (Header, Body, Footer)";                    protected const int p_1_3_2 = p_1_3_1 + p_Next;
        protected const string m_1_3_3 = f_CORE_UI + "PopUp: Default";                                  protected const int p_1_3_3 = p_1_3_2 + p_Next;
        protected const string m_1_3_4 = f_CORE_UI + "Button: "+ "Basic";                               protected const int p_1_3_4 = p_1_3_3 + p_Raya;
        protected const string m_1_3_5 = f_CORE_UI + "Button: " + "Icon";                               protected const int p_1_3_5 = p_1_3_4 + p_Next;
        protected const string m_1_3_6 = f_CORE_UI + "Button: " + "Label and Icon";                     protected const int p_1_3_6 = p_1_3_5 + p_Next;
        protected const string m_1_3_7 = f_CORE_UI + "Graphical Number: " + "Basic";                    protected const int p_1_3_7 = p_1_3_6 + p_Raya;
        protected const string m_1_3_8 = f_CORE_UI + "Graphical Number: " + "Animated";                 protected const int p_1_3_8 = p_1_3_7 + p_Next;
        protected const string m_1_3_9 = f_CORE_UI + "Graphical Number: " + "BackWard Countdown";       protected const int p_1_3_9 = p_1_3_8 + p_Next;

        protected const string m_1_4_1 = f_CORE_Skins + "UI Icon: "  + "VRG_SkinPool";                  protected const int p_1_4_1 = p_1_3_1 + p_Next;
        protected const string m_1_4_2 = f_CORE_Skins + "Add skin: "  + "Custom";                       protected const int p_1_4_2 = p_1_4_1 + p_Raya;
        protected const string m_1_4_3 = f_CORE_Skins + "Add skin: "  + "All";                          protected const int p_1_4_3 = p_1_4_2 + p_Next;
        protected const string m_1_4_4 = f_CORE_Skins + "Add skin: "  + "Elysium";                      protected const int p_1_4_4 = p_1_4_3 + p_Raya;
        protected const string m_1_4_5 = f_CORE_Skins + "Add skin: "  + "Gaia";                         protected const int p_1_4_5 = p_1_4_4 + p_Next;
        protected const string m_1_4_6 = f_CORE_Skins + "Add skin: "  + "Inferno";                      protected const int p_1_4_6 = p_1_4_5 + p_Next;
        protected const string m_1_4_7 = f_CORE_Skins + "Add skin: "  + "Limbo";                        protected const int p_1_4_7 = p_1_4_6 + p_Next;
        protected const string m_1_4_8 = f_CORE_Skins + "Add skin: "  + "Metropolis";                   protected const int p_1_4_8 = p_1_4_7 + p_Next;
        
        protected const string m_1_5_1 = f_CORE_SM + "VRG_GoToScene";                   protected const int p_1_5_1 = p_1_4_1 + p_Raya;
        protected const string m_1_5_2 = f_CORE_SM + "VRG_Managers";                    protected const int p_1_5_2 = p_1_5_1 + p_Next;

        protected const string m_1_6_1 = f_CORE_Utils + "VRG_SessionData";              protected const int p_1_6_1 = p_1_5_1 + p_Next;
        protected const string m_1_6_2 = f_CORE_Utils + "VRG_OpenUrl";                  protected const int p_1_6_2 = p_1_6_1 + p_Next;
        protected const string m_1_6_3 = f_CORE_Utils + "VRG_FPS: Frames Per Second";   protected const int p_1_6_3 = p_1_6_2 + p_Next;
 


        protected const string m_4_1_2 = f_US_RC + "REMOTE_CONFIG_INSTALLED: Add";      protected const int p_4_1_2 = p_4_1_1 + p_Raya;
        protected const string m_4_1_3 = f_US_RC + "REMOTE_CONFIG_INSTALLED: Remove";   protected const int p_4_1_3 = p_4_1_2 + p_Next;
        protected const string m_4_1_4_1 = f_US_RC_A + "Add preconfigured VRG_Remote";  protected const int p_4_1_4_1 = p_4_1_3 + p_Raya;
        protected const string m_4_1_4_2 = f_US_RC_A + "UI: Icon";                      protected const int p_4_1_4_2 = p_4_1_4_1 + p_Raya;
        protected const string m_4_1_4_3 = f_US_RC_A + "UI: PopUp window";              protected const int p_4_1_4_3 = p_4_1_4_2 + p_Next;
        protected const string m_4_1_5 = f_US_RC_B;                                     protected const int p_4_1_5 = p_4_1_4_3 + p_Raya;
        protected const string m_4_1_6_1 = f_US_RC_D + f_Download;                      protected const int p_4_1_6_1 = p_4_1_5 + p_Raya;

        protected const string m_4_2_1 = f_US_A + "UNITY_ANALYTICS_EVENT_LOGS: Add";    protected const int p_4_2_1 = p_4_1_1 + p_Next;
        protected const string m_4_2_2 = f_US_A + "UNITY_ANALYTICS_EVENT_LOGS: Remove"; protected const int p_4_2_2 = p_4_2_1 + p_Next;

        protected const string m_5_1_2 = f_Examples_Core + "00 Demo";                   protected const int p_5_1_2 = p_5_1_1 + p_Raya;
        protected const string m_5_1_3 = f_Examples_Core + "01 UI";                     protected const int p_5_1_3 = p_5_1_2 + p_Raya;
        protected const string m_5_1_4 = f_Examples_Core + "02 Graphical Numbers";      protected const int p_5_1_4 = p_5_1_3 + p_Next;
        protected const string m_5_1_5 = f_Examples_Core + "03 Camera And Fader";       protected const int p_5_1_5 = p_5_1_4 + p_Next;
        protected const string m_5_1_6 = f_Examples_Core + "04 Scene Managment";        protected const int p_5_1_6 = p_5_1_5 + p_Raya;
        protected const string m_5_1_7 = f_Examples_Core + "05 05 Sounds and music";    protected const int p_5_1_7 = p_5_1_6 + p_Next;
        protected const string m_5_1_8 = f_Examples_Core + "06 PopUp and Exit";         protected const int p_5_1_8 = p_5_1_7 + p_Next;
        protected const string m_5_1_9 = f_Examples_Core + "07 VRG_SessionData";        protected const int p_5_1_9 = p_5_1_8 + p_Raya;
        protected const string m_5_1_10 = f_Examples_Core + "08 VRG_SessionData UI";    protected const int p_5_1_10 = p_5_1_9 + p_Next;
        protected const string m_5_1_11 = f_Examples_Core + "09 Skins";                 protected const int p_5_1_11 = p_5_1_10 + p_Raya;

        protected const string m_5_2_1 = f_Examples_RC + "01 UI Text";                  protected const int p_5_2_1 = p_5_1_1 + p_Next;
        protected const string m_5_2_2 = f_Examples_RC + "02 A simple combat";          protected const int p_5_2_2 = p_5_2_1 + p_Next;
        protected const string m_5_2_3 = f_Examples_RC + "03 VRG_Announcement";         protected const int p_5_2_3 = p_5_2_2 + p_Next;

        protected const string m_5_3_1 = f_Examples_5s + "Game: Load scenes";           protected const int p_5_3_1 = p_5_2_1 + p_Next;
        protected const string m_5_3_2 = f_Examples_5s + "Game: Unload scenes";         protected const int p_5_3_2 = p_5_3_1 + p_Next;

        protected const string m_5_4_1 = f_Examples_Bhel + "VRG_BHEL: Create a Prefab demo";    protected const int p_5_4_1 = p_5_3_1 + p_Raya;
        protected const string m_5_4_2 = f_Examples_Bhel + "00 Bhel Demo";                      protected const int p_5_4_2 = p_5_4_1 + p_Raya;
        protected const string m_5_4_3 = f_Examples_Bhel + f_Download;                          protected const int p_5_4_3 = p_5_4_2 + p_Raya;


        protected const string m_5_5_1 = f_Examples_DDuA + f_Download;                  protected const int p_5_5_1 = p_5_4_1 + p_Raya;

        protected const string m_6_2 = f_About + "Us and this software";                protected const int p_6_2 = p_6_1 + p_Next;



    
    
    
    
    
    
    
        // [MenuItem(m_0_0, priority = p_0_0)]         public static void sfv_0_0() => VRG_Editor_Menu.menuFSM(p_0_0, m_0_0);
        [MenuItem(m_1_1, priority = p_1_1)]         public static void sfv_1_1() => VRG_Editor_CORE.menuFSM(p_1_1, m_1_1);
        [MenuItem(m_2, priority = p_2)]             public static void sfv_2() => VRG_Editor_BHEL.menuFSM(p_2, m_2);
        [MenuItem(m_3, priority = p_3)]             public static void sfv_3() => VRG_Editor_DDuA.menuFSM(p_3, m_3);
        [MenuItem(m_4_1_1, priority = p_4_1_1)]     public static void sfv_4_1_1() => VRG_Editor_VRG_Remote.menuFSM(p_4_1_1, m_4_1_1);
        [MenuItem(m_5_1, priority = p_5_1)]         public static void sfv_5_1() => VRG_Editor_CORE_Examples.menuFSM(p_5_1, m_5_1);
        [MenuItem(m_6_1, priority = p_6_1)]         public static void sfv_6_1() => VRG_Editor_AboutUs.menuFSM(p_6_1, m_6_1);


        [MenuItem(m_1_2, priority = p_1_2)]         public static void sfv_1_2() => VRG_Editor_CORE.menuFSM(p_1_2, m_1_2);
        
        [MenuItem(m_1_3_1, priority = p_1_3_1)]     public static void sfv_1_3_1() => VRG_Editor_CORE.menuFSM(p_1_3_1, m_1_3_1);
        [MenuItem(m_1_3_2, priority = p_1_3_2)]     public static void sfv_1_3_2() => VRG_Editor_CORE.menuFSM(p_1_3_2, m_1_3_2);
        [MenuItem(m_1_3_3, priority = p_1_3_3)]     public static void sfv_1_3_3() => VRG_Editor_CORE.menuFSM(p_1_3_3, m_1_3_3);
        [MenuItem(m_1_3_4, priority = p_1_3_4)]     public static void sfv_1_3_4() => VRG_Editor_CORE.menuFSM(p_1_3_4, m_1_3_4);
        [MenuItem(m_1_3_5, priority = p_1_3_5)]     public static void sfv_1_3_5() => VRG_Editor_CORE.menuFSM(p_1_3_5, m_1_3_5);
        [MenuItem(m_1_3_6, priority = p_1_3_6)]     public static void sfv_1_3_6() => VRG_Editor_CORE.menuFSM(p_1_3_6, m_1_3_6);
        [MenuItem(m_1_3_7, priority = p_1_3_7)]     public static void sfv_1_3_7() => VRG_Editor_CORE.menuFSM(p_1_3_7, m_1_3_7);
        [MenuItem(m_1_3_8, priority = p_1_3_8)]     public static void sfv_1_3_8() => VRG_Editor_CORE.menuFSM(p_1_3_8, m_1_3_8);
        [MenuItem(m_1_3_9, priority = p_1_3_9)]     public static void sfv_1_3_9() => VRG_Editor_CORE.menuFSM(p_1_3_9, m_1_3_9);

        [MenuItem(m_1_4_1, priority = p_1_4_1)]     public static void sfv_1_4_1() => VRG_Editor_CORE.menuFSM(p_1_4_1, m_1_4_1);
        [MenuItem(m_1_4_2, priority = p_1_4_2)]     public static void sfv_1_4_2() => VRG_Editor_CORE.menuFSM(p_1_4_2, m_1_4_2);
        [MenuItem(m_1_4_3, priority = p_1_4_3)]     public static void sfv_1_4_3() => VRG_Editor_CORE.menuFSM(p_1_4_3, m_1_4_3);
        [MenuItem(m_1_4_4, priority = p_1_4_4)]     public static void sfv_1_4_4() => VRG_Editor_CORE.menuFSM(p_1_4_4, m_1_4_4);
        [MenuItem(m_1_4_5, priority = p_1_4_5)]     public static void sfv_1_4_5() => VRG_Editor_CORE.menuFSM(p_1_4_5, m_1_4_5);
        [MenuItem(m_1_4_6, priority = p_1_4_6)]     public static void sfv_1_4_6() => VRG_Editor_CORE.menuFSM(p_1_4_6, m_1_4_6);
        [MenuItem(m_1_4_7, priority = p_1_4_7)]     public static void sfv_1_4_7() => VRG_Editor_CORE.menuFSM(p_1_4_7, m_1_4_7);
        [MenuItem(m_1_4_8, priority = p_1_4_8)]     public static void sfv_1_4_8() => VRG_Editor_CORE.menuFSM(p_1_4_8, m_1_4_8);

        [MenuItem(m_1_5_1, priority = p_1_5_1)]     public static void sfv_1_5_1() => VRG_Editor_CORE.menuFSM(p_1_5_1, m_1_5_1);
        [MenuItem(m_1_5_2, priority = p_1_5_2)]     public static void sfv_1_5_2() => VRG_Editor_CORE.menuFSM(p_1_5_2, m_1_5_2);
        
        [MenuItem(m_1_6_1, priority = p_1_6_1)]     public static void sfv_1_6_1() => VRG_Editor_CORE.menuFSM(p_1_6_1, m_1_6_1);
        [MenuItem(m_1_6_2, priority = p_1_6_2)]     public static void sfv_1_6_2() => VRG_Editor_CORE.menuFSM(p_1_6_2, m_1_6_2);
        [MenuItem(m_1_6_3, priority = p_1_6_3)]     public static void sfv_1_6_3() => VRG_Editor_CORE.menuFSM(p_1_6_3, m_1_6_3);
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
        [MenuItem(m_4_1_2, priority = p_4_1_2)]     public static void sfv_4_1_2() => VRG_Editor_VRG_Remote.menuFSM(p_4_1_2, m_4_1_2);
        [MenuItem(m_4_1_3, priority = p_4_1_3)]     public static void sfv_4_1_3() => VRG_Editor_VRG_Remote.menuFSM(p_4_1_3, m_4_1_3);
////////////////////////////////////////////////////////////
        [MenuItem(m_4_1_4_1, priority = p_4_1_4_1)] public static void sfv_4_1_4_1() => VRG_Editor_VRG_Remote.menuFSM(p_4_1_4_1, m_4_1_4_1);
        [MenuItem(m_4_1_4_2, priority = p_4_1_4_2)] public static void sfv_4_1_4_2() => VRG_Editor_VRG_Remote.menuFSM(p_4_1_4_2, m_4_1_4_2);
        [MenuItem(m_4_1_4_3, priority = p_4_1_4_3)] public static void sfv_4_1_4_3() => VRG_Editor_VRG_Remote.menuFSM(p_4_1_4_3, m_4_1_4_3);
        [MenuItem(m_4_1_5, priority = p_4_1_5)] public static void sfv_4_1_5_1() => VRG_Editor_BHEL_VRG_Remote.menuFSM(p_4_1_5, m_4_1_5);
        [MenuItem(m_4_1_6_1, priority = p_4_1_6_1)] public static void sfv_4_1_6_1() => VRG_Editor_DDuA_VRG_Remote.menuFSM(p_4_1_6_1, m_4_1_6_1);
////////////////////////////////////////////////////////////
        [MenuItem(m_4_2_1, priority = p_4_2_1)]     public static void sfv_4_2_1() => VRG_Editor_Analytics.menuFSM(p_4_2_1, m_4_2_1);
        [MenuItem(m_4_2_2, priority = p_4_2_2)]     public static void sfv_4_2_2() => VRG_Editor_Analytics.menuFSM(p_4_2_2, m_4_2_2);
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
        [MenuItem(m_5_1_1, priority = p_5_1_1)]     public static void sfv_5_1_1() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_1, m_5_1_1);
        [MenuItem(m_5_1_2, priority = p_5_1_2)]     public static void sfv_5_1_2() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_2, m_5_1_2);
        [MenuItem(m_5_1_3, priority = p_5_1_3)]     public static void sfv_5_1_3() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_3, m_5_1_3);
        [MenuItem(m_5_1_4, priority = p_5_1_4)]     public static void sfv_5_1_4() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_4, m_5_1_4);
        [MenuItem(m_5_1_5, priority = p_5_1_5)]     public static void sfv_5_1_5() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_5, m_5_1_5);
        [MenuItem(m_5_1_6, priority = p_5_1_6)]     public static void sfv_5_1_6() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_6, m_5_1_6);
        [MenuItem(m_5_1_7, priority = p_5_1_7)]     public static void sfv_5_1_7() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_7, m_5_1_7);
        [MenuItem(m_5_1_8, priority = p_5_1_8)]     public static void sfv_5_1_8() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_8, m_5_1_8);
        [MenuItem(m_5_1_9, priority = p_5_1_9)]     public static void sfv_5_1_9() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_9, m_5_1_9);
        [MenuItem(m_5_1_10, priority = p_5_1_10)]   public static void sfv_5_1_10() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_10, m_5_1_10);
        [MenuItem(m_5_1_11, priority = p_5_1_11)]   public static void sfv_5_1_11() => VRG_Editor_CORE_Examples.menuFSM(p_5_1_11, m_5_1_11);
////////////////////////////////////////////////////////////
        [MenuItem(m_5_2_1, priority = p_5_2_1)]     public static void sfv_5_2_1() => VRG_Editor_CORE_VRG_Remote_Examples.menuFSM(p_5_2_1, m_5_2_1);
        [MenuItem(m_5_2_2, priority = p_5_2_2)]     public static void sfv_5_2_2() => VRG_Editor_CORE_VRG_Remote_Examples.menuFSM(p_5_2_2, m_5_2_2);
        [MenuItem(m_5_2_3, priority = p_5_2_3)]     public static void sfv_5_2_3() => VRG_Editor_CORE_VRG_Remote_Examples.menuFSM(p_5_2_3, m_5_2_3);
////////////////////////////////////////////////////////////
        [MenuItem(m_5_3_1, priority = p_5_3_1)]     public static void sfv_5_3_1() => VRG_Editor_CORE_5Seconds.menuFSM(p_5_3_1, m_5_3_1);
        [MenuItem(m_5_3_2, priority = p_5_3_2)]     public static void sfv_5_3_2() => VRG_Editor_CORE_5Seconds.menuFSM(p_5_3_2, m_5_3_2);
////////////////////////////////////////////////////////////
        [MenuItem(m_5_4_1, priority = p_5_4_1)]     public static void sfv_5_4_1() => VRG_Editor_BHEL_Examples.menuFSM(p_5_4_1, m_5_4_1);
        [MenuItem(m_5_4_2, priority = p_5_4_2)]     public static void sfv_5_4_2() => VRG_Editor_BHEL_Examples.menuFSM(p_5_4_2, m_5_4_2);
        [MenuItem(m_5_4_3, priority = p_5_4_3)]     public static void sfv_5_4_3() => VRG_Editor_BHEL_Examples.menuFSM(p_5_4_3, m_5_4_3);
////////////////////////////////////////////////////////////
        [MenuItem(m_5_5_1, priority = p_5_5_1)]     public static void sfv_5_5_1() => VRG_Editor_DDuA_Examples.menuFSM(p_5_5_1, m_5_5_1);              
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
        [MenuItem(m_6_2, priority = p_6_2)]         public static void sfv_6_2() => VRG_Editor_AboutUs.menuFSM(p_6_2, m_6_2);
////////////////////////////////////////////////////////////

        protected static void menuFSM(int indexLocal, string pathLocal)
        {
            print(indexLocal + " | " + pathLocal);
        }
    }
}
/*






        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (pathLocal)
            {
                // textOfTheFirst
                case "1111":
                break;

                // textOfTheSecond
                case "2222":
                break;

                default:
                    VRG_Editor_Menu.menuFSM(indexLocal, "CLASS: " + pathLocal);
                break;                
            }
        }






        
*/