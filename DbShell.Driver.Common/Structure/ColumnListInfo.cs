using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public abstract class ColumnListInfo : NamedObjectInfo
    {
        private ColumnList _columns = new ColumnList();

        [XmlCollection(typeof(ColumnInfo))]
        public ColumnList Columns { get { return _columns; } }

        public int ColumnCount { get { return Columns.Count; } }

        public ColumnListInfo(DatabaseInfo database)
            : base(database)
        {
        }

        protected override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ColumnListInfo) source;
            foreach (var col in src.Columns) Columns.Add(col.Clone());
        }
    }
}