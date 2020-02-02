using System;

public static class DiagnosticSceneInformation
{
    public static PlayerDiagnosticInfo playerDiagnosticInfo;
    public static bool sucess;
    public static BodyPartOrigin monsterType;

    internal static void LoadInformation(PlayerDiagnosticInfo playerDiagnosticInfo)
    {
        DiagnosticSceneInformation.playerDiagnosticInfo = playerDiagnosticInfo;
    }
}