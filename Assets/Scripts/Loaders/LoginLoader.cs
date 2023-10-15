
public class LoginLoader : INameable
{
    public string NamePlayer { get; private set; }
    public void SetName(string name) => NamePlayer = name;
}

public interface INameable
{
    void SetName(string name);
}