using UnityEngine;
using Unity.Burst;
using TMPro;
[BurstCompile]
public class ConsoleDirector : MonoBehaviour
{
    private TMP_InputField Console;
    private string TempText = "A";
    [SerializeField] private string WelcomeText;
    [SerializeField] private string DefaultText;
    private void Awake()
    {
        Console = GetComponent<TMP_InputField>();
        Console.text = WelcomeText;
        Console.text += DefaultText;
        Console.caretPosition = Console.text.Length;
        TempText = null;
        TempText = Console.text;
    }
    public void ChangeHandler()
    {
        if(Console.text.Length < TempText.Length)
        {
            Console.text = TempText;
            Console.caretPosition = TempText.Length;
        }
        else if(Console.text.EndsWith("\n"))
        {
            CommandHandler(Console.text.Replace(TempText, null).TrimEnd("\n".ToCharArray()));
            UpdateText();
        }
    }
    public void CommandHandler(string Command)
    {
        if (Command == "echo " + Command.TrimStart("echo ".ToCharArray()) || Command == "echo")
        {   
            Console.text += Command.TrimStart("echo ".ToCharArray()) + "\n" + DefaultText;
        }
        else if (Command.Replace(" ", null) == "clear" && Command.TrimStart("clear".ToCharArray()) == "")
        {
            TempText = DefaultText;
            Console.text = TempText;
        }
        else if (Command.Replace(" ", null) == "fastfetch" && Command.TrimStart("fastfetch".ToCharArray()) == "")
        {
            Console.text += "\n     <b><color=black>################</color>     OS:</b> M-Unity's Weird Website \n     <b><color=black>##</color><color=red>############</color><color=black>##</color>     Kernel:</b> Unity 6000.0.23f1 \n     <b><color=black>##</color><color=red>##</color><color=black>##</color><color=red>##</color><color=red>##</color><color=black>##</color><color=red>##</color><color=black>##</color>     Shell:</b> mish 0.1 \n     <b><color=black>##</color><color=red>############</color><color=black>##</color>     Terminal:</b> muitty 0.1.0 \n     <b><color=black>##</color><color=red>##</color><color=black>##</color><color=red>##</color><color=red>##</color><color=black>##</color><color=red>##</color><color=black>##</color>     Terminal Font:</b> JetBrainsMonoNFM-Regular (15pt)" + "\n     <b><color=black>##</color><color=red>####</color><color=black>####</color><color=red>####</color><color=black>##</color></b>" + "\n     <b><color=black>##</color><color=red>############</color><color=black>##</color></b>" + "\n     <b><color=black>################</color>\n\n</b>" + DefaultText;
        }
        else if (Command.Replace(" ", null) == "")
        {
            Console.text += DefaultText;
        }
        else
        {
            Console.text += "mish: Unknown command or command doesn't have this argument" + "\n" + DefaultText;
        }
    }
    private void UpdateText()
    {
        TempText = Console.text;
        Console.caretPosition = TempText.Length;
    }
}