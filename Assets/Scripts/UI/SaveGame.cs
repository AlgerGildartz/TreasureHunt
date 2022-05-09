using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame : MonoBehaviour
{
    public void WriteSave()
    {
        Save.WriteSave();
        Menu.TextNPC.ShowTextFor("Game saved", 2);
    }
}
