using System;
using System.IO;

namespace Shared.Configurations
{
    public static class EnvConfig
    {
        public static string GetParamEnv(string param)
        {
            var root = Directory.GetCurrentDirectory();
            var dotenv = Path.Combine(root, ".env");
            Load(dotenv);

            return Environment.GetEnvironmentVariable(param);
        }

        private static void Load(string path)
        {
            var dir = path.Split("\\", StringSplitOptions.RemoveEmptyEntries);
            string _path = "";
            string _pathEnv = "";

            foreach (var item in dir)
            {
                _pathEnv = _pathEnv + item + "\\";

                if (File.Exists(_pathEnv + ("\\.env")))
                {
                    _path = _pathEnv + ("\\.env");
                    break;
                }

            }

            if (!File.Exists(_path))
                return;

            foreach (var line in File.ReadAllLines(_path))
            {
                var pt0 = "";
                var pt1 = "";
                var part = line.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (part.Length < 2)
                    continue;

                if (part.Length > 2)
                {
                    foreach (var p in part)
                    {
                        if (string.IsNullOrEmpty(pt0))
                            pt0 = p;

                        if (p != pt0)
                            pt1 = pt1 != "" ? (pt1 + "=" + p) : (pt1 + p);
                    };
                }
                else
                {
                    pt0 = part[0];
                    pt1 = part[1];
                }
                Environment.SetEnvironmentVariable(pt0, pt1);
            }
        }
    }
}
