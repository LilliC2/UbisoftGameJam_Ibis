using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Poiyomi.ModularShaderSystem;
using Poiyomi.ModularShaderSystem.CibbiExtensions;
using System.Linq;
using System.IO;

namespace Poi.Tools
{
    public class PoiModulesToggles : EditorWindow
    {
        private static ModuleCollection proCollection;
        private static ModuleCollection freeCollection;
        private Vector2 scrollPosition;
        private Color disabledColour = new Color(1.0f, 0.25f, 0.25f);
        private Color enabledColour = new Color(0.75f, 1.0f, 0.75f);

        const string SettingsFileName = "PoiModulesTogglesSettings.json";

        private static PoiModulesTogglesSettings _moduleSettings;
        public static PoiModulesTogglesSettings moduleSettings
        {
            get
            {
                if (_moduleSettings == null)
                {
                    if(PoiSettingsUtility.TryLoadSettings(SettingsFileName, out _moduleSettings))
                    {
                        _moduleSettings.proShaderModules = _moduleSettings.proShaderModulesInternal.Select(x => AssetDatabase.GUIDToAssetPath(x)).Select(x => AssetDatabase.LoadAssetAtPath<ShaderModule>(x)).ToArray();
                        _moduleSettings.freeShaderModules = _moduleSettings.freeShaderModulesInternal.Select(x => AssetDatabase.GUIDToAssetPath(x)).Select(x => AssetDatabase.LoadAssetAtPath<ShaderModule>(x)).ToArray();
                    }
                    else
                    {
                        _moduleSettings = System.Activator.CreateInstance<PoiModulesTogglesSettings>();
                        PoiSettingsUtility.SaveSettings(SettingsFileName, _moduleSettings, true);
                    }
                }
                return _moduleSettings;
            }
        }
        public static void SaveModuleSettings()
        {
            moduleSettings.proShaderModulesInternal = moduleSettings.proShaderModules.Where(x => x != null).Select(x => AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(x))).ToArray();
            moduleSettings.freeShaderModulesInternal = moduleSettings.freeShaderModules.Where(x => x != null).Select(x => AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(x))).ToArray();
            PoiSettingsUtility.SaveSettings(SettingsFileName, moduleSettings);
        }

        static readonly HashSet<string> ignoreList = new HashSet<string> {
            "PoiOutline",
        };

        [MenuItem("Poi/Modules Toggles")]
        static void OpenWindow()
        {
            Init();
            var w = GetWindow<PoiModulesToggles>();
            w.titleContent = new GUIContent("Poi Modules Toggles");
            w.Show();
        }
        public static void Init()
        {
            if (moduleSettings == null)
            {
                Debug.LogError("PoiModulesTogglesSettingsObject not found! Please report this to the Discord!");
                return;
            }

            proCollection = AssetDatabase.LoadAssetAtPath<ModuleCollection>(AssetDatabase.GUIDToAssetPath("ad791073d336f844e99f50c99b1c8641"));
            freeCollection = AssetDatabase.LoadAssetAtPath<ModuleCollection>(AssetDatabase.GUIDToAssetPath("496d9ada176c1a64c8d6e75b0ae824c1"));
            if (proCollection == null || freeCollection == null)
            {
                Debug.LogError("proCollection or freeCollection not found! Please report this to the Discord!");
                return;
            }

            if (moduleSettings.proShaderModules == null)
            {
                moduleSettings.proShaderModules = new ShaderModule[0];
                moduleSettings.proShaderModulesEnabled = new bool[0];
            }
            if (moduleSettings.freeShaderModules == null)
            {
                moduleSettings.freeShaderModules = new ShaderModule[0];
                moduleSettings.freeShaderModulesEnabled = new bool[0];
            }

            void ModuleCheck(ref ModuleCollection moduleCollection, ref ShaderModule[] moduleArray, ref bool[] boolArray)
            {
                for (int i = 0; i < moduleArray.Length; i++)
                {
                    if (!moduleCollection.Modules.Contains(moduleArray[i]) || ignoreList.Contains(moduleArray[i].Id))
                    {
                        ArrayUtility.RemoveAt(ref moduleArray, i);
                        ArrayUtility.RemoveAt(ref boolArray, i);
                    }
                }
                foreach (var item in moduleCollection.Modules.Where(x => x.GetType() != typeof(ModuleCollection)))
                {
                    if (ignoreList.Contains(item.Id)) continue;
                    if (!moduleArray.Contains(item))
                    {
                        ArrayUtility.Add(ref moduleArray, item);
                        ArrayUtility.Add(ref boolArray, true);
                    }
                }
            }

            ModuleCheck(ref proCollection, ref moduleSettings.proShaderModules, ref moduleSettings.proShaderModulesEnabled);
            ModuleCheck(ref freeCollection, ref moduleSettings.freeShaderModules, ref moduleSettings.freeShaderModulesEnabled);

            // EditorUtility.SetDirty(moduleSettings);
            // AssetDatabase.SaveAssets();
            SaveModuleSettings();
        }
        static void ReAddIgnoredModules(ref ModuleCollection customCollection, ref ModuleCollection moduleCollection)
        {
            foreach (var item in moduleCollection.Modules)
            {
                if (ignoreList.Contains(item.Id))
                {
                    customCollection.Modules.Add(item);
                }
            }
        }
        void OnGUI()
        {
            void DisplayToggle(ref ShaderModule[] moduleArray, ref bool[] boolArray, int index)
            {
                string toggleLabel = moduleArray[index].Name;
                if (string.IsNullOrEmpty(toggleLabel)) toggleLabel = moduleArray[index].Id;
                Color backgroundColour = GUI.backgroundColor;
                GUI.backgroundColor = boolArray[index] ? enabledColour : disabledColour;
                EditorGUI.BeginChangeCheck();
                bool tempBool = EditorGUILayout.ToggleLeft(toggleLabel, boolArray[index]);
                GUI.backgroundColor = backgroundColour;
                if (EditorGUI.EndChangeCheck())
                {
                    boolArray[index] = tempBool;
                    SaveModuleSettings();
                }
            }
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            for (int i = 0; i < moduleSettings.proShaderModules.Length; i++)
            {
                DisplayToggle(ref moduleSettings.proShaderModules, ref moduleSettings.proShaderModulesEnabled, i);
            }
            for (int i = 0; i < moduleSettings.freeShaderModules.Length; i++)
            {
                DisplayToggle(ref moduleSettings.freeShaderModules, ref moduleSettings.freeShaderModulesEnabled, i);
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.BeginHorizontal();
            bool apply = GUILayout.Button("Apply");
            bool revert = GUILayout.Button("Revert");
            EditorGUILayout.EndHorizontal();
            if (apply)
            {
                apply = EditorUtility.DisplayDialog("Poi Module Toggles", "This will regeneate the latest Poiyomi shaders and might take a long time, do you wish to continue?", "Yes", "No");
                if (apply)
                {
                    Apply();
                }
            }
            if (revert)
            {
                revert = EditorUtility.DisplayDialog("Poi Module Toggles", "This will regeneate the latest Poiyomi shaders and might take a long time, do you wish to continue?", "Yes", "No");
                if (revert)
                {
                    Revert();
                }
            }
        }
        public static bool IsModified()
        {
            var moduleCollections = AssetDatabase.FindAssets($"t:{nameof(ModuleCollection)}")
                                                 .Select(x => AssetDatabase.GUIDToAssetPath(x))
                                                 .Select(x => AssetDatabase.LoadAssetAtPath<ModuleCollection>(x));
            var proCustomCollection = moduleCollections.FirstOrDefault(x => x.Id == "ModuleCollectionProCustomEdited");
            var freeCustomCollection = moduleCollections.FirstOrDefault(x => x.Id == "ModuleCollectionFreeCustomEdited");
            if (proCustomCollection == null && freeCustomCollection == null) return false;
            var modularShaders = AssetDatabase.FindAssets($"t:{nameof(ModularShader)}")
                                              .Select(x => AssetDatabase.GUIDToAssetPath(x))
                                              .Select(x => AssetDatabase.LoadAssetAtPath<ModularShader>(x));
            foreach (var modularShader in modularShaders)
            {
                for (int i = 0; i < modularShader.BaseModules.Count; i++)
                {
                    if (modularShader.BaseModules[i] == proCustomCollection)
                    {
                        return true;
                    }
                    if (modularShader.BaseModules[i] == freeCustomCollection)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static void Apply(bool skipDialog = false)
        {
            var moduleCollections = AssetDatabase.FindAssets($"t:{nameof(ModuleCollection)}")
                                                 .Select(x => AssetDatabase.GUIDToAssetPath(x))
                                                 .Select(x => AssetDatabase.LoadAssetAtPath<ModuleCollection>(x));
            var proCustomCollection = moduleCollections.FirstOrDefault(x => x.Id == "ModuleCollectionProCustomEdited");
            var freeCustomCollection = moduleCollections.FirstOrDefault(x => x.Id == "ModuleCollectionFreeCustomEdited");
            string dir = System.IO.Path.GetDirectoryName(AssetDatabase.GetAssetPath(proCollection));
            if (proCustomCollection == null)
            {
                proCustomCollection = ScriptableObject.CreateInstance<ModuleCollection>();
                proCustomCollection.Id = "ModuleCollectionProCustomEdited";
                string proCCPath = System.IO.Path.Combine(dir, "ModuleCollectionProCustomEdited.asset");
                AssetDatabase.CreateAsset(proCustomCollection, proCCPath);
                AssetDatabase.ImportAsset(proCCPath);
            }
            if (freeCustomCollection == null)
            {
                freeCustomCollection = ScriptableObject.CreateInstance<ModuleCollection>();
                freeCustomCollection.Id = "ModuleCollectionFreeCustomEdited";
                string freeCCPath = System.IO.Path.Combine(dir, "ModuleCollectionFreeCustomEdited.asset");
                AssetDatabase.CreateAsset(freeCustomCollection, freeCCPath);
                AssetDatabase.ImportAsset(freeCCPath);
            }
            proCustomCollection.Modules = new List<ShaderModule>();
            freeCustomCollection.Modules = new List<ShaderModule>();
            proCustomCollection.Modules.Add(freeCustomCollection);
            ReAddIgnoredModules(ref proCustomCollection, ref proCollection);
            ReAddIgnoredModules(ref freeCustomCollection, ref freeCollection);
            for (int i = 0; i < moduleSettings.proShaderModules.Length; i++)
            {
                if (moduleSettings.proShaderModulesEnabled[i])
                {
                    proCustomCollection.Modules.Add(moduleSettings.proShaderModules[i]);
                }
            }
            for (int i = 0; i < moduleSettings.freeShaderModules.Length; i++)
            {
                if (moduleSettings.freeShaderModulesEnabled[i])
                {
                    freeCustomCollection.Modules.Add(moduleSettings.freeShaderModules[i]);
                }
            }
            EditorUtility.SetDirty(proCustomCollection);
            EditorUtility.SetDirty(freeCustomCollection);
            var modularShaders = AssetDatabase.FindAssets($"t:{nameof(ModularShader)}")
                                              .Select(x => AssetDatabase.GUIDToAssetPath(x))
                                              .Select(x => AssetDatabase.LoadAssetAtPath<ModularShader>(x));
            List<ModularShader> modifiedShaders = new List<ModularShader>();
            foreach (var modularShader in modularShaders)
            {
                for (int i = 0; i < modularShader.BaseModules.Count; i++)
                {
                    if (modularShader.BaseModules[i] == proCollection)
                    {
                        modularShader.BaseModules[i] = proCustomCollection;
                        modifiedShaders.Add(modularShader);
                        EditorUtility.SetDirty(modularShader);
                    }
                    if (modularShader.BaseModules[i] == freeCollection)
                    {
                        modularShader.BaseModules[i] = freeCustomCollection;
                        modifiedShaders.Add(modularShader);
                        EditorUtility.SetDirty(modularShader);
                    }
                    if (modularShader.BaseModules[i] == proCustomCollection || modularShader.BaseModules[i] == freeCustomCollection)
                    {
                        modifiedShaders.Add(modularShader);
                    }
                }
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            try
            {
                AssetDatabase.StartAssetEditing();
                for (int i = 0; i < modifiedShaders.Count; i++)
                {
                    EditorUtility.DisplayProgressBar("Poi Module Toggle, Generating", $"Generating {modifiedShaders[i].Name}", i / (float)modifiedShaders.Count);
                    ShaderGenerator.GenerateShader(ModularShadersGeneratorWindow._folderPath, modifiedShaders[i]);
                }
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
                Thry.ShaderEditor.ReloadActive();
                EditorUtility.ClearProgressBar();
            }
            if (!skipDialog) EditorUtility.DisplayDialog("Poi Modules Toggles", "Shader Generation successful!", "Ok");
        }
        public static void Revert(bool skipDialog = false)
        {
            var moduleCollections = AssetDatabase.FindAssets($"t:{nameof(ModuleCollection)}")
                                                 .Select(x => AssetDatabase.GUIDToAssetPath(x))
                                                 .Select(x => AssetDatabase.LoadAssetAtPath<ModuleCollection>(x));
            var proCustomCollection = moduleCollections.FirstOrDefault(x => x.Id == "ModuleCollectionProCustomEdited");
            var freeCustomCollection = moduleCollections.FirstOrDefault(x => x.Id == "ModuleCollectionFreeCustomEdited");
            if (proCustomCollection == null)
            {
                Debug.LogError("Custom Pro Collections not found! Please report this to the Discord!");
                return;
            }
            if (freeCustomCollection == null)
            {
                Debug.LogError("Custom Free Collections not found! Please report this to the Discord!");
                return;
            }
            var modularShaders = AssetDatabase.FindAssets($"t:{nameof(ModularShader)}")
                                              .Select(x => AssetDatabase.GUIDToAssetPath(x))
                                              .Select(x => AssetDatabase.LoadAssetAtPath<ModularShader>(x));
            List<ModularShader> modifiedShaders = new List<ModularShader>();
            foreach (var modularShader in modularShaders)
            {
                for (int i = 0; i < modularShader.BaseModules.Count; i++)
                {
                    if (modularShader.BaseModules[i] == proCustomCollection)
                    {
                        modularShader.BaseModules[i] = proCollection;
                        modifiedShaders.Add(modularShader);
                        EditorUtility.SetDirty(modularShader);
                    }
                    if (modularShader.BaseModules[i] == freeCustomCollection)
                    {
                        modularShader.BaseModules[i] = freeCollection;
                        modifiedShaders.Add(modularShader);
                        EditorUtility.SetDirty(modularShader);
                    }
                }
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            try
            {
                for (int i = 0; i < modifiedShaders.Count; i++)
                {
                    EditorUtility.DisplayProgressBar("Poi Module Toggle, Generating", $"Generating {modifiedShaders[i].Name}", i / (float)modifiedShaders.Count);
                    ShaderGenerator.GenerateShader(ModularShadersGeneratorWindow._folderPath, modifiedShaders[i]);
                }
            }
            finally
            {
                Thry.ShaderEditor.ReloadActive();
                EditorUtility.ClearProgressBar();
            }
            if (!skipDialog) EditorUtility.DisplayDialog("Poi Modules Toggles", "Revert successful!", "Ok");
        }
    }
}
