using Chess.GameLogic.Interfaces;

namespace Chess.GameLogic.Detectors
{
    internal class AvailableCagesDetectorBuilder
    {
        private readonly List<IPieceTypeAvailableCagesDetector> _detectors = new();

        public AvailableCagesDetectorBuilder AddDetector(IPieceTypeAvailableCagesDetector detector)
        {
            if(_detectors.Any(det => det.PieceName == detector.PieceName))
            {
                throw new ArgumentException("detector for this figure type is already in builder");
            }

            _detectors.Add(detector);
            return this;
        }

        public AvailableCagesDetector Build()
        {
            return new AvailableCagesDetector(_detectors);
        }
    }
}
