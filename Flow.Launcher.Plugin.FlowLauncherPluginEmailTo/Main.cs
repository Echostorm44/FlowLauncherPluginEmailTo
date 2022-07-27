using Flow.Launcher.Plugin;
using System;
using System.Collections.Generic;

namespace Flow.Launcher.Plugin.EmailTo
{
    public class EmailTo : IPlugin
    {
        private const string Image = "icon.png";
        private PluginInitContext _context;

        public void Init(PluginInitContext context)
        {
            _context = context;
        }

        public List<Result> Query(Query query)
        {
            var splitQuery = query.Search.Split(';');
            string mailDetails = "";
            string mailDisplay = "";
            for (int i = 0; i < splitQuery.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            mailDetails = splitQuery[i];
                            mailDisplay = splitQuery[i];
                        }
                        break;
                    case 1:
                        {
                            mailDetails += "?subject=" + splitQuery[i];
                            mailDisplay += "Subject:" + splitQuery[i];
                        }
                        break;
                    case 2:
                        {
                            mailDetails += "&body=" + splitQuery[i];
                            mailDisplay += "Body:" + splitQuery[i];
                        }
                        break;
                    default:
                        {
                        }
                        break;
                }
            }
            var results = new List<Result>();
            results.Add(new Result
            {
                Title = "To:" + mailDisplay,
                SubTitle = "To;Subject;Body  eg: adam@hotmail.com;Hi;Hi There!",
                IcoPath = Image,
                Action = c =>
                {
                    var foo = SharedCommands.ShellCommand.SetProcessStartInfo($"mailto:{mailDetails}", "", "", "", true);
                    foo.UseShellExecute = true;
                    SharedCommands.ShellCommand.Execute(foo);
                    return true;
                }
            });
            return results;
        }
    }
}