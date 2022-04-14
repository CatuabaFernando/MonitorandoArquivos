using System;
using System.IO;
namespace NetCore_Monitor
{
    class Program
    {
        private static FileSystemWatcher _monitorar;
        public static void MonitorarArquivos(string path, string filtro)
        {
            _monitorar = new FileSystemWatcher(path, filtro)
            {
                IncludeSubdirectories = true
            };

            _monitorar.Created += OnFileChanged;
            _monitorar.Changed += OnFileChanged;
            _monitorar.Deleted += OnFileChanged;
            _monitorar.Renamed += OnFileRenamed;

            _monitorar.EnableRaisingEvents = true;
            Console.WriteLine($"Monitorando arquivos e: {filtro}");
        }
        private static void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"O Arquivo {e.Name} {e.ChangeType}");
        }
        private static void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"O Arquivo {e.OldName} {e.ChangeType} para {e.Name}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Monitorando o sistema com : FileSystemWatcher");
            string path = @"c:\dados";
            string filtro = "*.txt";
            MonitorarArquivos(path, filtro);
            Console.ReadLine();
        }
    }
}