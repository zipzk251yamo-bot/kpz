namespace DesignPatterns.Adapter
{

    class FileLoggerAdapter : Logger
    {
        private FileWriter _fileWriter;

        public FileLoggerAdapter(FileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public override void Log(string message)
        {
            _fileWriter.WriteLine($"[FILE-LOG]: {message}");
        }

        public override void Error(string message)
        {
            _fileWriter.WriteLine($"[FILE-ERROR]: {message}");
        }

        public override void Warn(string message)
        {
            _fileWriter.WriteLine($"[FILE-WARN]: {message}");
        }
    }
}