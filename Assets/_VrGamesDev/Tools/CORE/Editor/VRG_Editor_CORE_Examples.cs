using UnityEditor;
using UnityEditor.SceneManagement;

///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_CORE_Examples : VRG_Editor_Menu
    {
        private static string m_ExamplesFolder = "CORE/Examples/Scenes/";

        public new static void menuFSM(int indexLocal, string pathLocal)
        {

            RemoveScenesFromoBuildSettings(new string[]
            {
                m_ExamplesFolder + "04 Scene Managment/" + "04 Scenes managment 1",
                m_ExamplesFolder + "04 Scene Managment/" + "04 Scenes managment 2"
            });

            switch (indexLocal)
            {
                // Examples/Instructions to use examples
                case p_5_1:
                    if (EditorUtility.DisplayDialog
                    (
                        "Vr Games Dev Examples", 
                        "This module has the capability to add or edit scenes in the build settings.\n"+
                        "Additionally, it may relocate assets into the addressables groups.\n"+
                        "Remember to save your current work before loading any examples.",
                        "Yes, I got it", 
                        "No"
                       )
                    )
                    {
                    }
                    break;

                // Examples/CORE/Clear Build Settings from examples
                case p_5_1_1:
                    EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);

                    print("Build Settings from CORE exmaples: Cleared ");
                    break;

                // Examples/CORE/00 Demo
                case p_5_1_2: LoadScene(m_ExamplesFolder + "00 Demo"); break;

                // Examples/CORE/01
                case p_5_1_3: LoadScene(m_ExamplesFolder + "01 UI"); break;

                // Examples/CORE/02
                case p_5_1_4: LoadScene(m_ExamplesFolder + "02 Graphical Numbers"); break;

                // Examples/CORE/03
                case p_5_1_5: LoadScene(m_ExamplesFolder + "03 Camera And Fader"); break;

                // Examples/CORE/04
                case p_5_1_6:
                    LoadScene(m_ExamplesFolder + "04 Scene Managment");

                    AddScenesToBuildSettings(new string[]
                    {
                        m_ExamplesFolder + "04 Scene Managment/" + "04 Scenes managment 1",
                        m_ExamplesFolder + "04 Scene Managment/" + "04 Scenes managment 2"
                    }, false);
                    break;

                // Examples/CORE/05
                case p_5_1_7: LoadScene(m_ExamplesFolder + "05 Sounds and music"); break;

                // Examples/CORE/06
                case p_5_1_8: LoadScene(m_ExamplesFolder + "06 PopUp and Exit"); break;

                // Examples/CORE/07
                case p_5_1_9: LoadScene(m_ExamplesFolder + "07 VRG_SessionData"); break;

                // Examples/CORE/08
                case p_5_1_10: LoadScene(m_ExamplesFolder + "08 VRG_SessionData UI"); break;

                // Examples/CORE/09
                case p_5_1_11: LoadScene(m_ExamplesFolder + "09 Skins"); break;


                default:
                    VRG_Editor_Menu.menuFSM(indexLocal, pathLocal);
                    break;
            }
        }
    }
}