using UnityEngine;
using Unity.Burst;
using TMPro;
using UnityEngine.SceneManagement;
[BurstCompile]
public class MUUBDirector : MonoBehaviour
{
    private TMP_InputField Console;
    private string TempText = "A";
    [SerializeField] private string WelcomeText;
    [SerializeField] private string DefaultText;
    [SerializeField] private string OSListText;
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
            CommandHandler(Console.text.Replace(TempText, "").TrimEnd("\n".ToCharArray()));
            UpdateText();
        }
    }
    public void CommandHandler(string Command)
    {
        if (Command.Length >= 5 && Command == "echo " + Command.Remove(0,5) || Command == "echo")
        {   
            Console.text +=  Command.Remove(0,5) + "\n" + DefaultText;
            return;
        }
        else if (Command.Length >= 5 && Command == "boot " + Command.Remove(0,5) || Command == "boot")
        {   
            LoadOS(Command.Remove(0,5).Replace(" ", null));
            return;
        }
        else if (Command.Length >= 4 && Command.Remove(0,4) == "" || Command == "list")
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
            default:
                Console.text += "muub: Unknown OS \n" + DefaultText;
                break;
        }
    }
}