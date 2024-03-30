using Nova;

namespace PVZ.UI
{
    public class PlantSelectionMenuVisuals : ItemVisuals
    {
        public PositionAnimation HoverAnimation = new PositionAnimation();
        public PositionAnimation UnHoverAnimation = new PositionAnimation();

        public static void HandleHover(Gesture.OnHover evt, PlantSelectionMenuVisuals target)
        {
            //AnimationHandle handle = target.HoverAnimation.Run(0.2f);
        }

        public static void HandleUnhover(Gesture.OnUnhover evt, PlantSelectionMenuVisuals target)
        {
            //AnimationHandle handle = target.UnHoverAnimation.Run(0.2f);
        }
    }
}