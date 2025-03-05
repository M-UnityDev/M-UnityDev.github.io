using UnityEngine;
using Unity.Burst;
using TMPro;
[BurstCompile]
public class ConsoleHandler : MonoBehaviour
{
    private TMP_InputField Console;
    private string TempText = "A";
    [SerializeField] private string WelcomeText;
    [SerializeField] private string DefaultText;
    private int CommandHandlerCount;
    private string TempCommand;
    private string TempCommandArguments;
    private void Awake()
    {
        Console = GetComponent<TMP_InputField>();
        Console.text = WelcomeText;
        Console.text += DefaultText;
        Console.caretPosition = Console.text.Length;
        TempText = Console.text;
    }
    private void Update()
    {
        if(TempText.Length < Console.text.Length)
        {
            if(Console.text.Remove(TempText.Length) != TempText)
            {
                Console.text = TempText + Console.text.Remove(0,TempText.Length);
                Console.caretPosition = TempText.Length;
            }
        }
        if(Console.caretPosition < TempText.Length)
        {
            Console.caretPosition = TempText.Length;
        }
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
            CommandProcessor(Console.text.Replace(TempText, "").TrimEnd("\n".ToCharArray()));
            Console.text += "\n" + DefaultText;
            UpdateText();
        }
    }
    public void CommandProcessor(string Command)
    {
        if (Command.Replace(" ", "") == "") return;
        CommandHandlerCount = 0;
        TempCommand = null;
        TempCommandArguments = null;
        if (Command.Contains(" ")) 
        {
            foreach(char c in Command)
            { 
                if (c == ' ') break;
                CommandHandlerCount+=1;
            }
            if (Command.Length <= CommandHandlerCount+1) NoArguments(Command);
            else
            {
                TempCommand = Command.Remove(CommandHandlerCount);
                TempCommandArguments = Command.Remove(0,CommandHandlerCount+1);
            }
        }
        else 
            NoArguments(Command);
        if (TryGetComponent(out IConsoleCommands Commands))
            Commands.CommandHandler(TempCommand,TempCommandArguments, Console);

    }
    private void NoArguments(string Command)
    {
        TempCommand = Command;
        TempCommandArguments = null;
    }
    private void UpdateText()
    {
        TempText = Console.text;
        Console.caretPosition = TempText.Length;
    }
}