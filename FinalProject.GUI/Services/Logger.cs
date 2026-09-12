namespace FinalProject.Services
{
    public static class Logger
    {
        public static void LogException(string message)
        {
            string path = Path.Combine("..", "..", "..", "logs", "errors.txt");

            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}