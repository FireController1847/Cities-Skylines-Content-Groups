using Harmony;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ContentGroups {
    public class ContentGroups : LoadingExtensionBase, IUserMod {
        private const string NAME = "Content Groups";
        private const string VERSION = "1.0.0";
        private const string DESCRIPTION = "Manage your workshop content right inside the content manager!";
        private const string HARMONY_ID = "com.github.firecontroller1847.contentgroups";

        public string Name => $"{NAME} v{VERSION}";
        public string Description => DESCRIPTION;
        public HarmonyInstance Harmony { get; private set; }

        public void OnEnabled() {
            Debug.Log($"{NAME} v{VERSION} Enabled!");

            Harmony = HarmonyInstance.Create(HARMONY_ID);
            Harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void OnDisabled() {
            Debug.Log($"{NAME} v{VERSION} Disabled!");

            Harmony.UnpatchAll(HARMONY_ID);
        }

        public override void OnCreated(ILoading loading) {
            Debug.Log("Created 1!");
            base.OnCreated(loading);
            Debug.Log("Created 2!");

            Harmony = HarmonyInstance.Create(HARMONY_ID);
            Harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
