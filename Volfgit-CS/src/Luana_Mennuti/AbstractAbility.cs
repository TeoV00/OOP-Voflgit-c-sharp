namespace TestProject1.Luana_Mennuti;

public abstract class AbstractAbility
{
    private readonly EAbility idAbility;
    private readonly ETypeAbility typeAbility;
    private bool show;
    private bool isActivated;
    
    protected AbstractAbility(EAbility idAbility, ETypeAbility typeAbility) {
        this.idAbility = idAbility;
        this.typeAbility = typeAbility;
        this.isActivated = false;
    }

    /**
         *   This method is used to identify the ability.
         *   @return the id of the ability.
         */
    public EAbility GetIdAbility() => this.idAbility;

    /**
         * This method is used to get the type of the ability. (Instant and durable)
         * @return the dimension of the box.
         */
    public ETypeAbility GetTypeAbility() => this.typeAbility;

    /**
         * This method is used if the box is shown.
         * @return true if the box is shown, false otherwise.
         */
    public bool IsShow() => this.show;

    /**
     * This method is used to verify if the ability has been actived.
     * @return true if the activation is true, false otherwise.
     */
    public bool IsActivated() => this.isActivated;

    /**
     * Show the box.
     */
    public void Show() => this.isActivated = true;

    /**
     * Hide the box.
     */
    public void Hide() => this.isActivated = false;

}