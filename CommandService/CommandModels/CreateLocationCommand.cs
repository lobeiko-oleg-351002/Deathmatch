using MediatR;

namespace CommandService.CommandModels
{
    public class CreateLocationCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public byte[] Poster { get; set; }
        public byte[] Binaries { get; set; }
    }
}
