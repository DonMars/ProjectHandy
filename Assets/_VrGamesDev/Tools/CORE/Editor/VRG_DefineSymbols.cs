using System.Collections.Generic;
using System.Linq;
using UnityEditor;

/// ///////////////////////////////////////////////////////////////////////////
/// 
/// This class is an editor tool that facilitates the management of compilation 
/// define symbols in Unity, making it easier to programmatically add, remove, 
/// and clear these symbols. Compilation define symbols are useful for controlling 
/// compiler features and code flow at compile time based on certain conditions.
/// 
/// It is used to add the "ADD remote Installed"
/// 
/// ///////////////////////////////////////////////////////////////////////////

// Defines the namespace for VRG's custom editor tools
namespace VrGamesDev.Editor
{
    // Static class for managing Unity's compilation define symbols
    public static class VRG_DefineSymbols
    {
        // Character used to separate define symbols in the define symbols string
        private const char DEFINE_SEPARATOR = ';';

        // Stores all current define symbols for the editor session
        private static readonly List<string> _allDefines = new List<string>();

        // Adds new define symbols, avoiding duplicates
        public static void Add(params string[] defines)
        {
            // Clears the current list and loads existing define symbols
            _allDefines.Clear();
            _allDefines.AddRange(GetDefines());
            // Adds new symbols, excluding those that already exist
            _allDefines.AddRange(defines.Except(_allDefines));
            // Updates the define symbols in the project settings
            UpdateDefines(_allDefines);
        }

        // Removes specific define symbols
        public static void Remove(params string[] defines)
        {
            // Clears the current list and reloads, excluding specified symbols to be removed
            _allDefines.Clear();
            _allDefines.AddRange(GetDefines().Except(defines));
            // Updates the define symbols in the project settings
            UpdateDefines(_allDefines);
        }

        // Clears all define symbols
        public static void Clear()
        {
            _allDefines.Clear();
            // Updates the define symbols to reflect they are now empty
            UpdateDefines(_allDefines);
        }

        // Retrieves the current define symbols as a list of strings
        private static IEnumerable<string> GetDefines()
        {
            IEnumerable<string> defineSymbolsString = PlayerSettings.GetScriptingDefineSymbols
            (
                UnityEditor.Build.NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup)
            ).Split(DEFINE_SEPARATOR).ToList();

            return defineSymbolsString;
        }

        // Updates the define symbols in Unity's project settings
        private static void UpdateDefines(List<string> allDefines)
        {
            PlayerSettings.SetScriptingDefineSymbols
            (
                UnityEditor.Build.NamedBuildTarget.FromBuildTargetGroup
                (
                    EditorUserBuildSettings.selectedBuildTargetGroup),
                    string.Join(DEFINE_SEPARATOR.ToString(),
                    allDefines.ToArray()
                )
            );
        }
    }
}