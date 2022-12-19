namespace GuessingGameCollection.UI;

public interface IUI
{
    public string GetStringInput();

    public void OutputString(string s);

    public void Exit();
}