using UnityEngine;
using Nova;
using PVZ.Player;
using PVZ.Attributes;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace PVZ.UI
{
    public class AttributeUIText : SerializedMonoBehaviour
    {
        [SerializeField] 
        private TextBlock textBlock;

        [OdinSerialize] 
        private AttributeKey attributeKey;

        private void Update()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            var attributeLibrary = AttribiteLibrary.Instance;

            if (!attributeLibrary.TryGetAttribute(attributeKey, out var attribute))
                return;

            var value = PlayerController.Instance.GetAttributeValue(attribute);

            textBlock.Text = value.CurrentValue.ToString();
        }
    }
}