using System.Text;
using System.Text.RegularExpressions;

namespace Leetcode.Helpers
{
    internal class GenerateDocumentationIndex
    {
        public void GenerateIndex()
        {
            string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.FullName;
            string rootPath = Path.Combine(projectRoot, "Documentation");
            string outputPath = Path.Combine(rootPath, "StrategyPlaybook.md");
            string problemsFolder = Path.Combine(rootPath, "Problems");

            Directory.CreateDirectory(problemsFolder);

            var folders = Directory.GetDirectories(rootPath);
            var sb = new StringBuilder();

            sb.AppendLine("# 🧠 Strategy Playbook");
            sb.AppendLine();
            sb.AppendLine("A consolidated reference of all strategy tradeoffs across problems.");
            sb.AppendLine();
            sb.AppendLine("## 📋 Table of Contents");
            sb.AppendLine();

            var sections = new List<(string problemName, string anchor, string descriptionLink, string content)>();

            foreach (var folder in folders.OrderBy(f => f))
            {
                string folderName = Path.GetFileName(folder);
                string anchor = folderName.ToLower().Replace(" ", "-").Replace(".", "").Replace("_", "-");

                var tradeoffFile = Directory.GetFiles(folder, "*Tradeoffs.md").FirstOrDefault();
                if (tradeoffFile == null) continue;

                var descriptionFile = Directory.GetFiles(folder, "Description.md").FirstOrDefault();
                string descriptionTarget = "";

                if (descriptionFile != null)
                {
                    string newPath = Path.Combine(problemsFolder, $"{folderName}-Description.md");
                    File.Copy(descriptionFile, newPath, overwrite: true);
                    descriptionTarget = $"./Problems/{folderName}-Description.md";
                }

                string content = File.ReadAllText(tradeoffFile);
                sections.Add((folderName, anchor, descriptionTarget, content));
            }

            foreach (var section in sections)
            {
                sb.AppendLine($"- [{section.problemName}](#{section.anchor})");
            }

            sb.AppendLine("\n---\n");

            foreach (var section in sections)
            {
                sb.AppendLine($"## {section.problemName}");
                sb.AppendLine($"<a name=\"{section.anchor}\"></a>");
                sb.AppendLine();

                if (!string.IsNullOrEmpty(section.descriptionLink))
                    sb.AppendLine($"📘 [Problem Description]({section.descriptionLink})\n");

                sb.AppendLine(section.content.Trim());
                sb.AppendLine("\n---\n");
            }

            File.WriteAllText(outputPath, sb.ToString());
            Console.WriteLine("✅ StrategyPlaybook.md generated and descriptions moved.");
        }
    }
}
