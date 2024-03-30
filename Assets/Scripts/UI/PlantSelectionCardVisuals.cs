using UnityEngine;
using Nova;

namespace PVZ.UI
{
    public class PlantSelectionCardVisuals : ItemVisuals
    {
        public UIBlock2D Image;
        public UIBlock2D Panel;
        public TextBlock Cost;

        public Color DefaultColor;
        public Color HoveredColor;
        public Color PressedColor;

        public static void HandleHover(Gesture.OnHover evt, PlantSelectionCardVisuals target)
        {
            target.Panel.Color = target.HoveredColor;
        }

        public static void HandlePress(Gesture.OnPress evt, PlantSelectionCardVisuals target)
        {
            target.Panel.Color = target.PressedColor;
        }

        public static void HandleRelease(Gesture.OnRelease evt, PlantSelectionCardVisuals target)
        {
            target.Panel.Color = target.DefaultColor;
        }

        public static void HandleUnhover(Gesture.OnUnhover evt, PlantSelectionCardVisuals target)
        {
            target.Panel.Color = target.DefaultColor;
        }
    }
}
