using HarmonyLib;

using UnityEngine;
using UnityEngine.UI;

namespace PC_ScrollableUI
{
    public static class Hooks
    {
        [HarmonyPostfix, HarmonyPatch(typeof(SelectScene), "Start")]
        private static void SelectScene_Start_ScrollableMaps()
        {
            var map = GameObject.Find("Select_UI/RightUp/MAP");
            var list = map.transform.Find("VerticalToggles");

            var ScrollView = new GameObject("ScrollView", typeof(RectTransform));
            ScrollView.transform.SetParent(map.transform, false);

            var svScrollRect = ScrollView.AddComponent<ScrollRect>();
            
            var ViewPort = new GameObject("ViewPort", typeof(RectTransform));
            ViewPort.transform.SetParent(ScrollView.transform, false);
            ViewPort.AddComponent<Mask>();
            
            var vpRectTransform = ViewPort.GetComponent<RectTransform>();

            var vpImg = ViewPort.AddComponent<Image>();
            vpImg.color = new Color(1, 1, 1, 0.015f);

            list.SetParent(ViewPort.transform, false);

            var listRect = list.gameObject.GetComponent<RectTransform>();
            svScrollRect.content = listRect;
            svScrollRect.horizontal = false;
            svScrollRect.scrollSensitivity = 20;
            
            var fitter = list.gameObject.AddComponent<ContentSizeFitter>();
            fitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            
            var svRect = ScrollView.gameObject.GetComponent<RectTransform>();
            svRect.offsetMin = new Vector2(-50, -352);
            svRect.offsetMax = new Vector2(50, -24);
            
            vpRectTransform.offsetMin = new Vector2(-55, -164);
            vpRectTransform.offsetMax = new Vector2(55, 164);
        }

        [HarmonyPostfix, HarmonyPatch(typeof(H_MapChange), "Start")]
        private static void H_MapChange_Start_ScrollableMaps()
        {
            var map = GameObject.Find("H_UI_Canvas/RightUpUI/Edits/EditStep2");
            var list = map.transform.Find("MapList");

            var ScrollView = new GameObject("ScrollView", typeof(RectTransform));
            ScrollView.transform.SetParent(map.transform, false);

            var svScrollRect = ScrollView.AddComponent<ScrollRect>();
            
            var ViewPort = new GameObject("ViewPort", typeof(RectTransform));
            ViewPort.transform.SetParent(ScrollView.transform, false);
            ViewPort.AddComponent<Mask>();

            var vpRectTransform = ViewPort.GetComponent<RectTransform>();

            var vpImg = ViewPort.AddComponent<Image>();
            vpImg.color = new Color(1, 1, 1, 0.015f);

            list.SetParent(ViewPort.transform, false);

            var listRect = list.gameObject.GetComponent<RectTransform>();
            svScrollRect.content = listRect;
            svScrollRect.horizontal = false;
            svScrollRect.scrollSensitivity = 20;
            
            var fitter = list.gameObject.AddComponent<ContentSizeFitter>();
            fitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            
            var svRect = ScrollView.gameObject.GetComponent<RectTransform>();
            svRect.offsetMin = new Vector2(45, -215);
            svRect.offsetMax = new Vector2(145, 111);
            
            vpRectTransform.offsetMin = new Vector2(-40, -163);
            vpRectTransform.offsetMax = new Vector2(40, 163);
            
            list.localPosition = new Vector3(40, list.localPosition.y, 0);

            foreach (Transform child in list.transform)
                child.localScale = new Vector3(1, 1, 1);

            list.GetComponent<VerticalLayoutGroup>().spacing = 5;
        }
    }
}