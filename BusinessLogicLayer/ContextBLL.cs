using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ContextBLL : IDisposable
    {
        ContextDAL _context = new ContextDAL();
        public ContextBLL()
        {
            _context.ConnectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<RoleBLL> RoleGetAll(int skip, int take)
        {
            List<RoleBLL> ProposedReturnValue = new List<RoleBLL>();
            List<RoleDAL> items = _context.RolesGetAll(skip, take);

            foreach (RoleDAL item in items)
            {
                RoleBLL correctedItem = new RoleBLL(item);
                ProposedReturnValue.Add(correctedItem);
            }

            return ProposedReturnValue;

        }
        public RoleBLL RoleFindByID(int RoleID)
        {
            RoleBLL proposedReturnValue = null;
            RoleDAL item = _context.RoleFindbyID(RoleID);
            if (item != null)
            {
                proposedReturnValue = new RoleBLL(item);
            }
            return proposedReturnValue;
        }
    }
}
