using System.Text;

namespace ZakharovA_GUN37_Casino.Services.SaveLoadService;

public class FileSystemSaveLoadService: ISaveLoadService<string>
{
    private readonly string _directory;

    public FileSystemSaveLoadService(string directory)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        _directory = directory;
    }

    public void SaveData(string data, string name)
    {
        try
        {
            File.WriteAllText(Path.Combine(_directory, name + ".txt"), data);
        }
        catch (Exception e)
        {
            Console.WriteLine("Saving failed!");
        }
    }

    public string LoadData(string name)
    {
        var result = "";
        try
        {
            result = File.ReadAllText(Path.Combine(_directory, name + ".txt"));
        }
        catch (Exception e)
        {
            Console.WriteLine("Loading failed!");
        }

        return result;
    }
}