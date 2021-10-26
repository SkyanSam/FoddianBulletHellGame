public class PaletteEvent : FoddianEvent
{
    public ColorPalette palette2;
    public ColorPalette palette1;
    public override void StartEvent(params System.Type[] parameters)
    {
        if (ColorManager.Instance.nextColorPalette == palette1)
            ColorManager.Instance.TransitionToColor(palette2);
        else
            ColorManager.Instance.TransitionToColor(palette1);
    }
}
