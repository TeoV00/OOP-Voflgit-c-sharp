namespace TestProject1.Alexandru_Bragari;

using System.Collections.Generic;
/**

*/
public class KeyEventHandler : IEventHandler<KeyCode>
{
    private KeySettings _keySettings = KeySettings.DefaultKeySettings();
    private KeyAction _keyAction;
    public void UpdateKeySettings(Dictionary<KeyCode, KeyAction> newSettings)
    {
        this._keySettings = KeySettings.FromSettings(newSettings);
    }

    private KeyAction GetActionFromKeyCode(KeyCode k)
    {
        return this._keySettings.GetAction(k);
    }
    
    public void Handle(ref KeyCode k)
    {
        {
            this._keyAction = GetActionFromKeyCode((KeyCode)k);
        }
    }
    
}


