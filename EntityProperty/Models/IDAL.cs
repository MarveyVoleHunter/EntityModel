using System.Data;

namespace EntityModel.Models
{
    public interface IDAL
    {
        void ExecuteNonQuery(IDbCommand command);
    }
}
