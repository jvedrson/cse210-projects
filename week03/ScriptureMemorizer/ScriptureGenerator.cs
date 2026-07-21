using System;

public class ScriptureGenerator
{
    private Random _randomGenerator = new Random();
    private string _bookSelected;
    private List<Scripture> _oldTestament = new List<Scripture>
    {
        new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he sall direct thy paths."
        ),
        new Scripture(
            new Reference("Isaiah", 1, 18),
            "Come now, and let us reason together, saith the Lord: though your sins be as scarlet, they shall be as white as snow; though they be red like crimson, they shall be as wool."
        ),
        new Scripture(
            new Reference("Isaiah", 5, 20),
            "Woe unto them that call evil good, and good evil; that put darkness for light, and light for darkness; that put bitter for sweet, and sweet for bitter!"
        ),
        new Scripture(
            new Reference("Genesis ", 26, 27),
            "God created man in his own image, in the image of God created he him; male and female created he them."
        ),
        new Scripture(
            new Reference("Amos ", 3, 7),
            "Surely the Lord God will do nothing, but he revealeth his secret unto his servants the prophets."
        )
    };

    private List<Scripture> _newTestament = new List<Scripture>
    {
        new Scripture(
            new Reference("Matthew", 11, 28, 30),
            "Come unto me, all ye that labour and are heavy laden, and I will give you rest. Take my yoke upon you, and learn of me; for I am meek and lowly in heart: and ye shall find rest unto your souls. For my yoke is easy, and my burden is light."
        ),
        new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        ),
        new Scripture(
            new Reference("John", 14, 15),
            "If ye love me, keep my commandments."
        ),
        new Scripture(
            new Reference("1 Corinthians", 15, 20, 22),
            "But now is Christ risen from the dead, and become the firstfruits of them that slept. For since by man came death, by man came also the resurrection of the dead. For as in Adam all die, even so in Christ shall all be made alive."
        ),
        new Scripture(
            new Reference("James", 1, 5, 6),
            "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tossed."
        )
    };

    private List<Scripture> _bookOfMormon = new List<Scripture>
    {
        new Scripture(
            new Reference("1 Nephi", 3, 7),
            "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."
        ),
        new Scripture(
            new Reference("2 Nephi", 2, 25),
            "Adam fell that men might be; and men are, that they might have joy."
        ),
        new Scripture(
            new Reference("2 Nephi", 25, 26),
            "And we talk of Christ, we rejoice in Christ, we preach of Christ, we prophesy of Christ, and we write according to our prophecies, that our children may know to what source they may look for a remission of their sins."
        ),
        new Scripture(
            new Reference("Mosiah", 2, 17),
            "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."
        ),
        new Scripture(
            new Reference("Moroni", 10, 4, 5),
            "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may know the truth of all things."
        )
    };

    public string GetBookSelected()
    {
        return _bookSelected;
    }

    public Scripture GetRandomScripture(string book)
    {
        Scripture scripture;

        switch (book)
        {
            case "1":
                scripture = _oldTestament[_randomGenerator.Next(_oldTestament.Count)];
                _bookSelected = "Old Testament";
                break;
            case "2":
                scripture = _newTestament[_randomGenerator.Next(_newTestament.Count)];
                _bookSelected = "New Testament";
                break;
            case "3":
                scripture = _bookOfMormon[_randomGenerator.Next(_bookOfMormon.Count)];
                _bookSelected = "The Book of Mormon";
                break;
            default:
                scripture = _oldTestament[_randomGenerator.Next(_oldTestament.Count)];
                _bookSelected = "Old Testament";
                break;
        }

        return scripture;
    }
}