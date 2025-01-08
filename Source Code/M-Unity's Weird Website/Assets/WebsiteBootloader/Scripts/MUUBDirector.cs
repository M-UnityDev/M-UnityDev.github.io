using UnityEngine;
using Unity.Burst;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
[BurstCompile]
public class MUUBDirector : MonoBehaviour
{
    private TMP_InputField Console;
    private string TempText = "A";
    [SerializeField] private string WelcomeText;
    [SerializeField] private string DefaultText;
    [SerializeField] private string[] OSList;
    private string OSListText;
    private int OSCount;
    private int CommandHandlerCount;
    private string TempCommand;
    private string TempCommandArguments;
    private void Awake()
    {
        Console = GetComponent<TMP_InputField>();
        Console.text = WelcomeText;
        Console.text += DefaultText;
        Console.caretPosition = Console.text.Length;
        //TempText = null;
        TempText = Console.text;
        foreach(string OS in OSList)
        {
            OSCount++;
            OSListText += OS.Insert(0, "\n  " + OSCount.ToString() + ". ");
        }
        OSListText += "\n ";
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
        CommandHandler(TempCommand,TempCommandArguments);
    }
    private void NoArguments(string Command)
    {
        TempCommand = Command;
        TempCommandArguments = null;
    }
    public void CommandHandler(string Command, string Arguments)
    {
        switch (Command)
        {
            case "echo":
                Console.text += Arguments;
                break;
            case "boot":
                LoadOS(Arguments);
                break;
            case "list":
                Console.text += OSListText;
                break;
            default:
                Console.text += "muub: Unknown command";
                break;
        }
    }
    public void OLDCommandHandler(string Command)
    {
        if (Command.Length >= 5 && Command == "echo " + Command.Remove(0,5) || Command == "echo")
        {   

            try {Console.text += Command.Remove(0,5) + "\n" + DefaultText;}
            finally {Console.text += "\n" + DefaultText;}
            return;
        }
        else if (Command.Length >= 5 && Command == "boot " + Command.Remove(0,5) || Command.Contains("boot"))
        {   
            LoadOS(Command.Remove(0,5).Replace(" ", null));
            return;
        }
        else if (Command.Replace(" ", null) == "list")
        {   
            Console.text +=  OSListText + "\n" + DefaultText;
            return;
        }
        else if (Command.Replace(" ", null) == "")
        {
            Console.text += DefaultText;
            return;
        }
        else
        {
            Console.text += "muub: Unknown command \n" + DefaultText;
            return;
        }
    }
    private void UpdateText()
    {
        TempText = Console.text;
        Console.caretPosition = TempText.Length;
    }
    private void LoadOS(string OSName)
    {
        switch (OSName)
        {
            case "5MBD":
                SceneManager.LoadScene("[5MBD]CutScene");
                break;
            case "C&BD":
                Console.text += "muub: C&BD is coming soon";
                //SceneManager.LoadScene("[C&BD]");
                break;
            case "MWW":
                Console.text += "muub: MWW is coming soon";
                //SceneManager.LoadScene("[MWW]");
                break;
            default:
                Console.text += "muub: Unknown OS";
                break;
        }
    }
}