
using MusicFactoryLib;

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
                break;
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
