using Tymski;

public class LevelSelectedMessage
{
    private readonly SceneReference _scene;

    public SceneReference Scene => _scene;

    public LevelSelectedMessage(SceneReference scene) 
    {
        _scene = scene;
    }
}
