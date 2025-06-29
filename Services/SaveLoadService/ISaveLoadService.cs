namespace ZakharovA_GUN37_Casino.Services.SaveLoadService;

public interface ISaveLoadService<T>
{
    void SaveData(T data, string name);
    T LoadData(string name);
}