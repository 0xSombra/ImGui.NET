namespace ImPlotNET
{
    public static unsafe partial class ImPlot
    {
        const ImPlotSubplotFlags ImPlotSubplotFlags_None = ImPlotSubplotFlags.None;
        const ImPlotDragToolFlags ImPlotDragToolFlags_None = ImPlotDragToolFlags.None;
        const ImPlotCond ImPlotCond_Once = ImPlotCond.Once;
        const ImPlotBarGroupsFlags ImPlotBarGroupsFlags_None = ImPlotBarGroupsFlags.None;
        const ImPlotLegendFlags ImPlotLegendFlags_None = ImPlotLegendFlags.None;
        const ImPlotMouseTextFlags ImPlotMouseTextFlags_None = ImPlotMouseTextFlags.None;
        const int ImPlotBin_Sturges = (int)ImPlotBin.Sturges;

        static ImPlotRange ImPlotRange() => new ImPlotRange();
        static ImPlotRect ImPlotRect() => new ImPlotRect();
    }
}
