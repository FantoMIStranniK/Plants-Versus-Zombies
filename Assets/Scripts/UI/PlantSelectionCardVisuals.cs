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

        internal static void HandleHover(Gesture.OnHover evt, PlantSelectionCardVisuals target)
        {
            target.Panel.Color = target.HoveredColor;
        }

        internal static void HandlePress(Gesture.OnPress evt, PlantSelectionCardVisuals target)
        {
            target.Panel.Color = target.PressedColor;
        }

        internal static void HandleRelease(Gesture.OnRelease evt, PlantSelectionCardVisuals target)
        {
            target.Panel.Color = target.DefaultColor;
        }

        internal static void HandleUnhover(Gesture.OnUnhover evt, PlantSelectionCardVisuals target)
        {
            target.Panel.Color = target.DefaultColor;
        }
    }
}
