using System;

public interface IMelody
{
    void PlayMelody();
}

public interface IArtist
{
    void Perform();
}

public interface IInstrument
{
    void PlayInstrument();
}

public abstract class MusicFactory
{
    public abstract IMelody CreateMelody();
    public abstract IArtist CreateArtist();
    public abstract IInstrument CreateInstrument();
}

public class PopMusicFactory : MusicFactory
{
    public override IMelody CreateMelody() => new GenericMelody("Pop melody");
    public override IArtist CreateArtist() => new GenericArtist("Pop artist");
    public override IInstrument CreateInstrument() => new GenericInstrument("Pop instrument");
}

public class RockMusicFactory : MusicFactory
{
    public override IMelody CreateMelody() => new GenericMelody("Rock melody");
    public override IArtist CreateArtist() => new GenericArtist("Rock artist");
    public override IInstrument CreateInstrument() => new GenericInstrument("Rock instrument");
}

public class ClassicalMusicFactory : MusicFactory
{
    public override IMelody CreateMelody() => new GenericMelody("Classical melody");
    public override IArtist CreateArtist() => new GenericArtist("Classical artist");
    public override IInstrument CreateInstrument() => new GenericInstrument("Classical instrument");
}

public class GenericMelody : IMelody
{
    private readonly string _melody;
    public GenericMelody(string melody) => _melody = melody;
    public void PlayMelody() => Console.WriteLine($"Playing {_melody}.");
}

public class GenericArtist : IArtist
{
    private readonly string _artist;
    public GenericArtist(string artist) => _artist = artist;
    public void Perform() => Console.WriteLine($"Performing {_artist}.");
}

public class GenericInstrument : IInstrument
{
    private readonly string _instrument;
    public GenericInstrument(string instrument) => _instrument = instrument;
    public void PlayInstrument() => Console.WriteLine($"Playing {_instrument}.");
}

class GuessTheMelodyGame
{
    private readonly IMelody _melody;
    private readonly IArtist _artist;
    private readonly IInstrument _instrument;

    public GuessTheMelodyGame(MusicFactory factory)
    {
        _melody = factory.CreateMelody();
        _artist = factory.CreateArtist();
        _instrument = factory.CreateInstrument();
    }

    public void StartGame()
    {
        _melody.PlayMelody();
        _artist.Perform();
        _instrument.PlayInstrument();
    }
}

class Program
{
    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("Choose music genre (1 - Pop, 2 - Rock, 3 - Classical): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
            {
                break; // Вихід з циклу, якщо число правильне
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number between 1 and 3.");
            }
        } while (true);

        MusicFactory factory = choice switch
        {
            1 => new PopMusicFactory(),
            2 => new RockMusicFactory(),
            3 => new ClassicalMusicFactory(),
            _ => throw new ArgumentException("Invalid genre choice.")
        };

        GuessTheMelodyGame game = new GuessTheMelodyGame(factory);
        game.StartGame();
    }
}
