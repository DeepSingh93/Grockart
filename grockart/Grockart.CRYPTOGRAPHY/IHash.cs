

namespace Grockart.CRYPTOGRAPHY
{
    public interface IHash
    {
        string hash(string input);
        string GetUniqueKey(int blockSize);
    }
}
