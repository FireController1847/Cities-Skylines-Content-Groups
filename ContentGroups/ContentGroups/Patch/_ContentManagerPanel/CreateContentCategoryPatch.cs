using ColossalFramework.UI;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ContentGroups.Patch._ContentManagerPanel {
    [HarmonyPatch(typeof(ContentManagerPanel))]
    [HarmonyPatch("CreateCategories")]
    public class CreateContentCategoryPatch {
        public static void Postfix(ContentManagerPanel __instance, UIListBox ___m_Categories, UITabContainer ___m_CategoriesContainer, UIComponent ___m_ModsContainer) {
            Debug.Log("Create Categories!");

            var handler = (PropertyChangedEventHandler<int>) Delegate.CreateDelegate(typeof(PropertyChangedEventHandler<int>), __instance, "OnCategoryChanged");
            ___m_Categories.eventSelectedIndexChanged -= handler;
            ___m_Categories.selectedIndex = -1;

            // Manually Insert Category
            // TODO: Cleanup!
            UIComponent container;
            List<string> list = (___m_Categories.items == null) ? new List<string>() : new List<string>(___m_Categories.items);
            list.Insert(list.Count - 2, "GROUPS");
            container = ___m_CategoriesContainer.AddUIComponent<UIPanel>();
            container.zOrder = list.Count - 3;
            ___m_Categories.items = list.ToArray();
            ___m_Categories.filteredItems = new int[1] {
                10
            };

            ___m_Categories.eventSelectedIndexChanged += handler;
            ___m_Categories.selectedIndex = 0;
        }
    }
}
