using UnityEditor.SceneManagement;

///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_CORE_5Seconds : VRG_Editor_Menu
    {
        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (indexLocal)
            {
                // Examples/5 seconds/Game: Load scenes
                case p_5_3_1:                        
                    AddScenesToBuildSettings(new string[]
                    {
                        "5 Seconds/Scenes/" + "Home",
                        "5 Seconds/Scenes/" + "VRG_Managers",
                        "5 Seconds/Scenes/" + "Campaign"
                    });

                    LoadScene("5 Seconds/Scenes/Home");
                break;

                // Examples/5 seconds/Game: Unload scenes
                case p_5_3_2:
                    EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);

                    RemoveScenesFromoBuildSettings(new string[]
                    {
                        "5 Seconds/Scenes/" + "Home",
                        "5 Seconds/Scenes/" + "VRG_Managers",
                        "5 Seconds/Scenes/" + "Campaign"
                    });
                break;
                
                default:
                    VRG_Editor_Menu.menuFSM(indexLocal, pathLocal);
                break;
            }
        }
    }
}