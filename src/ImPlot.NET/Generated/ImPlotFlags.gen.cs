namespace ImPlotNET
{
    [System.Flags]
    public enum ImPlotFlags
    {
        None = 0,
        NoTitle = 1,
        NoLegend = 2,
        NoMouseText = 4,
        NoInputs = 8,
        NoMenus = 16,
        NoBoxSelect = 32,
        NoFrame = 64,
        Equal = 128,
        Crosshairs = 256,
        CanvasOnly = 55,
    }
}
