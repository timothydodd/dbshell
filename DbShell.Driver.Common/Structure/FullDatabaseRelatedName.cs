namespace DbShell.Driver.Common.Structure
{
    public class FullDatabaseRelatedName
    {
        public string ObjectType;
        public NameWithSchema ObjectName;
        public string SubName;

        public override string ToString()
        {
            if (ObjectName != null)
            {
                return ObjectName.ToString();
            }
            return base.ToString();
        }
    }
}