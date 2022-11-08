namespace TestProject1.Alexandru_Bragari;

public interface IEventHandler<T>
{
    public void Handle(ref T e);
}