public class MusicVolume : VolumeSlider
{
    protected override string GetParameter()
    {
        return AudioMixerData.Params.MusicVolume;
    }
}
