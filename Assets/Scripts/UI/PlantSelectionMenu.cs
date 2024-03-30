using System.Collections.Generic;
using UnityEngine;
using Nova;
using PVZ.Plants;

namespace PVZ.UI
{
    public class PlantSelectionMenu : MonoBehaviour
    {
        public UIBlock Root = null;
        public UIBlock PlantSelectionPanel = null;

        public ListView PlantCardsView = null;

        private IList<PlantShopInfoSO> PlantsList = null;


        private void Start()
        {
            PlantsList = PlantsSelector.Instance.GetValues();

            Root.AddGestureHandler<Gesture.OnHover, PlantSelectionCardVisuals>(PlantSelectionCardVisuals.HandleHover);
            Root.AddGestureHandler<Gesture.OnUnhover, PlantSelectionCardVisuals>(PlantSelectionCardVisuals.HandleUnhover);
            Root.AddGestureHandler<Gesture.OnPress, PlantSelectionCardVisuals>(PlantSelectionCardVisuals.HandlePress);
            Root.AddGestureHandler<Gesture.OnRelease, PlantSelectionCardVisuals>(PlantSelectionCardVisuals.HandleRelease);

            PlantSelectionPanel.AddGestureHandler<Gesture.OnHover, PlantSelectionMenuVisuals>(PlantSelectionMenuVisuals.HandleHover);
            PlantSelectionPanel.AddGestureHandler<Gesture.OnUnhover, PlantSelectionMenuVisuals>(PlantSelectionMenuVisuals.HandleUnhover);

            PlantCardsView.AddGestureHandler<Gesture.OnClick, PlantSelectionCardVisuals>(PlantCardClicked);

            PlantCardsView.AddDataBinder<PlantShopInfoSO, PlantSelectionCardVisuals>(BindPlant);

            PlantCardsView.SetDataSource(PlantsList);
        }

        private void PlantCardClicked(Gesture.OnClick evt, PlantSelectionCardVisuals visuals, int index)
        {
            PlantName plantName = PlantsList[index].Name;

            PlantsSelector.Instance.SetCurrentPlant(plantName);
        }

        private void BindPlant(Data.OnBind<PlantShopInfoSO> evt, PlantSelectionCardVisuals visuals, int index)
        {
            PlantShopInfoSO plantInfo = evt.UserData;

            var cost = -plantInfo.Cost.gameplayEffect.Modifiers[0].Multiplier;

            visuals.Cost.Text = cost.ToString();
        }
    }
}

