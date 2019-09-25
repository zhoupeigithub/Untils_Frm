using System.Data.Common;

namespace Untils_DALProfile
{
    public interface IDbBase
    {
        DbCommand CreateCommand();
        DbConnection CreateConnection();
        DbDataAdapter CreateDataAdapter();
        DbParameter CreateParameter();
    }
}
