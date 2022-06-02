namespace ImPlotNET
{
    [System.Flags]
    public enum ImPlotAxisFlags
    {
        None = 0,
        NoLabel = 1,
        NoGridLines = 2,
        NoTickMarks = 4,
        NoTickLabels = 8,
        NoInitialFit = 16,
        NoMenus = 32,
        Opposite = 64,
        Foreground = 128,
        LogScale = 256,
        Time = 512,
        Invert = 1024,
        AutoFit = 2048,
        RangeFit = 4096,
        LockMin = 8192,
        LockMax = 16384,
        Lock = 24576,
        NoDecorations = 15,
        AuxDefault = 66,
    }
}
