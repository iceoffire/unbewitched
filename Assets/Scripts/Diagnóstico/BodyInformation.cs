using System;

[Serializable]
public struct BodyInformation
{
    public BodyPartOrigin bodyPart;
    public NotifyInformation notifyInformation;
}

public enum BodyPartOrigin
{
    Frog,
    Cthulhu,
    Horse,
    Human
}