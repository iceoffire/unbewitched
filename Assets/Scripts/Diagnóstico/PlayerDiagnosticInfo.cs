using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Diagnostic", menuName = "ScriptableObjects/PlayerDiagnostic", order = 1)]
public class PlayerDiagnosticInfo : ScriptableObject
{
    public List<string> preDialogForTheWitcher;
    public BodyPartOrigin whoAmI;

    public BodyInformation head;
    public BodyInformation torso;
    public BodyInformation arm;
    public BodyInformation leg;
    
}