using P01._FileStream_After.Contracts;

namespace P01._FileStream_After
{
    public abstract class Result : IResult
    {
        public int Length { get; set; }

        public int Sent { get; set; }
    }
}
