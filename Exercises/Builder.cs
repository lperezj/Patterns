using System.Collections.Generic;

namespace Exercises
{
    public class Builder
    {
        public string className;
        Dictionary<string, string> fields = new Dictionary<string, string>();

        public Builder(string className)
        {
            this.className = className;
        }

        public Builder AddField(string type, string name)
        {
            fields.Add(type, name);
            return this;
        }

        public override string ToString()
        {
            string classContent = "";
            foreach (var entry in fields)
            {
                string currentType = entry.Value.ToString();
                string currentName = entry.Key.ToString();
                classContent += $"\n  public {currentType} {currentName};";
            }
            string classOutput = $"public class {className}\n{{{classContent}\n}}";
            return classOutput;
        }
    }
}
