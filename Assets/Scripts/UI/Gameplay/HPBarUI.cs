using AttributeSystem.Components;
using Nova;
using PVZ.Attributes;
using UnityEngine;

public class HPBarUI : MonoBehaviour
{
    [SerializeField] private ItemView View;
    private HPBarVisuals Visuals;

    [SerializeField] private AttributeDependentBehaviour hp;
    private SliderData SliderData = new SliderData();

    private void Start()
    {
        Visuals = View.Visuals as HPBarVisuals;
        SliderData.max = GetHP().BaseValue;
        SliderData.Value = GetHP().BaseValue;
    }

    private void Update()
    {
        HPUpdate();
    }

    private void HPUpdate()
    {
        float sliderWidth = Visuals.Background.CalculatedSize.X.Value;
        //float sliderWidthPercent = Visuals.Fill.CalculatedSize.X.Value / sliderWidth;

        //Debug.Log(Visuals.Background.CalculatedSize.X.Value);
        //Debug.Log(Visuals.Fill.CalculatedSize.X.Value);
        //Debug.Log(sliderWidthPercent);

        float distanceFromLeft = GetHP().CurrentValue + 0.5f * sliderWidth;
        float percentFromLeft = Mathf.Clamp01(distanceFromLeft / sliderWidth);

        SliderData.Value = SliderData.min + percentFromLeft * (SliderData.max - SliderData.min);

        Visuals.Fill.Size.X.Percent = percentFromLeft;
    }

    private AttributeValue GetHP()
    {
        var val = hp.GetAttributeValue(AttribiteLibrary.Instance.Attributes[new AttributeKey(AttributeSide.General, AttributeType.Health)]);
        Debug.Log(val.BaseValue);
        return val;
    }
}
