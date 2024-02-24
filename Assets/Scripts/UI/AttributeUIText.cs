using UnityEngine;
using Nova;
using AttributeSystem.Authoring;
using PVZ.Player;

namespace PVZ.UI
{
    public class AttributeUIText : MonoBehaviour
    {
        [SerializeField] private AttributeScriptableObject attribute;

        [SerializeField] private TextBlock textBlock;

        private void Start()
        {
            UpdateText();
        }

        private void Update()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            var value = PlayerController.Instance.GetAttributeValue(attribute);

            textBlock.Text = value.CurrentValue.ToString();
        }
    }
}