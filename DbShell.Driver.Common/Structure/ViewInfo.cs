using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class ViewInfo : SpecificObjectInfo
    {
        public ViewInfo(DatabaseInfo database)
            : base(database)
        {
        }

        [XmlSubElem]
        public QueryResultInfo QueryInfo { get; set; }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.View; }
        }

        public ViewInfo CloneView(DatabaseInfo ownerDb = null)
        {
            var res = new ViewInfo(ownerDb ?? OwnerDatabase);
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneView(owner as DatabaseInfo);
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ViewInfo) source;
            if (src.QueryInfo != null) QueryInfo = src.QueryInfo.Clone();
        }
    }
}