namespace HwTest.BL.Interfaces;

public interface IFactory<out T>
{
    T Create();
}
