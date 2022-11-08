namespace TestProject1.Alexandru_Bragari;

using System.Collections.Generic;
public class KeySettings
{
    private Dictionary<KeyCode, KeyAction> _currentSettings;
    private KeySettings(Dictionary<KeyCode, KeyAction> settings)
    {
        this._currentSettings = settings;
    }

    public static KeySettings DefaultKeySettings()
    {
        /*
        var settings = new Dictionary<KeyCode,KeyAction>();
        foreach (var code in Enum.GetNames(typeof(KeyAction)))
        {
            if ( Enum.Parse<KeyAction>(code) != KeyAction.NOACTION)
            {
                settings.Add(Enum.Parse<KeyCode>(code),Enum.Parse<KeyAction>(code));
            } 
        }
        */

        var s = Enum.GetNames(typeof(KeyAction)).Where(t => !t.Equals("NOACTION"))
            .Select(t => Enum.Parse<KeyAction>(t)).ToDictionary(t => Enum.Parse<KeyCode>(t.ToString()));
        return new KeySettings(s);
    }

    public static KeySettings FromSettings(Dictionary<KeyCode, KeyAction> settings)
    {
        return new KeySettings(settings);
    }

    public KeyAction GetAction(KeyCode k)
    {
        try
        {
            var t = this._currentSettings[k];
            return t;
        }
        catch (Exception e)
        {
            if (e is ArgumentNullException or KeyNotFoundException)
            {
                return KeyAction.NOACTION;
            }
            else
            {
                throw;
            }
                
        }
    }
}