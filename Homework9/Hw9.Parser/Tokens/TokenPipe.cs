using System.Collections;

namespace Hw9.Parser.Tokens;

public class TokenPipe : IEnumerable<Token>
{
    private List<Token> _tokens = new ();

    public IReadOnlyList<Token> Tokens => _tokens;

    public Token this[int index]
    {
        get => _tokens[index];
        private set => _tokens[index] = value;
    }

    /// <summary>
    /// Текущая позиция в потоке токенов
    /// </summary>
    public int CurrentPos { get; set; }

    public int Count => _tokens.Count;

    public void Add(Token token)
        => _tokens.Add(token);

    public Token? Next() => HasNext() ? this[CurrentPos++] : null;

    public bool HasNext(int add = 0) 
        => CurrentPos + add < Count;

    public IEnumerator<Token> GetEnumerator()
        => _tokens.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => _tokens.GetEnumerator();
}