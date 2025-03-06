using UnityEngine;
using Unity.Burst;
using TMPro;
[BurstCompile]
public class ConsoleCommands : MonoBehaviour, IConsoleCommands
{
    public void CommandHandler(string Command, string Arguments, TMP_InputField Console)
    {
        switch (Command)
        {
            case "echo":
                Console.text += Arguments;
                break;
            case "fastfetch":
                Console.text += "\n     <b><color=black>################</color>     OS:</b> M-Unity's Weird Website \n     <b><color=black>##</color><color=red>############</color><color=black>##</color>     Kernel:</b> Unity 6000.0.23f1 \n     <b><color=black>##</color><color=red>##</color><color=black>##</color><color=red>##</color><color=red>##</color><color=black>##</color><color=red>##</color><color=black>##</color>     Shell:</b> mish 0.1 \n     <b><color=black>##</color><color=red>############</color><color=black>##</color>     Terminal:</b> muitty 0.1.0 \n     <b><color=black>##</color><color=red>##</color><color=black>##</color><color=red>##</color><color=red>##</color><color=black>##</color><color=red>##</color><color=black>##</color>     Terminal Font:</b> JetBrainsMonoNFM-Regular (15pt)" + "\n     <b><color=black>##</color><color=red>####</color><color=black>####</color><color=red>####</color><color=black>##</color></b>" + "\n     <b><color=black>##</color><color=red>############</color><color=black>##</color></b>" + "\n     <b><color=black>################</color>\n\n</b>";
                break;
            default:
                Console.text += "mish: Unknown command or command doesn't have this argument \n";
                break;
        }
    }
}