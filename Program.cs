using System;
using System.Collections.Generic;

public class Program
{
    public static string OldPhonePad(string input)
    {
        Dictionary<char, string> keypad = new Dictionary<char, string>()
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" },
            { '0', " " }
        };

        string result = "";
        char prevChar = '\0';
        int count = 0;

        foreach(char c in input){
            if(c == '#') break;
            
            if(keypad.ContainsKey(c)){
                if (c == prevChar){
                    count = count + 1;
                }else{
                    if (prevChar != '\0'){
                        string letters = keypad[prevChar];
                        result = result + letters[(count-1) % letters.Length];
                    }
                    prevChar = c;
                    count = 1;
                }
            }else if (c == ' '){
                if (prevChar != '\0'){
                    string letters = keypad[prevChar];
                    result += letters[(count-1) % letters.Length];
                    prevChar = '\0';
                    count = 0;
                }
            }else if (c == '*'){
                if (prevChar != '\0'){
                    prevChar = '\0';
                    count = 0;
                }
                else if(result.Length > 0){
                    result = result.Substring(0, result.Length - 1);
                }
            }
        }

        if (prevChar != '\0'){
            string letters = keypad[prevChar];
            result = result + letters[(count-1) % letters.Length];
        }
        return result;
    }

    public static void Main()
    {
        string message = OldPhonePad("4433555 555666#");
        Console.WriteLine(message);
        string message2 = OldPhonePad("8 88777444666*664#");
        Console.WriteLine(message2);
    }
}
