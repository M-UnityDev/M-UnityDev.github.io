using UnityEngine;
using Unity.Burst;
using TMPro;
using UnityEngine.SceneManagement;
[BurstCompile]
public class MUUBCommands : MonoBehaviour, IConsoleCommands
{
    private TMP_InputField TempConsole;
    [SerializeField] private string[] OSList;
    private string OSListText;
    private int OSCount;
    private void Awake()
    {
        foreach(string OS in OSList)
        {
            OSCount++;
            OSListText += OS.Insert(0, "\n  " + OSCount.ToString() + ". ");
        }
        OSListText += "\n ";
    }
    public void CommandHandler(string Command, string Arguments, TMP_InputField Console)
    {
        TempConsole = Console;
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
    private void LoadOS(string OSName)
    {
        switch (OSName)
        {
            case "5MBD":
                SceneManager.LoadScene("[5MBD]CutScene");
                break;
            case "C&BD":
                TempConsole.text += "muub: C&BD is coming soon";
                //SceneManager.LoadScene("[C&BD]");
                break;
            case "MWW":
                TempConsole.text += "muub: MWW is coming soon";
                //SceneManager.LoadScene("[MWW]");
                break;
            default:
                TempConsole.text += "muub: Unknown OS";
                break;
        }
    }
}