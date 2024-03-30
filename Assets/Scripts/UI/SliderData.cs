using UnityEngine;

[System.Serializable]
public class SliderData
{
    [SerializeField]
    private float value;
    public float min;
    public float max;
    public string valueFormat = "{0:0.0}";

    public float Value
    {
        get => Mathf.Clamp(value, min, max);
        set => this.value = Mathf.Clamp(value, min, max);
    }

    public string DisplayValue => string.Format(valueFormat, Value);
}