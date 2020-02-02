using System;

public static class DiagnosticSceneInformation
{
    public static PlayerDiagnosticInfo playerDiagnosticInfo;

    internal static void LoadInformation(PlayerDiagnosticInfo playerDiagnosticInfo)
    {
        DiagnosticSceneInformation.playerDiagnosticInfo = playerDiagnosticInfo;
    }
}