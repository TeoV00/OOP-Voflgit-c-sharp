namespace TestProject1.Luana_Mennuti;

public interface IAbilityInTheBox
{
     /**
         *   This method is used to identify the ability.
         *   @return the id of the ability.
         */
     EAbility GetIdAbility();
     /**
         * This method is used to get the type of the ability. (Instant and durable)
         * @return the dimension of the box.
         */
     ETypeAbility GetTypeAbility();
     /**
         * This method is used if the box is shown.
         * @return true if the box is shown, false otherwise.
         */
     bool IsShow();
    /**
     * This method is used to verify if the ability has been actived.
     * @return true if the activation is true, false otherwise.
     */
    bool IsActivated();
    /**
     * Show the box.
     */
    void Show();
    /**
     * Hide the box.
     */
    void Hide();
}