using MediatR;

namespace CommandService.CommandModels
{
    public class CreateLocationCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public string LevelFilepath { get; set; }
        public string PosterFilepath { get; set; }
    }
}
