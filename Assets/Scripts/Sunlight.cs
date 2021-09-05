using UnityEngine;

public enum UniverseCode
{
    None, Universe1, Universe2, Universe3, Universe4, Universe5, Universe6
}

public class Sunlight : MonoBehaviour
{
    private Light sunLight;

    [SerializeField]
    private Color firstRoomLightColor, universe1LightColor, universe2LightColor,
                  universe3LightColor, universe4LightColor, universe5LightColor,
                  universe6LightColor;

    void Start()
    {
        sunLight = GetComponent<Light>();
    }

    public void ChangeLightColor(UniverseCode value)
    {
        switch(value)
        {
            case UniverseCode.Universe1:
                sunLight.color = universe1LightColor;
                return;

            case UniverseCode.Universe2:
                sunLight.color = universe2LightColor;
                return;

            case UniverseCode.Universe3:
                sunLight.color = universe3LightColor;
                return;

            case UniverseCode.Universe4:
                sunLight.color = universe4LightColor;
                return;

            case UniverseCode.Universe5:
                sunLight.color = universe5LightColor;
                return;

            case UniverseCode.Universe6:
                sunLight.color = universe6LightColor;
                return;

            default:
                sunLight.color = firstRoomLightColor;
                return;
        }
    }
}
