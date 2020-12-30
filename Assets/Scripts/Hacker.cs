using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private string[] level1Passwords = { "apple", "banana", "pear", "cherry", "grape" };
    private string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };

    private int level;
    public string password;

    public enum Screen { MainMenu, Password, Win };
    public Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    private void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You can type menu whenever to come back");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the fruit library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection: ");
    }

    private void OnUserInput(string input)
    {

        if( currentScreen == Screen.MainMenu )
        {
            RunMainMenu(input);
        }

        else if ( currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

        if( input == "menu")
        {
            ShowMainMenu();
            currentScreen = Screen.MainMenu;
        }

    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if ( isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        

        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    private void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;

            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            
            default:
                Debug.LogError("Invalid level number");
                break;

        }

        Terminal.WriteLine("Please enter your password, hint: " + password.Anagram());
    }

    private void CheckPassword( string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }

        else
        {
            Terminal.WriteLine("Wrong, try again!!");
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch ( level )
        {
            case 1:
                Terminal.WriteLine("You are a fruit god!!");
                break;
            case 2:
                Terminal.WriteLine("You are under arrest!!");
                break;

        }
    }
}
